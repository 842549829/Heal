using AutoMapper;
using Heal.Net.Application.Contracts.Bases.Roles.Dtos;
using Heal.Net.Domain.Bases.Permissions.Modules;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Application.Bases.Roles;

/// <summary>
/// 角色自动映射配置
/// </summary>
public class RoleAutoMapperProfile : Profile
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public RoleAutoMapperProfile()
    {
        CreateMap<UpdatePermissionDto, UpdatePermission>();

        CreateMap<IdentityRole, RoleDto>();
    }
}