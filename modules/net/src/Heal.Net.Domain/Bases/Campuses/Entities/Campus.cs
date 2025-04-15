using Heal.Domain.Entities;
using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Extensions;

namespace Heal.Net.Domain.Bases.Campuses.Entities;

/// <summary>
/// 院区
/// </summary>
/// <param name="id">id</param>
/// <param name="name">名称</param>
public class Campus(Guid id, string name, string code) : FullParentHealthcareAuditedAggregateRoot<Guid>(id, name, code)
{
    /// <summary>
    /// 简称
    /// </summary>
    public string? ShortName { get; private set; }

    /// <summary>
    /// 设置简称
    /// </summary>
    /// <param name="shortName">简称</param>
    public void SetShortName(string? shortName)
    {
        FieldValidatorExtension.ValidateFieldLength(shortName, "简称", 1, CampusConsts.MaxShortNameLength);
        ShortName = shortName;
    }

    /// <summary>
    /// 所在大楼
    /// </summary>
    public string? Building { get; private set; }

    /// <summary>
    /// 设置所在大楼
    /// </summary>
    /// <param name="building">所在大楼</param>
    public void SetBuilding(string? building)
    {
        FieldValidatorExtension.ValidateFieldLength(building, "所在大楼", 1, CampusConsts.MaxBuildingLength);
        Building = building;
    }

    /// <summary>
    /// 所在楼层
    /// </summary>
    public string? Floor { get; private set; }

    /// <summary>
    /// 设置所在楼层
    /// </summary>
    /// <param name="floor">所在楼层</param>
    public void SetFloor(string? floor)
    {
        FieldValidatorExtension.ValidateFieldLength(floor, "所在楼层", 1, CampusConsts.MaxFloorLength);
        Floor = floor;
    }

    /// <summary>
    /// 房间号
    /// </summary>
    public string? RoomNumber { get; private set; }

    /// <summary>
    /// 设置房间号
    /// </summary>
    /// <param name="roomNumber">房间号</param>
    public void SetRoomNumber(string? roomNumber)
    {
        FieldValidatorExtension.ValidateFieldLength(roomNumber, "房间号", 1, CampusConsts.MaxRoomNumberLength);
        RoomNumber = roomNumber;
    }

    /// <summary>
    /// 所在详细地址
    /// </summary>
    public string? Address { get; private set; }

    /// <summary>
    /// 设置所在详细地址
    /// </summary>
    /// <param name="address">所在详细地址</param>
    public void SetAddress(string? address)
    {
        FieldValidatorExtension.ValidateFieldLength(address, "所在详细地址", 1, CampusConsts.MaxAddressLength);
        Address = address;
    }

    /// <summary>
    /// 床位数/接待能力(该院区可容纳的最大病人数或接诊量)
    /// </summary>
    public int Capacity { get; private set; }

    /// <summary>
    /// 设置床位数/接待能力
    /// </summary>
    /// <param name="capacity">床位数/接待能力</param>
    public void SetCapacity(int capacity)
    {
        FieldValidatorExtension.ValidateNonNegativeInt(capacity, "床位数/接待能力");
        Capacity = capacity;
    }

    /// <summary>
    /// 联系电话
    /// </summary>
    public string? Phone { get; private set; }

    /// <summary>
    /// 设置联系电话
    /// </summary>
    /// <param name="phone">联系电话</param>
    public void SetPhone(string? phone)
    {
        FieldValidatorExtension.ValidateFieldLength(phone, "联系电话", 1, CampusConsts.MaxPhoneLength);
        Phone = phone;
    }

    /// <summary>
    /// 电子邮箱
    /// </summary>
    public string? Email { get; private set; }

    /// <summary>
    /// 设置电子邮箱
    /// </summary>
    /// <param name="email">电子邮箱</param>
    public void SetEmail(string? email)
    {
        FieldValidatorExtension.ValidateFieldLength(email, "电子邮箱", 1, CampusConsts.MaxEmailLength);
        Email = email;
    }

    /// <summary>
    /// 院区负责人
    /// </summary>
    public string? HeadOfCampus { get; private set; }

    /// <summary>
    /// 设置院区负责人
    /// </summary>
    /// <param name="headOfCampus">院区负责人</param>
    public void SetHeadOfCampus(string? headOfCampus)
    {
        FieldValidatorExtension.ValidateFieldLength(headOfCampus, "院区负责人", 1, CampusConsts.MaxHeadOfCampusLength);
        HeadOfCampus = headOfCampus;
    }

    /// <summary>
    /// 负责人电话
    /// </summary>
    public string? HeadOfCampusPhone { get; private set; }

    /// <summary>
    /// 设置负责人电话
    /// </summary>
    /// <param name="headOfCampusPhone">负责人电话</param>
    public void SetHeadOfCampusPhone(string? headOfCampusPhone)
    {
        FieldValidatorExtension.ValidateFieldLength(headOfCampusPhone, "负责人电话", 1, CampusConsts.MaxHeadOfCampusPhoneLength);
        HeadOfCampusPhone = headOfCampusPhone;
    }

    /// <summary>
    /// 负责人邮箱
    /// </summary>
    public string? HeadOfCampusEmail { get; private set; }

    /// <summary>
    /// 设置负责人邮箱
    /// </summary>
    /// <param name="headOfCampusEmail">负责人邮箱</param>
    public void SetHeadOfCampusEmail(string? headOfCampusEmail)
    {
        FieldValidatorExtension.ValidateFieldLength(headOfCampusEmail, "负责人邮箱", 1, CampusConsts.MaxHeadOfCampusEmailLength);
        HeadOfCampusEmail = headOfCampusEmail;
    }

    /// <summary>
    /// 院区网站
    /// </summary>
    public string? Website { get; private set; }

    /// <summary>
    /// 设置院区网站
    /// </summary>
    /// <param name="website">院区网站</param>
    public void SetWebsite(string? website)
    {
        FieldValidatorExtension.ValidateFieldLength(website, "院区网站", 1, CampusConsts.MaxWebsiteLength);
        Website = website;
    }

    /// <summary>
    /// 提供的服务
    /// </summary>
    public string? ServicesOffered { get; private set; }

    /// <summary>
    /// 设置提供的服务
    /// </summary>
    /// <param name="servicesOffered">提供的服务</param>
    public void SetServicesOffered(string? servicesOffered)
    {
        FieldValidatorExtension.ValidateFieldLength(servicesOffered, "提供的服务", 1, CampusConsts.MaxServicesOfferedLength);
        ServicesOffered = servicesOffered;
    }

    /// <summary>
    /// 紧急联系人
    /// </summary>
    public string? EmergencyContact { get; private set; }

    /// <summary>
    /// 设置紧急联系人
    /// </summary>
    /// <param name="emergencyContact">紧急联系人</param>
    public void SetEmergencyContact(string? emergencyContact)
    {
        FieldValidatorExtension.ValidateFieldLength(emergencyContact, "紧急联系人", 1, CampusConsts.MaxEmergencyContactLength);
        EmergencyContact = emergencyContact;
    }

    /// <summary>
    /// 紧急联系电话
    /// </summary>
    public string? EmergencyPhone { get; private set; }

    /// <summary>
    /// 设置紧急联系电话
    /// </summary>
    /// <param name="emergencyPhone">紧急联系电话</param>
    public void SetEmergencyPhone(string? emergencyPhone)
    {
        FieldValidatorExtension.ValidateFieldLength(emergencyPhone, "紧急联系电话", 1, CampusConsts.MaxEmergencyPhoneLength);
        EmergencyPhone = emergencyPhone;
    }
}