using Heal.Core.Domain.Bases.Campuses.Entities;
using Heal.Net.Application.Contracts.Bases.Campuses.Dto;
using Riok.Mapperly.Abstractions;
using Volo.Abp.Mapperly;

namespace Heal.Net.Application.Bases.Campuses;


[Mapper]
public partial class CampusAutoListMapperProfile : MapperBase<Campus, CampusListDto>
{
    public override partial CampusListDto Map(Campus source);

    public override partial void Map(Campus source, CampusListDto destination);
}