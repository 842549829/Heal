using AutoMapper;
using Heal.Net.Application.Contracts.Bases.Campuses.Dto;
using Heal.Net.Domain.Bases.Campuses.Entities;

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
    }
}