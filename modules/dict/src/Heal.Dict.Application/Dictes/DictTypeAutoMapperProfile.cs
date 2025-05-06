using AutoMapper;
using Heal.Dict.Application.Contracts.Dictes.Dtos;
using Heal.Dict.Domain.Dictes.Entities;

namespace Heal.Dict.Application.Dictes;

/// <summary>
/// 数据字典类型自动映射配置
/// </summary>
public class DictTypeAutoMapperProfile : Profile
{
    /// <summary>
    /// 构造函数
    /// </summary>
    public DictTypeAutoMapperProfile()
    {
        CreateMap<DictType, DictTypeDto>()
            .MapExtraProperties();
    }
}