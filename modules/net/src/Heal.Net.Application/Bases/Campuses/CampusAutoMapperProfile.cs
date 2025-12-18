using Heal.Core.Domain.Bases.Campuses.Entities;
using Heal.Net.Application.Contracts.Bases.Campuses.Dto;
using Riok.Mapperly.Abstractions;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Mapperly;

namespace Heal.Net.Application.Bases.Campuses;

/// <summary>
/// AutoMapper配置
/// </summary>
[Mapper]
public partial class CampusAutoMapperProfile : IAbpMapperlyMapper<Campus, CampusDto>, IAbpMapperlyMapper<CampusDto, Campus>, ITransientDependency
{
    /// <summary>
    /// Map
    /// </summary>
    /// <param name="source">Campus</param>
    /// <returns>CampusDto</returns>
    public CampusDto Map(Campus source)
    {
        var campusDto = new CampusDto
        {
            Code = source.Code,
            Name = source.Name,
            OrganizationCode = source.OrganizationCode,
            Sort = source.Sort,
            Describe = source.Describe,
            ShortName = source.ShortName,
            Building = source.Building,
            Floor = source.Floor,
            RoomNumber = source.RoomNumber,
            Address = source.Address,
            Capacity = source.Capacity,
            Phone = source.Phone,
            Email = source.Email,
            HeadOfCampus = source.HeadOfCampus,
            HeadOfCampusPhone = source.HeadOfCampusPhone,
            HeadOfCampusEmail = source.HeadOfCampusEmail,
            Website = source.Website,
            ServicesOffered = source.ServicesOffered,
            EmergencyContact = source.EmergencyContact,
            EmergencyPhone = source.EmergencyPhone,
            ConcurrencyStamp = source.ConcurrencyStamp,
            CreationTime = source.CreationTime,
            CreatorId = source.CreatorId,
            LastModificationTime = source.LastModificationTime,
            LastModifierId = source.LastModifierId,
            CreatorName = source.CreatorName,
            Id = source.Id,
            LastModificationName = source.LastModificationName,
        };
        return campusDto;
    }

    /// <summary>
    /// Map
    /// </summary>
    /// <param name="source">Campus</param>
    /// <param name="destination">CampusDto</param>
    public void Map(Campus source, CampusDto destination)
    {
        destination.Code = source.Code;
        destination.Name = source.Name;
        destination.OrganizationCode = source.OrganizationCode;
        destination.Sort = source.Sort;
        destination.Describe = source.Describe;
        destination.ShortName = source.ShortName;
        destination.Building = source.Building;
        destination.Floor = source.Floor;
        destination.RoomNumber = source.RoomNumber;
        destination.Address = source.Address;
        destination.Capacity = source.Capacity;
        destination.Phone = source.Phone;
        destination.Email = source.Email;
        destination.HeadOfCampus = source.HeadOfCampus;
        destination.HeadOfCampusPhone = source.HeadOfCampusPhone;
        destination.HeadOfCampusEmail = source.HeadOfCampusEmail;
        destination.Website = source.Website;
        destination.ServicesOffered = source.ServicesOffered;
        destination.EmergencyContact = source.EmergencyContact;
        destination.EmergencyPhone = source.EmergencyPhone;
        destination.ConcurrencyStamp = source.ConcurrencyStamp;
        destination.CreationTime = source.CreationTime;
        destination.CreatorId = source.CreatorId;
        destination.LastModificationTime = source.LastModificationTime;
        destination.LastModifierId = source.LastModifierId;
        destination.CreatorName = source.CreatorName;
        destination.Id = source.Id;
        destination.LastModificationName = source.LastModificationName;
    }

    public void BeforeMap(Campus source)
    {
    }

    public void AfterMap(Campus source, CampusDto destination)
    {
    }

    public partial Campus Map(CampusDto source);

    public partial void Map(CampusDto source, Campus destination);

    public void BeforeMap(CampusDto source)
    {
    }

    public void AfterMap(CampusDto source, Campus destination)
    {
    }
}
