using AutoMapper;
using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Heal.Net.Domain.Bases.Permissions.Modules;
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
        CreateMap<PermissionTree, PermissionTreeDto>();

        CreateMap<PermissionGroupDefinitionRecord, PermissionGroupDefinitionDto>();

        CreateMap<PermissionDefinitionRecord, PermissionDefinitionDto>();
    }
}