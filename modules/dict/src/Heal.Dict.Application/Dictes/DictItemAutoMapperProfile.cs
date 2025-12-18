using Heal.Dict.Application.Contracts.Dictes.Dtos;
using Heal.Dict.Domain.Dictes.Entities;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace Heal.Dict.Application.Dictes;

/// <summary>
/// DictItem映射
/// </summary>
[Mapper]
public partial class DictItemAutoMapperProfile : MapperBase<DictItem, DictItemDto>
{
    /// <summary>
    /// Maps the specified source <see cref="DictItem"/> to a new <see cref="DictItemDto"/> instance.
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    public override DictItemDto Map(DictItem source)
    {
        var dictItemDto = new DictItemDto
        {
            Code = source.Code,
            ConcurrencyStamp = source.ConcurrencyStamp,
            DictTypeId = source.DictTypeId,
            Id = source.Id,
            Name = source.Name,
            ParentId = source.ParentId,
            Style = source.Style,
            Sort = source.Sort,
            TenantId = source.TenantId,
            Alias = source.Alias,
            Describe = source.Describe,
            Status = source.Status
        };
        foreach (var sourceExtraProperty in source.ExtraProperties)
        {
            dictItemDto.ExtraProperties.Add(sourceExtraProperty.Key, sourceExtraProperty.Value);
        }
        return dictItemDto;
    }

    /// <summary>
    /// Maps the values from the specified source <see cref="DictItem"/> to the destination <see cref="DictItemDto"/>
    /// object.
    /// </summary>
    /// <param name="source">The source <see cref="DictItem"/> instance containing the data to map from. Cannot be null.</param>
    /// <param name="destination">The destination <see cref="DictItemDto"/> instance to which the data will be mapped. Cannot be null.</param>
    public override void Map(DictItem source, DictItemDto destination)
    {
        // 参数校验（良好实践）
        if (source == null)
        {
            throw new ArgumentNullException(nameof(source));
        }

        if (destination == null)
        {
            throw new ArgumentNullException(nameof(destination));
        }

        // 映射基本属性
        destination.Code = source.Code;
        destination.ConcurrencyStamp = source.ConcurrencyStamp;
        destination.DictTypeId = source.DictTypeId;
        destination.Id = source.Id;
        destination.Name = source.Name;
        destination.ParentId = source.ParentId;
        destination.Style = source.Style;
        destination.Sort = source.Sort;
        destination.TenantId = source.TenantId;
        destination.Alias = source.Alias;
        destination.Describe = source.Describe;
        destination.Status = source.Status;

        // 映射 ExtraProperties 字典
        // 策略：清空目标字典，然后将源字典的内容复制过去
        // 这确保了目标对象的 ExtraProperties 与源对象完全一致
        destination.ExtraProperties?.Clear(); // 清空目标字典（如果它不为 null）

        if (destination.ExtraProperties == null)
        {
            return;
        }

        // 遍历源字典并添加到目标字典
        // 注意：ToList() 是为了在迭代时避免潜在的集合修改异常（如果源字典在迭代过程中被修改）
        foreach (var kvp in source.ExtraProperties.ToList())
        {
            destination.ExtraProperties[kvp.Key] = kvp.Value;
        }
    }
}
