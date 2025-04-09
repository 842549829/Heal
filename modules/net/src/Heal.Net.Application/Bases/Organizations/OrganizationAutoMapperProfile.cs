using AutoMapper;
using Heal.Net.Application.Contracts.Bases.Organizations.Dtos;
using Volo.Abp.Identity;

namespace Heal.Net.Application.Bases.Organizations;

/// <summary>
/// 组织机构自动映射配置
/// </summary>
public class OrganizationAutoMapperProfile : Profile
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public OrganizationAutoMapperProfile()
    {
        CreateMap<OrganizationUnit, OrganizationDto>();
        CreateMap<OrganizationUnit, OrganizationTreeDto>();
        CreateMap<OrganizationUnit, OrganizationSelectDto>();
    }
}