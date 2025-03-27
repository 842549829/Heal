using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sharding.Core.Test.Entities;
using Sharding.Core.Test.EntityFrameworkCore;

namespace Sharding.Core.Test.Controllers;

[Route("api/[controller]")]
public class ValuesController(ShardingDbContext myDbContext) : ControllerBase
{
    [HttpGet]
    public async Task<Order?> Get()
    {
        var order = await myDbContext.Set<Order>().FirstOrDefaultAsync(o => o.Id == "20250327001214555");
        return order;
    }

    // 添加订单
    [HttpGet("add")]
    public async Task<IActionResult> Post()
    {
        var order1 = new Order
        {
            Id = "20250327001214555",
            Payer = "张三",
            Money = 100,
            Area = "北京",
            OrderStatus = OrderStatusEnum.NoPay,
            CreationTime = DateTime.Now
        };
        var order2 = new Order
        {
            Id = "20250227001214555",
            Payer = "六码",
            Money = 100,
            Area = "河南",
            OrderStatus = OrderStatusEnum.NoPay,
            CreationTime = new DateTime(2025, 2, 15)
        };
        var order3 = new Order
        {
            Id = "20250227001214001",
            Payer = "京东",
            Money = 100,
            Area = "成都",
            OrderStatus = OrderStatusEnum.NoPay,
            CreationTime = new DateTime(2025, 2, 8)
        };
        await myDbContext.Set<Order>().AddRangeAsync(order1, order2, order3);
        await myDbContext.SaveChangesAsync();
        return Ok();
    }

}
