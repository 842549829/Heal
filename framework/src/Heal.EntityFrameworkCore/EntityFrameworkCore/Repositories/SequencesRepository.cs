using Heal.Domain.Entities;
using Heal.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity.EntityFrameworkCore;

namespace Heal.EntityFrameworkCore.EntityFrameworkCore.Repositories;

/// <summary>
/// Sequences仓储
/// </summary>
public class SequencesRepository(IDbContextProvider<IIdentityDbContext> dbContextProvider)
    : EfCoreRepository<IIdentityDbContext, Sequences, string>(dbContextProvider), ISequencesRepository
{
    /// <summary>
    /// 获取下一个序列
    /// </summary>
    /// <param name="name">名称</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>序列</returns>
    public async Task<long> GetNextSequenceAsync(string name, CancellationToken cancellationToken = default)
    {
        // 确保传入的序列名称不为空
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("序列名称不能为空", nameof(name));
        }
        // 获取 DbContext
        var dbContext = await GetDbContextAsync();

        // 定义 SQL 查询
        var sqlQuery = $"SELECT GET_NEXT_VAL('{name}') AS `Value` FROM DUAL";

        // 使用 FromSqlRaw 执行查询并获取结果
        var result = await dbContext.Database
            .SqlQueryRaw<long>(sqlQuery)
            .FirstOrDefaultAsync(cancellationToken);

        return result;
    }
}