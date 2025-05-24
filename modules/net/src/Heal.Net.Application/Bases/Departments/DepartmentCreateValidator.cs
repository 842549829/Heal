using FluentValidation;
using Heal.Application;
using Heal.Domain.Shared.Constants;
using Heal.Net.Application.Contracts.Bases.Departments.Dto;
using Volo.Abp.DependencyInjection;

namespace Heal.Net.Application.Bases.Departments;

/// <summary>
/// 部门创建验证器
/// </summary>
public class DepartmentCreateValidator: ValidationBase<DepartmentCreateDto>
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="lazyServiceProvider">IAbpLazyServiceProvider</param>
    public DepartmentCreateValidator(IAbpLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
        // 验证名称
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage(FieldIsRequiredFormatLocalized(LocalizedTextsConstants.Name))
            .Length(1, NameConstants.MaxLength)
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConstants.Name, 1, NameConstants.MaxLength));
        
          // 验证编码
        RuleFor(x => x.OrganizationCode)
            .NotNull()
            .WithMessage(FieldIsRequiredFormatLocalized(LocalizedTextsConstants.OrganizationCode))
            .Length(1, CodeConstants.MaxLength)
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConstants.OrganizationCode, 1, CodeConstants.MaxLength));

        // 验证描述
        RuleFor(x => x.Describe)
            .Length(1, DescribeConstants.MaxLength)
            .When(x => !string.IsNullOrEmpty(x.Describe)) // 当字段不为空时才进行长度验证
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConstants.Describe, 1, CodeConstants.MaxLength));

        // 验证简称
        RuleFor(x => x.ShortName)
            .Length(1, DepartmentConstants.MaxShortNameLength)
            .When(x => !string.IsNullOrEmpty(x.ShortName))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConstants.ShortName, 1, DepartmentConstants.MaxShortNameLength));

        // 验证所在大楼
        RuleFor(x => x.Building)
            .Length(1, DepartmentConstants.MaxBuildingLength)
            .When(x => !string.IsNullOrEmpty(x.Building)) // 当字段不为空时才进行长度验证
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConstants.Building, 1, DepartmentConstants.MaxBuildingLength));

        // 验证所在楼层
        RuleFor(x => x.Floor)
            .Length(1, DepartmentConstants.MaxFloorLength)
            .When(x => !string.IsNullOrEmpty(x.Floor))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConstants.Floor, 1, DepartmentConstants.MaxFloorLength));

        // 验证所在房间号
        RuleFor(x => x.RoomNumber)
            .Length(1, DepartmentConstants.MaxRoomNumberLength)
            .When(x => !string.IsNullOrEmpty(x.RoomNumber))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConstants.RoomNumber, 1, DepartmentConstants.MaxRoomNumberLength));

        // 验证地址
        RuleFor(x => x.Address)
            .Length(1, DepartmentConstants.MaxAddressLength)
            .When(x => !string.IsNullOrEmpty(x.Address))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConstants.Address, 1, DepartmentConstants.MaxAddressLength));

        // 验证联系电话
        RuleFor(x => x.Phone)
            .Length(1, DepartmentConstants.MaxPhoneLength)
            .When(x => !string.IsNullOrEmpty(x.Phone))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConstants.Phone, 1, DepartmentConstants.MaxPhoneLength));

        // 验证联系邮箱
        RuleFor(x => x.Email)
            .Length(1, DepartmentConstants.MaxEmailLength)
            .When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConstants.Email, 1, DepartmentConstants.MaxEmailLength));

        // 验证网站
        RuleFor(x => x.Website)
            .Length(1, DepartmentConstants.MaxWebsiteLength)
            .When(x => !string.IsNullOrEmpty(x.Website))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConstants.Website, 1, DepartmentConstants.MaxWebsiteLength));

        // 验证提供的服务
        RuleFor(x => x.ServicesOffered)
            .Length(1, DepartmentConstants.MaxServicesOfferedLength)
            .When(x => !string.IsNullOrEmpty(x.ServicesOffered))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConstants.ServicesOffered, 1, DepartmentConstants.MaxServicesOfferedLength));

        // 验证紧急联系人
        RuleFor(x => x.EmergencyContact)
            .Length(1, DepartmentConstants.MaxEmergencyContactLength)
            .When(x => !string.IsNullOrEmpty(x.EmergencyContact))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConstants.EmergencyContact, 1, DepartmentConstants.MaxEmergencyContactLength));

        // 验证紧急联系电话
        RuleFor(x => x.EmergencyPhone)
            .Length(1, DepartmentConstants.MaxEmergencyPhoneLength)
            .When(x => !string.IsNullOrEmpty(x.EmergencyPhone))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConstants.EmergencyPhone, 1, DepartmentConstants.MaxEmergencyPhoneLength));

    }
}