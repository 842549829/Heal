﻿using Heal.Net.Application.Contracts.Bases.Roles;
using Heal.Net.Application.Contracts.Bases.Roles.Dtos;
using Heal.Net.Domain.Bases.Permissions.Managers;
using Heal.Net.Domain.Bases.Permissions.Modules;
using Microsoft.AspNetCore.Identity;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Data;
using Volo.Abp.Identity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Application.Bases.Roles;

/// <summary>
/// 角色服务
/// </summary>
/// <param name="roleManager">角色管理</param>
/// <param name="roleRepository">角色仓储</param>
/// <param name="netPermissionManager">角色权限管理</param>
public class RoleAppService(
    IdentityRoleManager roleManager,
    IIdentityRoleRepository roleRepository,
    INetRolePermissionManager netPermissionManager)
    : HealNetAppService, IRoleAppService
{
    /// <summary>
    /// 创建角色
    /// </summary>
    /// <param name="input">角色创建</param>
    /// <returns>角色</returns>
    public async Task<IdentityRoleDto> CreateAsync(RoleCreateDto input)
    {
        var role = new IdentityRole(
            GuidGenerator.Create(),
            input.Name,
            CurrentTenant.Id
        )
        {
            IsDefault = input.IsDefault,
            IsPublic = input.IsPublic
        };

        input.MapExtraPropertiesTo(role);

        (await roleManager.CreateAsync(role)).CheckErrors();

        await SetPermissionAsync(role, input.Permissions);

        await CurrentUnitOfWork?.SaveChangesAsync()!;

        return ObjectMapper.Map<IdentityRole, IdentityRoleDto>(role);
    }

    /// <summary>
    /// 更新角色
    /// </summary>
    /// <param name="id">角色Id</param>
    /// <param name="input">角色更新</param>
    /// <returns>角色</returns>
    public async Task<IdentityRoleDto> UpdateAsync(Guid id, RoleUpdateDto input)
    {
        var role = await roleManager.GetByIdAsync(id);

        role.SetConcurrencyStampIfNotNull(input.ConcurrencyStamp);

        (await roleManager.SetRoleNameAsync(role, input.Name)).CheckErrors();

        role.IsDefault = input.IsDefault;
        role.IsPublic = input.IsPublic;

        input.MapExtraPropertiesTo(role);

        (await roleManager.UpdateAsync(role)).CheckErrors();

        await SetPermissionAsync(role, input.Permissions);

        await CurrentUnitOfWork?.SaveChangesAsync()!;

        return ObjectMapper.Map<IdentityRole, IdentityRoleDto>(role);
    }

    /// <summary>
    /// 删除角色
    /// </summary>
    /// <param name="id">角色Id</param>
    /// <returns>Task</returns>
    public async Task DeleteAsync(Guid id)
    {
        var role = await roleManager.FindByIdAsync(id.ToString());
        if (role == null)
        {
            return;
        }

        (await roleManager.DeleteAsync(role)).CheckErrors();
    }

    /// <summary>
    /// 获取角色列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <returns>角色列表</returns>
    public async Task<PagedResultDto<IdentityRoleDto>> GetListAsync(GetIdentityRolesInput input)
    {
        var list = await roleRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount,
            input.Filter);
        var totalCount = await roleRepository.GetCountAsync(input.Filter);

        return new PagedResultDto<IdentityRoleDto>(
            totalCount,
            ObjectMapper.Map<List<IdentityRole>, List<IdentityRoleDto>>(list)
        );
    }

    /// <summary>
    /// 获取角色
    /// </summary>
    /// <param name="id">id</param>
    /// <returns>角色</returns>
    public async Task<RoleDto> GetAsync(Guid id)
    {
        var identityRole = await roleManager.GetByIdAsync(id);
        var dto = ObjectMapper.Map<IdentityRole, RoleDto>(identityRole);
        var permissionGrants =
            await netPermissionManager.GetPermissionGrantListAsync(RolePermissionValueProvider.ProviderName, dto.Name);
        permissionGrants.ForEach(x =>
        {
            dto.Permissions.Add(new UpdatePermissionDto
            {
                Name = x.Name,
                IsGranted = true
            });
        });
        return dto;
    }

    /// <summary>
    /// 设置角色权限
    /// </summary>
    /// <param name="role">角色</param>
    /// <param name="permissions">权限</param>
    /// <returns>Task</returns>
    private async Task SetPermissionAsync(IdentityRole role, List<UpdatePermissionDto> permissions)
    {
        var updatePermissions = ObjectMapper.Map<List<UpdatePermissionDto>, List<UpdatePermission>>(permissions);
        await netPermissionManager.SetPermissionAsync(role, updatePermissions);
    }

    /// <summary>
    /// 获取角色权限
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>权限</returns>
    public async Task<List<string>> GetPermissionListAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var identityRole = await roleManager.GetByIdAsync(id);
        var permissionGrants =
            await netPermissionManager.GetPermissionGrantListAsync(RolePermissionValueProvider.ProviderName,
                identityRole.Name, cancellationToken);
        return permissionGrants.Select(x => x.Name).ToList();
    }

    /// <summary>
    /// 获取所有角色
    /// </summary>
    /// <returns>所有角色</returns>
    public async Task<List<string>> GetAllAsync()
    {
        var roles = await roleRepository.GetListAsync();
        return roles.Select(a => a.Name).ToList();
    }
}