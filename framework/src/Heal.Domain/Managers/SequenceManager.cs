using Heal.Domain.Repositories;

namespace Heal.Domain.Managers;

/// <summary>
/// 序列管理
/// </summary>
public class SequenceManager(ISequencesRepository sequencesRepository) : HealDomainManager, ISequenceManager
{
    /// <summary>
    /// 获取下一个序列
    /// </summary>
    /// <param name="name">名称</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>序列</returns>
    public Task<long> GetNextSequenceAsync(string name, CancellationToken cancellationToken = default)
    {
        return sequencesRepository.GetNextSequenceAsync(name, cancellationToken);
    }
}