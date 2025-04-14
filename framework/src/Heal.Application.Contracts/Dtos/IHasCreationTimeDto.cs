namespace Heal.Application.Contracts.Dtos
{
    /// <summary>
    /// 创建时间
    /// </summary>
    public interface IHasCreationTimeDto
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime CreationTime { get; }
    }
}
