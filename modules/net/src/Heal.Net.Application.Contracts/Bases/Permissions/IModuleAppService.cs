using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;

namespace Heal.Net.Application.Contracts.Bases.Permissions;

/// <summary>
/// 模块应用服务
/// </summary>
public interface IModuleAppService : IHealNetApplicationService
{
    /// <summary>
    /// 创建模块
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <returns>Task</returns>
    Task CeateAsync(ModuleCreateDto input);

    /// <summary>
    /// 更新模块
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <returns>Task</returns>
    Task UpdateAsync(Guid id, ModuleUpdateDto input);
}