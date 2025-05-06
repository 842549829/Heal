using AutoMapper;
using Heal.Dict.Application.Contracts.Dictes.Dtos;
using Heal.Dict.Domain.Dictes.Entities;

namespace Heal.Dict.Application.Dictes;

/// <summary>
/// DictItem映射
/// </summary>
public class DictItemAutoMapperProfile : Profile
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public DictItemAutoMapperProfile()
    {
        CreateMap<DictItem, DictItemDto>()
            .MapExtraProperties();
    }
}