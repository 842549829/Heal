using Heal.Core.Domain.Bases.Departments.Entities;
using Heal.Core.Domain.Bases.Departments.Repositories;
using Heal.Core.Domain.Bases.Organizations.Managers;
using Heal.Domain.Managers;
using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Enums;
using Heal.Domain.Shared.Extensions;
using Heal.Net.Application.Contracts.Bases.Departments;
using Heal.Net.Application.Contracts.Bases.Departments.Dto;
using Volo.Abp.Application.Dtos;

namespace Heal.Net.Application.Bases.Departments;

/// <summary>
/// 科室服务
/// </summary>
public class DepartmentService(
    ISequenceManager sequenceManager,
    IOrganizationManager organizationManager,
    IDepartmentRepository departmentRepository) : HealNetAppService, IDepartmentService
{
    /// <summary>
    /// 创建科室
    /// </summary>
    /// <param name="input">创建信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室</returns>
    public async Task<DepartmentDto> CreateAsync(DepartmentCreateDto input,
        CancellationToken cancellationToken = default)
    {
        var clockNow = Clock.Now;
        var code = await sequenceManager.PadNumberWithZerosAsync(DepartmentConstants.Code,
            OrganizationUnitExtensionConstants.CodeDefaultLength, cancellationToken);
        var organizationId =
            await organizationManager.GetOrganizationIdAsync(input.OrganizationCode, cancellationToken);
        var entity = new Department(
            GuidGenerator.Create(),
            input.Name,
            code
        );
        SetDepartment(input, entity);
        entity.SetOrganization(organizationId, input.OrganizationCode);
        entity.SetTenant(CurrentUser.TenantId);
        entity.SetCampus(input.CampusId);
        entity.SetCreator(CurrentUser.Id, CurrentUser.GetCurrentUserName(), clockNow);
        entity.SetModification(CurrentUser.Id, CurrentUser.GetCurrentUserName(), clockNow);

        var department = await departmentRepository.InsertAsync(entity, cancellationToken: cancellationToken);

        return ObjectMapper.Map<Department, DepartmentDto>(department);
    }

    /// <summary>
    /// 科室分页查询
    /// </summary>
    /// <param name="input">查询条件</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室列表</returns>
    public async Task<PagedResultDto<DepartmentListDto>> GetListAsync(DepartmentInput input,
        CancellationToken cancellationToken = default)
    {
        var list = await departmentRepository.GetListAsync(input.Sorting, input.MaxResultCount, input.SkipCount,
            input.Filter, cancellationToken: cancellationToken);
        var totalCount = await departmentRepository.GetCountAsync(input.Filter, cancellationToken);

        return new PagedResultDto<DepartmentListDto>(
            totalCount,
            ObjectMapper.Map<List<Department>, List<DepartmentListDto>>(list)
        );
    }

    /// <summary>
    /// 更新科室    
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="input">更新信息</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室</returns>
    public async Task<DepartmentDto> UpdateAsync(Guid id, DepartmentUpdateDto input,
        CancellationToken cancellationToken = default)
    {
        var clockNow = Clock.Now;
        var entity = await departmentRepository.GetAsync(id, cancellationToken: cancellationToken);

        SetDepartment(input, entity);

        entity.SetModification(CurrentUser.Id, CurrentUser.GetCurrentUserName(), clockNow);

        var department = await departmentRepository.UpdateAsync(entity, cancellationToken: cancellationToken);

        return ObjectMapper.Map<Department, DepartmentDto>(department);
    }

    /// <summary>
    /// 获取科室
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>科室</returns>
    public async Task<DepartmentDto> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await departmentRepository.GetAsync(id, cancellationToken: cancellationToken);
        return ObjectMapper.Map<Department, DepartmentDto>(entity);
    }

    /// <summary>
    /// 删除科室
    /// </summary>
    /// <param name="id">id</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns>结果</returns>
    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        // // 先判断该科室下面有没有子科室
        // if (await departmentRepository.GetCountAsync(
        //         $"ParentId = '{id}'",
        //         cancellationToken: cancellationToken) > 0)
        // {
        //     throw new UserFriendlyException("");
        // }
        // // 判断该科室下面是否有医生
        // if (await departmentRepository.GetCountAsync(
        //         $"DepartmentTypeId = '{DepartmentTypeEnum.Doctor}' and DepartmentId = '{id}'",
        //         cancellationToken: cancellationToken) > 0)
        // {
        //     throw new UserFriendlyException("");
        // }

        await departmentRepository.DeleteAsync(id, cancellationToken: cancellationToken);
        return true;
    }

    /// <summary>
    /// 设置科室信息
    /// </summary>
    /// <param name="input">院区创建和修改</param>
    /// <param name="entity">院区实体</param>
    private static void SetDepartment(DepartmentCreateOrUpdateDto input, Department entity)
    {
        entity.SetShortName(input.ShortName);
        entity.SetBuilding(input.Building);
        entity.SetFloor(input.Floor);
        entity.SetRoomNumber(input.RoomNumber);
        entity.SetAddress(input.Address);
        entity.SetCapacity(input.Capacity);
        entity.SetPhone(input.Phone);
        entity.SetEmail(input.Email);
        entity.SetWebsite(input.Website);
        entity.SetServicesOffered(input.ServicesOffered);
        entity.SetEmergencyContact(input.EmergencyContact);
        entity.SetEmergencyPhone(input.EmergencyPhone);
        entity.SetParent(input.ParentId);
        entity.SetSort(input.Sort);
        entity.SetDescribe(input.Describe);
        entity.SetStatus(Enable.Enabled);
        entity.SetDepartmentTypeId(input.DepartmentTypeId);
        entity.SetHeadOfDepartment(input.HeadOfDepartment);
        entity.SetHeadOfDepartmentPhone(input.HeadOfDepartmentPhone);
        entity.SetHeadOfDepartmentEmail(input.HeadOfDepartmentEmail);
    }
}