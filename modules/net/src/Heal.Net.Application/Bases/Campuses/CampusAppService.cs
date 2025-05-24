using Heal.Core.Domain.Bases.Campuses.Entities;
using Heal.Core.Domain.Bases.Campuses.Repositories;
using Heal.Core.Domain.Bases.Organizations.Managers;
using Heal.Domain.Managers;
using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Enums;
using Heal.Domain.Shared.Extensions;
using Heal.Net.Application.Contracts.Bases.Campuses;
using Heal.Net.Application.Contracts.Bases.Campuses.Dto;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Bases.Campuses;

/// <summary>
/// 院区服务
/// </summary>
public class CampusAppService(
    ISequenceManager sequenceManager,
    IOrganizationManager organizationManager,
    ICampusRepository campusRepository) : HealNetAppService, ICampusAppService
{
    /// <summary>
    /// 创建用户
    /// </summary>
    /// <param name="input">用户创建信息</param>
    /// <param name="cancellationToken"></param>
    /// <returns>用户</returns>
    public async Task<CampusDto> CreateAsync(CampusCreateDto input, CancellationToken cancellationToken = default)
    {
        var clockNow = Clock.Now;
        var code = await sequenceManager.PadNumberWithZerosAsync(CampusConstants.Code,
            OrganizationUnitExtensionConstants.CodeDefaultLength, cancellationToken);
        var organizationId =
            await organizationManager.GetOrganizationIdAsync(input.OrganizationCode, cancellationToken);
        var entity = new Campus(
            GuidGenerator.Create(),
            input.Name,
            code
        );

        SetCampus(input, entity);
        entity.SetOrganization(organizationId, input.OrganizationCode);
        entity.SetCreator(CurrentUser.Id, CurrentUser.GetCurrentUserName(), clockNow);
        entity.SetModification(CurrentUser.Id, CurrentUser.GetCurrentUserName(), clockNow);

        var campus = await campusRepository.InsertAsync(entity, cancellationToken: cancellationToken);

        return ObjectMapper.Map<Campus, CampusDto>(campus);
    }

    /// <summary>
    /// 更新院区
    /// </summary>
    /// <param name="id">Id</param>
    /// <param name="input">院区更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>院区</returns>
    public async Task<CampusDto> UpdateAsync(Guid id, CampusUpdateDto input,
        CancellationToken cancellationToken = default)
    {
        var clockNow = Clock.Now;
        var entity = await campusRepository.GetAsync(id, cancellationToken: cancellationToken);

        SetCampus(input, entity);

        entity.SetModification(CurrentUser.Id, CurrentUser.GetCurrentUserName(), clockNow);

        var campus = await campusRepository.UpdateAsync(entity, cancellationToken: cancellationToken);

        return ObjectMapper.Map<Campus, CampusDto>(campus);
    }

    /// <summary>
    /// 获取院区列表
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>院区列表</returns>
    public async Task<PagedResultDto<CampusListDto>> GetListAsync(CampusInput input, CancellationToken cancellationToken = default)
    {
        var list = await campusRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount, input.Filter, cancellationToken: cancellationToken);
        var totalCount = await campusRepository.GetCountAsync(input.Filter, cancellationToken);

        return new PagedResultDto<CampusListDto>(
            totalCount,
            ObjectMapper.Map<List<Campus>, List<CampusListDto>>(list)
        );
    }

    /// <summary>
    /// 设置院区信息
    /// </summary>
    /// <param name="input">院区创建和修改</param>
    /// <param name="entity">院区实体</param>
    private void SetCampus(CampusCreateOrUpdateDto input, Campus entity)
    {
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
        entity.SetSort(input.Sort);
        entity.SetDescribe(input.Describe);
        entity.SetStatus(Enable.Enabled);
    }
}