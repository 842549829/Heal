using Heal.Net.Application.Contracts.Bases.Roles.Dtos;
using Heal.Net.Domain.Bases.Permissions.Modules;
using Riok.Mapperly.Abstractions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Mapperly;
using Volo.Abp.PermissionManagement;

namespace Heal.Net.Application.Bases.Roles;

/// <summary>
/// 角色自动映射配置
/// </summary>
[Mapper]
public partial class RoleAutoMapperProfile : IAbpMapperlyMapper<UpdatePermissionDto, UpdatePermission>, IAbpMapperlyMapper<IdentityRole, RoleDto>, ITransientDependency
{
    public UpdatePermission Map(UpdatePermissionDto source)
    {
        throw new NotImplementedException();
    }

    public void Map(UpdatePermissionDto source, UpdatePermission destination)
    {
        throw new NotImplementedException();
    }

    public void BeforeMap(UpdatePermissionDto source)
    {
        throw new NotImplementedException();
    }

    public void AfterMap(UpdatePermissionDto source, UpdatePermission destination)
    {
        throw new NotImplementedException();
    }

    public RoleDto Map(IdentityRole source)
    {
        throw new NotImplementedException();
    }

    public void Map(IdentityRole source, RoleDto destination)
    {
        throw new NotImplementedException();
    }

    public void BeforeMap(IdentityRole source)
    {
        throw new NotImplementedException();
    }

    public void AfterMap(IdentityRole source, RoleDto destination)
    {
        throw new NotImplementedException();
    }
}