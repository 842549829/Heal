using Heal.Domain.Shared.Enums;
using Heal.Net.Application.Contracts.Bases.Permissions;
using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Heal.Net.Domain.Bases.Permissions.Managers;
using Heal.Net.Domain.Bases.Permissions.Modules;

namespace Heal.Net.Application.Bases.Permissions;

/// <summary>
/// 权限服务
/// </summary>
/// <param name="netRolePermissionManager">角色权限领域接口</param>
public class NetRolePermissionAppService(INetRolePermissionManager netRolePermissionManager)
    : HealNetAppService, INetRolePermissionAppService
{
    /// <summary>
    /// 获取模块列表
    /// </summary>
    /// <returns>返回模块列表</returns>
    public async Task<List<ModuleHomeListDto>> GetModuleListAsync()
    {
        var permissions = await netRolePermissionManager.GetModuleListAsync(CurrentUser.Id.GetValueOrDefault());
        return MapToDtoList(permissions);
    }

    /// <summary>
    /// 获取权限树列表
    /// </summary>
    /// <param name="moduleName">模块名称</param>
    /// <returns>返回权限树列表</returns>
    public async Task<List<RouteConfigDto>> GetPermissionTreeListAsync(string moduleName)
    {
        var permissions =
            await netRolePermissionManager.GetPermissionTreeListAsync(CurrentUser.Id.GetValueOrDefault(), moduleName);
        return MapToDtoList(permissions);
    }

    /// <summary>
    /// 获取所有权限菜单列表
    /// </summary>
    /// <returns>所有权限菜单列表</returns>
    public async Task<List<RolePermissionTreeDto>> GetAllRolePermissionTreeListAsync()
    {
        var userId = CurrentUser.Id.GetValueOrDefault();
        var permissions = await netRolePermissionManager.GetAllPermissionTreeListAsync(userId);
        return MapToMapToRolePermissionTreeDtoList(permissions);
    }

    /// <summary>
    /// 将树结构转换为 DTO 树结构。
    /// </summary>
    /// <param name="treeNode">原始树节点。</param>
    /// <returns>DTO 树节点。</returns>
    private static RolePermissionTreeDto MapToRolePermissionTreeDto(PermissionTree treeNode)
    {
        // 创建 DTO 节点
        var dtoNode = new RolePermissionTreeDto
        {
            PermissionName = treeNode.PermissionName,
            Tag = treeNode.Tag,
            ParentName = treeNode.ParentName,
            Type = treeNode.Type,
            Name = treeNode.Name,
            Component = treeNode.Component,
            Redirect = treeNode.Redirect,
            Alias = treeNode.Alias,
            Path = treeNode.Path,
            Meta = new MetaDto
            {
                ActiveMenu = treeNode.ActiveMenu,
                Hidden = treeNode.Hidden,
                AlwaysShow = treeNode.AlwaysShow,
                Breadcrumb = treeNode.Breadcrumb,
                Affix = treeNode.Affix,
                NoCache = treeNode.NoCache,
                Title = treeNode.Title,
                Icon = treeNode.Icon,
                NoTagsView = treeNode.NoTagsView,
                CanTo = treeNode.CanTo
            }
        };

        // 递归处理子节点
        if (treeNode.ChildPermissions == null)
        {
            return dtoNode;
        }

        // 处理按钮权限
        if (treeNode.Type == PermissionType.Menu)
        {
            dtoNode.Meta.Permission = []; // 初始化 Permission 列表

            foreach (var child in treeNode.ChildPermissions)
            {
                if (child.Type == PermissionType.Button)
                {
                    // 收集 Type=2 的节点名称，并跳过递归
                    dtoNode.Meta.Permission.Add(child.PermissionName);
                }
                else
                {
                    // 对其他类型的节点进行递归
                    var childDto = MapToRolePermissionTreeDto(child);
                    dtoNode.Children ??= [];
                    dtoNode.Children.Add(childDto);
                }
            }
        }
        else
        {
            foreach (var childDto in treeNode.ChildPermissions.Select(MapToRolePermissionTreeDto))
            {
                dtoNode.Children ??= [];
                dtoNode.Children.Add(childDto);
            }
        }

        return dtoNode;
    }

    /// <summary>
    /// 将整个树结构列表转换为 DTO 树结构列表。
    /// </summary>
    /// <param name="treeNodes">原始树节点列表。</param>
    /// <returns>DTO 树节点列表。</returns>
    private static List<RolePermissionTreeDto> MapToMapToRolePermissionTreeDtoList(List<PermissionTree> treeNodes)
    {
        return !treeNodes.Any() ? [] : treeNodes.Select(MapToRolePermissionTreeDto).ToList();
    }

    /// <summary>
    /// 将树结构转换为 DTO 树结构。
    /// </summary>
    /// <param name="treeNode">原始树节点。</param>
    /// <returns>DTO 树节点。</returns>
    private static RouteConfigDto MapToDto(PermissionTree treeNode)
    {
        // 创建 DTO 节点
        var dtoNode = new RouteConfigDto
        {
            Name = treeNode.Name,
            Component = treeNode.Component,
            Redirect = treeNode.Redirect,
            Alias = treeNode.Alias,
            Path = treeNode.Path,
            Meta = new MetaDto
            {
                ActiveMenu = treeNode.ActiveMenu,
                Hidden = treeNode.Hidden,
                AlwaysShow = treeNode.AlwaysShow,
                Breadcrumb = treeNode.Breadcrumb,
                Affix = treeNode.Affix,
                NoCache = treeNode.NoCache,
                Title = treeNode.Title,
                Icon = treeNode.Icon,
                NoTagsView = treeNode.NoTagsView,
                CanTo = treeNode.CanTo
            }
        };

        // 递归处理子节点
        if (treeNode.ChildPermissions == null)
        {
            return dtoNode;
        }

        // 处理按钮权限
        if (treeNode.Type == PermissionType.Menu)
        {
            dtoNode.Meta.Permission = new List<string>(); // 初始化 Permission 列表

            foreach (var child in treeNode.ChildPermissions)
            {
                if (child.Type == PermissionType.Button)
                {
                    // 收集 Type=2 的节点名称，并跳过递归
                    dtoNode.Meta.Permission.Add(child.PermissionName);
                }
                else
                {
                    // 对其他类型的节点进行递归
                    var childDto = MapToDto(child);
                    dtoNode.Children ??= [];
                    dtoNode.Children.Add(childDto);
                }
            }
        }
        else
        {
            foreach (var childDto in treeNode.ChildPermissions.Select(MapToDto))
            {
                dtoNode.Children ??= [];
                dtoNode.Children.Add(childDto);
            }
        }

        return dtoNode;
    }

    /// <summary>
    /// 将整个树结构列表转换为 DTO 树结构列表。
    /// </summary>
    /// <param name="treeNodes">原始树节点列表。</param>
    /// <returns>DTO 树节点列表。</returns>
    private static List<RouteConfigDto> MapToDtoList(List<PermissionTree> treeNodes)
    {
        return !treeNodes.Any() ? [] : treeNodes.Select(MapToDto).ToList();
    }

    /// <summary>
    /// 转换
    /// </summary>
    /// <param name="permissions">权限</param>
    /// <returns>模块</returns>
    private static List<ModuleHomeListDto> MapToDtoList(List<Permission> permissions)
    {
        return permissions.Where(a => a.Hidden == false).Select(d => new ModuleHomeListDto
        {
            ModuleName = d.PermissionName,
            Name = d.Name,
            Component = d.Component,
            Path = d.Path,
            Title = d.Title,
            Icon = d.Icon,
            Alias = d.Alias,
            Redirect = d.Redirect,
        }).ToList();
    }
}