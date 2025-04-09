namespace Heal.Net.Application.Contracts;

/// <summary>
/// 测试接口
/// </summary>
public interface ITestAppService : IHealNetApplicationService
{
    /// <summary>
    /// 获取下一个序列
    /// </summary>
    /// <param name="name">名称</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>序列</returns>
    Task<long> GetNextSequenceAsync(string name, CancellationToken cancellationToken = default);
}