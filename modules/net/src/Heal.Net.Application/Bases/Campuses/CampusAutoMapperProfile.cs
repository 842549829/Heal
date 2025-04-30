using AutoMapper;
using Heal.Core.Domain.Bases.Campuses.Entities;
using Heal.Net.Application.Contracts.Bases.Campuses.Dto;

namespace Heal.Net.Application.Bases.Campuses;

/// <summary>
/// AutoMapper配置
/// </summary>
public class CampusAutoMapperProfile : Profile
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public CampusAutoMapperProfile()
    {
        CreateMap<Campus, CampusDto>();
        CreateMap<Campus, CampusListDto>();
    }
}