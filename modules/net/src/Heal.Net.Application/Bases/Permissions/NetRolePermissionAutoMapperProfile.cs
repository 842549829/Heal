using Heal.Net.Application.Contracts.Bases.Permissions.Dtos;
using Riok.Mapperly.Abstractions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Mapperly;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Application.Bases.Permissions;

/// <summary>
/// AutoMapper配置
/// </summary>
[Mapper]
public partial class NetRolePermissionAutoMapperProfile : IAbpMapperlyMapper<PermissionGroupDefinitionRecord, PermissionGroupDefinitionDto>, IAbpMapperlyMapper<PermissionDefinitionRecord, PermissionDefinitionDto>, ITransientDependency
{
    public PermissionGroupDefinitionDto Map(PermissionGroupDefinitionRecord source)
    {
        throw new NotImplementedException();
    }

    public void Map(PermissionGroupDefinitionRecord source, PermissionGroupDefinitionDto destination)
    {
        throw new NotImplementedException();
    }

    public void BeforeMap(PermissionGroupDefinitionRecord source)
    {
        throw new NotImplementedException();
    }

    public void AfterMap(PermissionGroupDefinitionRecord source, PermissionGroupDefinitionDto destination)
    {
        throw new NotImplementedException();
    }

    public PermissionDefinitionDto Map(PermissionDefinitionRecord source)
    {
        throw new NotImplementedException();
    }

    public void Map(PermissionDefinitionRecord source, PermissionDefinitionDto destination)
    {
        throw new NotImplementedException();
    }

    public void BeforeMap(PermissionDefinitionRecord source)
    {
        throw new NotImplementedException();
    }

    public void AfterMap(PermissionDefinitionRecord source, PermissionDefinitionDto destination)
    {
        throw new NotImplementedException();
    }
}