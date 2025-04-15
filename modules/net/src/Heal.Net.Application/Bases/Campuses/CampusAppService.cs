using Heal.Domain.Managers;
using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Enums;
using Heal.Domain.Shared.Extensions;
using Heal.Net.Application.Contracts.Bases.Campuses;
using Heal.Net.Application.Contracts.Bases.Campuses.Dto;
using Heal.Net.Domain.Bases.Campuses.Entities;
using Heal.Net.Domain.Bases.Campuses.Repositories;
using Heal.Net.Domain.Bases.Organizations.Managers;

namespace Heal.Net.Application.Bases.Campuses;

/// <summary>
/// 院区服务
/// </summary>
public class CampusAppService(ISequenceManager sequenceManager,
    IOrganizationManager organizationManager,
    ICampusRepository campusRepository) : HealNetAppService, ICampusAppService
{
    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="input">用户创建信息</param>
    /// <returns>用户</returns>
    public async Task<CampusDto> CreateAsync(CampusCreateDto input)
    {
        var clockNow = Clock.Now;
        var code = await sequenceManager.PadNumberWithZerosAsync(CampusConsts.Code, OrganizationUnitExtensionConsts.CodeDefaultLength);
        var organizationId = await organizationManager.GetOrganizationIdAsync(input.OrganizationCode);
        var entity = new Campus(
            GuidGenerator.Create(),
            input.Name,
            code
        );
        entity.SetShortName(input.ShortName);
        entity.SetBuilding(input.Building);
        entity.SetFloor(input.Floor);
        entity.SetRoomNumber(input.RoomNumber);
        entity.SetAddress(input.Address);
        entity.SetCapacity(input.Capacity);
        entity.SetPhone(input.Phone);
        entity.SetEmail(input.Email);
        entity.SetHeadOfCampus(input.HeadOfCampus);
        entity.SetHeadOfCampusPhone(input.HeadOfCampusPhone);
        entity.SetHeadOfCampusEmail(input.HeadOfCampusEmail);
        entity.SetWebsite(input.Website);
        entity.SetServicesOffered(input.ServicesOffered);
        entity.SetEmergencyContact(input.EmergencyContact);
        entity.SetEmergencyPhone(input.EmergencyPhone);
        entity.SetParent(input.ParentId);
        entity.SetTenant(CurrentUser.TenantId);
        entity.SetOrganization(organizationId, input.OrganizationCode);
        entity.SetSort(input.Sort);
        entity.SetDescribe(input.Describe);
        entity.SetStatus(Enable.Enabled);
        entity.SetCreator(CurrentUser.Id, CurrentUser.GetCurrentUserName(), clockNow);
        entity.SetModification(CurrentUser.Id, CurrentUser.GetCurrentUserName(), clockNow);

        var campus = await campusRepository.InsertAsync(entity);

        return ObjectMapper.Map<Campus, CampusDto>(campus);
    }
}