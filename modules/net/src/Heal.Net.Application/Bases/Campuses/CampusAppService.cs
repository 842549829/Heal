using Heal.Domain.Managers;
using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Enums;
using Heal.Domain.Shared.Extensions;
using Heal.Net.Application.Contracts.Bases.Campuses;
using Heal.Net.Application.Contracts.Bases.Campuses.Dto;
using Heal.Net.Domain.Bases.Campuses.Entities;
using Heal.Net.Domain.Bases.Campuses.Repositories;

namespace Heal.Net.Application.Bases.Campuses;

/// <summary>
/// 院区服务
/// </summary>
public class CampusAppService(ISequenceManager sequenceManager, ICampusRepository campusRepository) : HealNetAppService, ICampusAppService
{
    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="input">用户创建信息</param>
    /// <returns>用户</returns>
    public async Task<CampusDto> CreateAsync(CampusCreateDto input)
    {
        var clockNow = Clock.Now;
        var code = await sequenceManager.PadNumberWithZerosAsync(CampusConsts.Code);
        var entity = new Campus(
            GuidGenerator.Create(),
            input.Name
        )
        {
            ShortName = input.ShortName,
            Building = input.Building,
            Floor = input.Floor,
            RoomNumber = input.RoomNumber,
            Address = input.Address,
            Capacity = input.Capacity,
            Phone = input.Phone,
            Email = input.Email,
            HeadOfCampus = input.HeadOfCampus,
            HeadOfCampusPhone = input.HeadOfCampusPhone,
            HeadOfCampusEmail = input.HeadOfCampusEmail,
            Website = input.Website,
            ServicesOffered = input.ServicesOffered,
            EmergencyContact = input.EmergencyContact,
            EmergencyPhone = input.EmergencyPhone
        };
        entity.SetCode(code);
        entity.SetTenant(CurrentUser.TenantId);
        entity.SetOrganization(input.OrganizationId);
        entity.SetSort(input.Sort);
        entity.SetDescribe(input.Describe);
        entity.SetStatus(Enable.Enabled);
        entity.SetCreator(CurrentUser.Id, CurrentUser.GetCurrentUserName(), clockNow);
        entity.SetModification(CurrentUser.Id, CurrentUser.GetCurrentUserName(), clockNow);

        var campus = await campusRepository.InsertAsync(entity);

        return ObjectMapper.Map<Campus, CampusDto>(campus);
    }
}