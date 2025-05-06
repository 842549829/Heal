using Heal.Domain.Managers;
using Heal.Net.Application.Contracts;

namespace Heal.Net.Application;

/// <summary>
/// 测试应用服务
/// </summary>
public class TestAppService(ISequenceManager sequenceManager) :HealNetAppService, ITestAppService
{
    /// <summary>
    /// 获取下一个序列
    /// </summary>
    /// <param name="name">名称</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>序列</returns>
    public Task<long> GetNextSequenceAsync(string name, CancellationToken cancellationToken = default)
    {
        return sequenceManager.GetNextSequenceAsync(name, cancellationToken);
    }

    /// <summary>
    /// 生成 GUID
    /// </summary>
    /// <returns>Guid</returns>
    public Guid Guid()
    {
        return GuidGenerator.Create();
    }
}
