namespace Heal.Domain.Managers;

/// <summary>
/// 序列管理器
/// </summary>
public interface ISequenceManager : IHealDomainManager
{
    /// <summary>
    /// 获取下一个序列
    /// </summary>
    /// <param name="name">名称</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>序列</returns>
    public Task<long> GetNextSequenceAsync(string name, CancellationToken cancellationToken = default);

    /// <summary>
    /// 将数字转换为字符串，并补零到指定长度。
    /// </summary>
    /// <param name="name">名称</param>
    /// <param name="length">目标字符串的最小长度</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>补零后的字符串</returns>
    public async Task<string> PadNumberWithZerosAsync(string name, int length = 6, CancellationToken cancellationToken = default)
    {
        var number = await GetNextSequenceAsync(name, cancellationToken);
        return PadNumberWithZeros(number, length);
    }

    /// <summary>
    /// 将数字转换为字符串，并补零到指定长度。
    /// </summary>
    /// <param name="number">输入的数字</param>
    /// <param name="length">目标字符串的最小长度</param>
    /// <returns>补零后的字符串</returns>
    public string PadNumberWithZeros(long number, int length = 6)
    {
        if (length <= 0)
        {
            throw new ArgumentException("目标长度必须大于0", nameof(length));
        }

        return number.ToString($"D{length}");
    }
}