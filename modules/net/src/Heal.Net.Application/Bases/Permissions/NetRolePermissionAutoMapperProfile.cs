using AutoMapper;
using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Application.Bases.Permissions;

/// <summary>
/// AutoMapper配置
/// </summary>
public class NetRolePermissionAutoMapperProfile : Profile
{
    /// <summary>
    /// AutoMapper配置
    /// </summary>
    public NetRolePermissionAutoMapperProfile()
    {
        CreateMap<PermissionGroupDefinitionRecord, PermissionGroupDefinitionDto>();

        CreateMap<PermissionDefinitionRecord, PermissionDefinitionDto>();
    }
}