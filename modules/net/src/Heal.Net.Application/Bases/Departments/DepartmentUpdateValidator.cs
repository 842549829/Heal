using FluentValidation;
using Heal.Application;
using Heal.Domain.Shared.Constants;
using Heal.Net.Application.Contracts.Bases.Departments.Dto;
using Volo.Abp.DependencyInjection;

namespace Heal.Net.Application.Bases.Departments;

/// <summary>
/// 部门更新验证器
/// </summary>
public class DepartmentUpdateValidator: ValidationBase<DepartmentUpdateDto>
{
    /// <summary>
    /// 构造函数
    /// </summary>
    /// <param name="lazyServiceProvider">IAbpLazyServiceProvider</param>
    public DepartmentUpdateValidator(IAbpLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
        // 验证名称
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage(FieldIsRequiredFormatLocalized(LocalizedTextsConsts.Name))
            .Length(1, NameConsts.MaxLength)
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Name, 1, NameConsts.MaxLength));

        // 验证描述
        RuleFor(x => x.Describe)
            .Length(1, DescribeConsts.MaxLength)
            .When(x => !string.IsNullOrEmpty(x.Describe)) // 当字段不为空时才进行长度验证
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Describe, 1, CodeConsts.MaxLength));

        // 验证简称
        RuleFor(x => x.ShortName)
            .Length(1, DepartmentConsts.MaxShortNameLength)
            .When(x => !string.IsNullOrEmpty(x.ShortName))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.ShortName, 1,
                DepartmentConsts.MaxShortNameLength));

        // 验证所在大楼
        RuleFor(x => x.Building)
            .Length(1, DepartmentConsts.MaxBuildingLength)
            .When(x => !string.IsNullOrEmpty(x.Building)) // 当字段不为空时才进行长度验证
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Building, 1, DepartmentConsts.MaxBuildingLength));

        // 验证所在楼层
        RuleFor(x => x.Floor)
            .Length(1, DepartmentConsts.MaxFloorLength)
            .When(x => !string.IsNullOrEmpty(x.Floor))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Floor, 1, DepartmentConsts.MaxFloorLength));

        // 验证所在房间号
        RuleFor(x => x.RoomNumber)
            .Length(1, DepartmentConsts.MaxRoomNumberLength)
            .When(x => !string.IsNullOrEmpty(x.RoomNumber))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.RoomNumber, 1,
                DepartmentConsts.MaxRoomNumberLength));

        // 验证地址
        RuleFor(x => x.Address)
            .Length(1, DepartmentConsts.MaxAddressLength)
            .When(x => !string.IsNullOrEmpty(x.Address))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Address, 1, DepartmentConsts.MaxAddressLength));

        // 验证联系电话
        RuleFor(x => x.Phone)
            .Length(1, DepartmentConsts.MaxPhoneLength)
            .When(x => !string.IsNullOrEmpty(x.Phone))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Phone, 1, DepartmentConsts.MaxPhoneLength));

        // 验证联系邮箱
        RuleFor(x => x.Email)
            .Length(1, DepartmentConsts.MaxEmailLength)
            .When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Email, 1, DepartmentConsts.MaxEmailLength));
        
        // 验证网站
        RuleFor(x => x.Website)
            .Length(1, DepartmentConsts.MaxWebsiteLength)
            .When(x => !string.IsNullOrEmpty(x.Website))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Website, 1, DepartmentConsts.MaxWebsiteLength));

        // 验证提供的服务
        RuleFor(x => x.ServicesOffered)
            .Length(1, DepartmentConsts.MaxServicesOfferedLength)
            .When(x => !string.IsNullOrEmpty(x.ServicesOffered))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.ServicesOffered, 1,
                DepartmentConsts.MaxServicesOfferedLength));

        // 验证紧急联系人
        RuleFor(x => x.EmergencyContact)
            .Length(1, DepartmentConsts.MaxEmergencyContactLength)
            .When(x => !string.IsNullOrEmpty(x.EmergencyContact))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.EmergencyContact, 1,
                DepartmentConsts.MaxEmergencyContactLength));

        // 验证紧急联系电话
        RuleFor(x => x.EmergencyPhone)
            .Length(1, DepartmentConsts.MaxEmergencyPhoneLength)
            .When(x => !string.IsNullOrEmpty(x.EmergencyPhone))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.EmergencyPhone, 1,
                DepartmentConsts.MaxEmergencyPhoneLength));
    }
}