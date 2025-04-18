using FluentValidation;
using Heal.Application;
using Heal.Domain.Shared.Constants;
using Heal.Net.Application.Contracts.Bases.Campuses.Dto;
using Volo.Abp.DependencyInjection;

namespace Heal.Net.Application.Bases.Campuses;

/// <summary>
/// 院区创建验证器
/// </summary>
public class CampusCreateValidator : ValidationBase<CampusCreateDto>
{
    /// <summary>
    /// 院区创建验证器
    /// </summary>
    public CampusCreateValidator(IAbpLazyServiceProvider lazyServiceProvider) : base(lazyServiceProvider)
    {
        // 验证名称
        RuleFor(x => x.Name)
            .NotNull()
            .WithMessage(FieldIsRequiredFormatLocalized(LocalizedTextsConsts.Name))
            .Length(1, NameConsts.MaxLength)
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Name, 1, NameConsts.MaxLength));

        // 验证编码
        RuleFor(x => x.OrganizationCode)
            .NotNull()
            .WithMessage(FieldIsRequiredFormatLocalized(LocalizedTextsConsts.OrganizationCode))
            .Length(1, CodeConsts.MaxLength)
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.OrganizationCode, 1, CodeConsts.MaxLength));

        // 验证描述
        RuleFor(x => x.Describe)
            .Length(1, DescribeConsts.MaxLength)
            .When(x => !string.IsNullOrEmpty(x.Describe)) // 当字段不为空时才进行长度验证
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Describe, 1, CodeConsts.MaxLength));

        // 验证简称
        RuleFor(x => x.ShortName)
            .Length(1, CampusConsts.MaxShortNameLength)
            .When(x => !string.IsNullOrEmpty(x.ShortName))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.ShortName, 1, CampusConsts.MaxShortNameLength));

        // 验证所在大楼
        RuleFor(x => x.Building)
            .Length(1, CampusConsts.MaxBuildingLength)
            .When(x => !string.IsNullOrEmpty(x.Building)) // 当字段不为空时才进行长度验证
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Building, 1, CampusConsts.MaxBuildingLength));

        // 验证所在楼层
        RuleFor(x => x.Floor)
            .Length(1, CampusConsts.MaxFloorLength)
            .When(x => !string.IsNullOrEmpty(x.Floor))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Floor, 1, CampusConsts.MaxFloorLength));

        // 验证所在房间号
        RuleFor(x => x.RoomNumber)
            .Length(1, CampusConsts.MaxRoomNumberLength)
            .When(x => !string.IsNullOrEmpty(x.RoomNumber))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.RoomNumber, 1, CampusConsts.MaxRoomNumberLength));

        // 验证地址
        RuleFor(x => x.Address)
            .Length(1, CampusConsts.MaxAddressLength)
            .When(x => !string.IsNullOrEmpty(x.Address))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Address, 1, CampusConsts.MaxAddressLength));

        // 验证联系电话
        RuleFor(x => x.Phone)
            .Length(1, CampusConsts.MaxPhoneLength)
            .When(x => !string.IsNullOrEmpty(x.Phone))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Phone, 1, CampusConsts.MaxPhoneLength));

        // 验证联系邮箱
        RuleFor(x => x.Email)
            .Length(1, CampusConsts.MaxEmailLength)
            .When(x => !string.IsNullOrEmpty(x.Email))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Email, 1, CampusConsts.MaxEmailLength));

        // 验证负责人姓名
        RuleFor(x => x.HeadOfCampus)
            .Length(1, CampusConsts.MaxHeadOfCampusLength)
            .When(x => !string.IsNullOrEmpty(x.HeadOfCampus))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.HeadOfCampus, 1, CampusConsts.MaxHeadOfCampusLength));

        // 验证负责人联系电话
        RuleFor(x => x.HeadOfCampusPhone)
            .Length(1, CampusConsts.MaxHeadOfCampusPhoneLength)
            .When(x => !string.IsNullOrEmpty(x.HeadOfCampusPhone))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.HeadOfCampusPhone, 1, CampusConsts.MaxHeadOfCampusPhoneLength));

        // 验证负责人联系邮箱
        RuleFor(x => x.HeadOfCampusEmail)
            .Length(1, CampusConsts.MaxHeadOfCampusEmailLength)
            .When(x => !string.IsNullOrEmpty(x.HeadOfCampusEmail))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.HeadOfCampusEmail, 1, CampusConsts.MaxHeadOfCampusEmailLength));

        // 验证网站
        RuleFor(x => x.Website)
            .Length(1, CampusConsts.MaxWebsiteLength)
            .When(x => !string.IsNullOrEmpty(x.Website))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.Website, 1, CampusConsts.MaxWebsiteLength));

        // 验证提供的服务
        RuleFor(x => x.ServicesOffered)
            .Length(1, CampusConsts.MaxServicesOfferedLength)
            .When(x => !string.IsNullOrEmpty(x.ServicesOffered))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.ServicesOffered, 1, CampusConsts.MaxServicesOfferedLength));

        // 验证紧急联系人
        RuleFor(x => x.EmergencyContact)
            .Length(1, CampusConsts.MaxEmergencyContactLength)
            .When(x => !string.IsNullOrEmpty(x.EmergencyContact))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.EmergencyContact, 1, CampusConsts.MaxEmergencyContactLength));

        // 验证紧急联系电话
        RuleFor(x => x.EmergencyPhone)
            .Length(1, CampusConsts.MaxEmergencyPhoneLength)
            .When(x => !string.IsNullOrEmpty(x.EmergencyPhone))
            .WithMessage(FieldLengthFormatLocalized(LocalizedTextsConsts.EmergencyPhone, 1, CampusConsts.MaxEmergencyPhoneLength));
    }
}