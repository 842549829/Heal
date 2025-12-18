using Heal.Net.Application.Contracts.Bases.Organizations.Dtos;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Mapperly;

namespace Heal.Net.Application.Bases.Organizations;

/// <summary>
/// 组织机构自动映射配置
/// </summary>
public partial class OrganizationAutoMapperProfile : IAbpMapperlyMapper<OrganizationUnit, OrganizationDto>,
    IAbpMapperlyMapper<OrganizationUnit, OrganizationTreeDto>,
    IAbpMapperlyMapper<OrganizationUnit, OrganizationSelectDto>,
    ITransientDependency
{
    OrganizationDto IAbpMapperlyMapper<OrganizationUnit, OrganizationDto>.Map(OrganizationUnit source)
    {
        var organizationDto = new OrganizationDto
        {
            Code = source.Code,
            ConcurrencyStamp = source.ConcurrencyStamp,
            DisplayName = source.DisplayName,
            Id = source.Id,
            ParentId = source.ParentId,
            TenantId = source.TenantId,
            CreationTime = source.CreationTime,
            LastModificationTime = source.LastModificationTime,
            LastModifierId = source.LastModifierId,
            CreatorId = source.CreatorId,
            DeleterId = source.DeleterId,
            IsDeleted = source.IsDeleted,
            DeletionTime = source.DeletionTime,
        };

        foreach (var property in source.ExtraProperties)
        {
            organizationDto.ExtraProperties[property.Key] = property.Value;
        }

        return organizationDto;
    }

    public void Map(OrganizationUnit source, OrganizationSelectDto destination)
    {
        destination.Code = source.Code;
        destination.DisplayName = source.DisplayName;
        destination.ParentId = source.ParentId;
        destination.Id = source.Id;
    }

    void IAbpMapperlyMapper<OrganizationUnit, OrganizationSelectDto>.BeforeMap(OrganizationUnit source)
    {
    }

    public void AfterMap(OrganizationUnit source, OrganizationSelectDto destination)
    {
    }

    public void Map(OrganizationUnit source, OrganizationTreeDto destination)
    {
        destination.Code = source.Code;
        destination.DisplayName = source.DisplayName;
        destination.Id = source.Id;
        destination.ParentId = source.ParentId;
        destination.TenantId = source.TenantId;
        destination.ConcurrencyStamp = source.ConcurrencyStamp;
        destination.CreationTime = source.CreationTime;
        destination.LastModificationTime = source.LastModificationTime;
        destination.LastModifierId = source.LastModifierId;
        destination.CreatorId = source.CreatorId;
        destination.DeleterId = source.DeleterId;
        destination.IsDeleted = source.IsDeleted;
        destination.DeletionTime = source.DeletionTime;
        foreach (var property in source.ExtraProperties)
        {
            destination.ExtraProperties[property.Key] = property.Value;
        }
    }

    OrganizationSelectDto IAbpMapperlyMapper<OrganizationUnit, OrganizationSelectDto>.Map(OrganizationUnit source)
    {
        var organizationSelectDto = new OrganizationSelectDto
        {
            Code = source.Code,
            DisplayName = source.DisplayName,
            Id = source.Id,
            ParentId = source.ParentId
        };
        return organizationSelectDto;
    }

    void IAbpMapperlyMapper<OrganizationUnit, OrganizationTreeDto>.BeforeMap(OrganizationUnit source)
    {
    }

    public void AfterMap(OrganizationUnit source, OrganizationTreeDto destination)
    {
    }

    public void Map(OrganizationUnit source, OrganizationDto destination)
    {
        destination.Code = source.Code;
        destination.DisplayName = source.DisplayName;
        destination.Id = source.Id;
        destination.ParentId = source.ParentId;
        destination.TenantId = source.TenantId;
        destination.ConcurrencyStamp = source.ConcurrencyStamp;
        destination.CreationTime = source.CreationTime;
        destination.LastModificationTime = source.LastModificationTime;
        destination.LastModifierId = source.LastModifierId;
        destination.CreatorId = source.CreatorId;
        destination.DeleterId = source.DeleterId;
        destination.IsDeleted = source.IsDeleted;
        destination.DeletionTime = source.DeletionTime;
        foreach (var property in source.ExtraProperties)
        {
            destination.ExtraProperties[property.Key] = property.Value;
        }
    }

    OrganizationTreeDto IAbpMapperlyMapper<OrganizationUnit, OrganizationTreeDto>.Map(OrganizationUnit source)
    {
        var organizationTreeDto = new OrganizationTreeDto
        {
            Code = source.Code,
            DisplayName = source.DisplayName,
            Id = source.Id,
            ParentId = source.ParentId,
            TenantId = source.TenantId,
            ConcurrencyStamp = source.ConcurrencyStamp
        };

        return organizationTreeDto;
    }

    void IAbpMapperlyMapper<OrganizationUnit, OrganizationDto>.BeforeMap(OrganizationUnit source)
    {
    }

    public void AfterMap(OrganizationUnit source, OrganizationDto destination)
    {
    }
}