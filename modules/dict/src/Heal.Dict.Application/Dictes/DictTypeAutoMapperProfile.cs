using Heal.Dict.Application.Contracts.Dictes.Dtos;
using Heal.Dict.Domain.Dictes.Entities;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace Heal.Dict.Application.Dictes;

/// <summary>
/// 数据字典类型自动映射配置
/// </summary>
[Mapper]
public partial class DictTypeAutoMapperProfile : MapperBase<DictType, DictTypeDto>
{
    /// <summary>
    /// 映射
    /// </summary>
    /// <param name="source">source</param>
    /// <returns>DictTypeDto</returns>
    public override partial DictTypeDto Map(DictType source);

    /// <summary>
    /// 映射
    /// </summary>
    /// <param name="source">DictType</param>
    /// <param name="destination">DictTypeDto</param>
    public override partial void Map(DictType source, DictTypeDto destination);
}