using Sharding.Core.Test.Entities;
using ShardingCore.Core.EntityMetadatas;
using ShardingCore.Core.VirtualRoutes;
using ShardingCore.Helpers;
using ShardingCore.VirtualRoutes.Mods;
using ShardingCore.VirtualRoutes.Months;
using System.Globalization;

namespace Sharding.Core.Test.EntityFrameworkCore;

/// <summary>
/// 创建虚拟路由
/// </summary>
public class OrderVirtualTableRoute() : AbstractSimpleShardingModKeyStringVirtualTableRoute<Order>(2, 3)
{
    public override void Configure(EntityMetadataTableBuilder<Order> builder)
    {
        builder.ShardingProperty(o => o.Id);
        builder.AutoCreateTable(null);
        builder.TableSeparator("_");
    }
}

/// <summary>
/// 创建虚拟路由(按月分表)
/// 参考地址 https://www.cnblogs.com/xuejiaming/p/15728340.html
/// </summary>
public class OrderTimeShardingRule : AbstractSimpleShardingMonthKeyDateTimeVirtualTableRoute<Order>
{
    /// <summary>
    /// 配置分表的一些信息
    /// 1.ShardingProperty 哪个字段分表
    /// 2.TableSeparator 分表的后缀和表名的连接符
    /// 3.AutoCreateTable 启动时是否需要创建对应的分表信息
    /// 3.ShardingExtraProperty 额外分片字段
    /// </summary>
    /// <param name="builder"></param>
    public override void Configure(EntityMetadataTableBuilder<Order> builder)
    {
        // 指定分片字段
        builder.ShardingProperty(o => o.CreationTime);

        // 设置分表名后缀连接符，默认是下划线 "_"
        builder.TableSeparator("_");

        // 是否自动创建分表，默认是 true
        builder.AutoCreateTable(true);

        builder.ShardingExtraProperty(o => o.Id);
    }

    /// <summary>是否需要自动创建按时间分表的路由</summary>
    /// <returns></returns>
    public override bool AutoCreateTableByTime()
    {
        return true;
    }

    public override DateTime GetBeginTime()
    {
        return new DateTime(2025, 2, 01);
    }

    /// <summary>
    /// 配置额外分片路由规则
    /// </summary>
    /// <param name="shardingKey">shardingKey</param>
    /// <param name="shardingOperator">shardingOperator</param>
    /// <param name="shardingPropertyName">shardingPropertyName</param>
    /// <returns>表达式</returns>
    public override Func<string, bool> GetExtraRouteFilter(object shardingKey, ShardingOperatorEnum shardingOperator, string shardingPropertyName)
    {
        return shardingPropertyName switch
        {
            nameof(Order.Id) => GetOrderNoRouteFilter(shardingKey, shardingOperator),
            _ => throw new NotImplementedException(shardingPropertyName)
        };
    }
    /// <summary>
    /// 订单编号的路由
    /// </summary>
    /// <param name="shardingKey">shardingKey</param>
    /// <param name="shardingOperator">shardingOperator</param>
    /// <returns>表达式</returns>
    private Func<string, bool> GetOrderNoRouteFilter(object shardingKey,
        ShardingOperatorEnum shardingOperator)
    {
        //将分表字段转成订单编号
        var orderNo = shardingKey.ToString() ?? string.Empty;
        //判断订单编号是否是我们符合的格式
        if (!CheckOrderNo(orderNo, out var orderTime))
        {
            //如果格式不一样就直接返回false那么本次查询因为是and链接的所以本次查询不会经过任何路由,可以有效的防止恶意攻击
            return tail => false;
        }

        //当前时间的tail
        var currentTail = TimeFormatToTail(orderTime);
        //因为是按月分表所以获取下个月的时间判断id是否是在临界点创建的
        //var nextMonthFirstDay = ShardingCoreHelper.GetNextMonthFirstDay(DateTime.Now);//这个是错误的
        var nextMonthFirstDay = ShardingCoreHelper.GetNextMonthFirstDay(orderTime);
        if (orderTime.AddSeconds(10) > nextMonthFirstDay)
        {
            var nextTail = TimeFormatToTail(nextMonthFirstDay);
            return DoOrderNoFilter(shardingOperator, orderTime, currentTail, nextTail);
        }
        //因为是按月分表所以获取这个月月初的时间判断id是否是在临界点创建的
        //if (orderTime.AddSeconds(-10) < ShardingCoreHelper.GetCurrentMonthFirstDay(DateTime.Now))//这个是错误的
        if (orderTime.AddSeconds(-10) >= ShardingCoreHelper.GetCurrentMonthFirstDay(orderTime))
        {
            return DoOrderNoFilter(shardingOperator, orderTime, currentTail, currentTail);
        }

        //上个月tail
        var previewTail = TimeFormatToTail(orderTime.AddSeconds(-10));

        return DoOrderNoFilter(shardingOperator, orderTime, previewTail, currentTail);

    }

    private static Func<string, bool> DoOrderNoFilter(ShardingOperatorEnum shardingOperator, DateTime shardingKey, string minTail, string maxTail)
    {
        switch (shardingOperator)
        {
            case ShardingOperatorEnum.GreaterThan:
            case ShardingOperatorEnum.GreaterThanOrEqual:
                {
                    return tail => string.Compare(tail, minTail, StringComparison.Ordinal) >= 0;
                }

            case ShardingOperatorEnum.LessThan:
                {
                    var currentMonth = ShardingCoreHelper.GetCurrentMonthFirstDay(shardingKey);
                    //处于临界值 o=>o.time < [2021-01-01 00:00:00] 尾巴20210101不应该被返回
                    if (currentMonth == shardingKey)
                    {
                        return tail => string.Compare(tail, maxTail, StringComparison.Ordinal) < 0;
                    }

                    return tail => string.Compare(tail, maxTail, StringComparison.Ordinal) <= 0;
                }
            case ShardingOperatorEnum.LessThanOrEqual:
                return tail => string.Compare(tail, maxTail, StringComparison.Ordinal) <= 0;
            case ShardingOperatorEnum.Equal:
                {
                    var isSame = minTail == maxTail;
                    if (isSame)
                    {
                        return tail => tail == minTail;
                    }
                    return tail => tail == minTail || tail == maxTail;
                }
            case ShardingOperatorEnum.UnKnown:
            case ShardingOperatorEnum.NotEqual:
            case ShardingOperatorEnum.AllLike:
            case ShardingOperatorEnum.StartLike:
            case ShardingOperatorEnum.EndLike:
            default:
                {
                    return _ => true;
                }
        }
    }

    private static bool CheckOrderNo(string orderNo, out DateTime orderTime)
    {
        // ID 字段提取前 6 位
        var id = orderNo[..Math.Min(8, orderNo.Length)];
        if (DateTime.TryParseExact(id, "yyyyMMdd", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out var parseDateTime))
        {
            orderTime = parseDateTime;
            return true;
        }

        orderTime = DateTime.MinValue;
        return false;
    }
}