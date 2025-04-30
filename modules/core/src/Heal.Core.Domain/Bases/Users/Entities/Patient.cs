using Heal.Domain.Entities;

namespace Heal.Core.Domain.Bases.Users.Entities;

/// <summary>
/// 患者
/// </summary>
/// <param name="id">id</param>
/// <param name="name">名称</param>
/// <param name="code">编码</param>
/// <param name="idCardType">证件类型</param>
/// <param name="idCardNo">证件号</param>
/// <param name="gender">性别</param>
/// <param name="phone">电话</param>
public class Patient(Guid id, string name, string code, string idCardType, string idCardNo, string gender, string phone)
    : FullPersonnelAuditedAggregateRoot<Guid>(id, name, code, idCardType, idCardNo, gender, phone)
{
    /// <summary>
    /// 工作单位
    /// </summary>
    public string? WorkUnit { get; private set; }

    /// <summary>
    /// 设置工作单位
    /// </summary>
    /// <param name="workUnit">工作单位</param>
    public void SetWorkUnit(string? workUnit)
    {
        WorkUnit = workUnit;
    }

    /// <summary>
    /// 工作单位地址
    /// </summary>
    public string? WorkUnitAddress { get; private set; }

    /// <summary>
    /// 设置工作单位地址
    /// </summary>
    /// <param name="workUnitAddress">工作单位地址</param>
    public void SetWorkUnitAddress(string? workUnitAddress)
    {
        WorkUnitAddress = workUnitAddress;
    }

    /// <summary>
    /// 工作单位电话
    /// </summary>
    public string? WorkUnitPhone { get; private set; }

    /// <summary>
    /// 设置工作单位电话
    /// </summary>
    /// <param name="workUnitPhone">工作单位电话</param>
    public void SetWorkUnitPhone(string? workUnitPhone)
    {
        WorkUnitPhone = workUnitPhone;
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
        EmergencyContact = emergencyContact;
    }

    /// <summary>
    /// 紧急联系人电话
    /// </summary>
    public string? EmergencyContactPhone { get; private set; }

    /// <summary>
    /// 设置紧急联系人电话
    /// </summary>
    /// <param name="emergencyContactPhone">紧急联系人电话</param>
    public void SetEmergencyContactPhone(string? emergencyContactPhone)
    {
        EmergencyContactPhone = emergencyContactPhone;
    }

    /// <summary>
    /// 紧急联系人关系
    /// </summary>
    public string? EmergencyContactRelationship { get; private set; }

    /// <summary>
    /// 设置紧急联系人关系
    /// </summary>
    /// <param name="emergencyContactRelationship">紧急联系人关系</param>
    public void SetEmergencyContactRelationship(string? emergencyContactRelationship)
    {
        EmergencyContactRelationship = emergencyContactRelationship;
    }

    /// <summary>
    /// 紧急联系人地址
    /// </summary>
    public string? EmergencyContactAddress { get; private set; }

    /// <summary>
    /// 设置紧急联系人地址
    /// </summary>
    /// <param name="emergencyContactAddress">紧急联系人地址</param>
    public void SetEmergencyContactAddress(string? emergencyContactAddress)
    {
        EmergencyContactAddress = emergencyContactAddress;
    }

    /// <summary>
    /// 民族
    /// </summary>
    public string? Ethnicity { get; private set; }

    /// <summary>
    /// 设置民族
    /// </summary>
    /// <param name="ethnicity">民族</param>
    public void SetEthnicity(string? ethnicity)
    {
        Ethnicity = ethnicity;
    }

    /// <summary>
    /// 政治面貌
    /// </summary>
    public string? PoliticalStatus { get; private set; }

    /// <summary>
    /// 设置政治面貌
    /// </summary>
    /// <param name="politicalStatus">政治面貌</param>
    public void SetPoliticalStatus(string? politicalStatus)
    {
        PoliticalStatus = politicalStatus;
    }

    /// <summary>
    /// 国籍
    /// </summary>
    public string? Nationality { get; private set; }

    /// <summary>
    /// 设置国籍
    /// </summary>
    /// <param name="nationality">国籍</param>
    public void SetNationality(string? nationality)
    {
        Nationality = nationality;
    }

    /// <summary>
    /// 籍贯
    /// </summary>
    public string? NativePlace { get; private set; }

    /// <summary>
    /// 设置籍贯
    /// </summary>
    /// <param name="nativePlace">籍贯</param>
    public void SetNativePlace(string? nativePlace)
    {
        NativePlace = nativePlace;
    }

    /// <summary>
    /// 健康状况
    /// </summary>
    public string? HealthStatus { get; private set; }

    /// <summary>
    /// 设置健康状况
    /// </summary>
    /// <param name="healthStatus">健康状况</param>
    public void SetHealthStatus(string? healthStatus)
    {
        HealthStatus = healthStatus;
    }

    /// <summary>
    /// 婚姻状况
    /// </summary>
    public string? MaritalStatus { get; private set; }

    /// <summary>
    /// 设置婚姻状况
    /// </summary>
    /// <param name="maritalStatus">婚姻状况</param>
    public void SetMaritalStatus(string? maritalStatus)
    {
        MaritalStatus = maritalStatus;
    }

    /// <summary>
    /// 血型
    /// </summary>
    public string? BloodType { get; private set; }

    /// <summary>
    /// 设置血型
    /// </summary>
    /// <param name="bloodType">血型</param>
    public void SetBloodType(string? bloodType)
    {
        BloodType = bloodType;
    }

    /// <summary>
    /// 现住址
    /// </summary>
    public string? CurrentAddress { get; private set; }

    /// <summary>
    /// 设置现住址
    /// </summary>
    /// <param name="currentAddress">现住址</param>
    public void SetCurrentAddress(string? currentAddress)
    {
        CurrentAddress = currentAddress;
    }

    /// <summary>
    /// 户籍地址
    /// </summary>
    public string? HouseholdAddress { get; private set; }

    /// <summary>
    /// 设置户籍地址
    /// </summary>
    /// <param name="householdAddress">户籍地址</param>
    public void SetHouseholdAddress(string? householdAddress)
    {
        HouseholdAddress = householdAddress;
    }

    /// <summary>
    /// 居住证地址
    /// </summary>
    public string? ResidencePermitAddress { get; private set; }

    /// <summary>
    /// 设置居住证地址
    /// </summary>
    /// <param name="residencePermitAddress">居住证地址</param>
    public void SetResidencePermitAddress(string? residencePermitAddress)
    {
        ResidencePermitAddress = residencePermitAddress;
    }

    /// <summary>
    /// 居住证有效期
    /// </summary>
    public string? ResidencePermitValidity { get; private set; }

    /// <summary>
    /// 设置居住证有效期
    /// </summary>
    /// <param name="residencePermitValidity">居住证有效期</param>
    public void SetResidencePermitValidity(string? residencePermitValidity)
    {
        ResidencePermitValidity = residencePermitValidity;
    }

    /// <summary>
    /// 身份证有效期
    /// </summary>
    public string? IdCardValidity { get; private set; }

    /// <summary>
    /// 设置身份证有效期
    /// </summary>
    /// <param name="idCardValidity">身份证有效期</param>
    public void SetIdCardValidity(string? idCardValidity)
    {
        IdCardValidity = idCardValidity;
    }

    /// <summary>
    /// 身份证地址
    /// </summary>
    public string? IdCardAddress { get; private set; }

    /// <summary>
    /// 设置身份证地址
    /// </summary>
    /// <param name="idCardAddress">身份证地址</param>
    public void SetIdCardAddress(string? idCardAddress)
    {
        IdCardAddress = idCardAddress;
    }

    /// <summary>
    /// 身份证正面照
    /// </summary>
    public string? IdCardFrontPhoto { get; private set; }

    /// <summary>
    /// 设置身份证正面照
    /// </summary>
    /// <param name="idCardFrontPhoto">身份证正面照</param>
    public void SetIdCardFrontPhoto(string? idCardFrontPhoto)
    {
        IdCardFrontPhoto = idCardFrontPhoto;
    }

    /// <summary>
    /// 身份证反面照
    /// </summary>
    public string? IdCardBackPhoto { get; private set; }

    /// <summary>
    /// 设置身份证反面照
    /// </summary>
    /// <param name="idCardBackPhoto">身份证反面照</param>
    public void SetIdCardBackPhoto(string? idCardBackPhoto)
    {
        IdCardBackPhoto = idCardBackPhoto;
    }

    /// <summary>
    /// 身份证国徽照
    /// </summary>
    public string? IdCardEmblemPhoto { get; private set; }

    /// <summary>
    /// 设置身份证国徽照
    /// </summary>
    /// <param name="idCardEmblemPhoto">身份证国徽照</param>
    public void SetIdCardEmblemPhoto(string? idCardEmblemPhoto)
    {
        IdCardEmblemPhoto = idCardEmblemPhoto;
    }

    /// <summary>
    /// 身份证号码
    /// </summary>
    public string? IdCardNumber { get; private set; }

    /// <summary>
    /// 设置身份证号码
    /// </summary>
    /// <param name="idCardNumber">身份证号码</param>
    public void SetIdCardNumber(string? idCardNumber)
    {
        IdCardNumber = idCardNumber;
    }

    /// <summary>
    /// 就诊卡号
    /// </summary>
    public string? MedicalCardNumber { get; private set; }

    /// <summary>
    /// 设置就诊卡号
    /// </summary>
    /// <param name="medicalCardNumber">就诊卡号</param>
    public void SetMedicalCardNumber(string? medicalCardNumber)
    {
        MedicalCardNumber = medicalCardNumber;
    }

    /// <summary>
    /// 来源 (门诊，住院，体检，其他)
    /// </summary>
    public string? Source { get; private set; }

    /// <summary>
    /// 设置来源
    /// </summary>
    /// <param name="source">来源</param>
    public void SetSource(string? source)
    {
        Source = source;
    }

    /// <summary>
    /// 监护人Id
    /// </summary>
    public string? GuardianId { get; private set; }

    /// <summary>
    /// 设置监护人Id
    /// </summary>
    /// <param name="guardianId">监护人Id</param>
    public void SetGuardianId(string? guardianId)
    {
        GuardianId = guardianId;
    }

    /// <summary>
    /// 监护人关系
    /// </summary>
    public string? GuardianRelationship { get; private set; }

    /// <summary>
    /// 设置监护人关系
    /// </summary>
    /// <param name="guardianRelationship">监护人关系</param>
    public void SetGuardianRelationship(string? guardianRelationship)
    {
        GuardianRelationship = guardianRelationship;
    }

    /// <summary>
    /// 监护人电话
    /// </summary>
    public string? GuardianPhone { get; private set; }

    /// <summary>
    /// 设置监护人电话
    /// </summary>
    /// <param name="guardianPhone">监护人电话</param>
    public void SetGuardianPhone(string? guardianPhone)
    {
        GuardianPhone = guardianPhone;
    }

    /// <summary>
    /// 监护人地址
    /// </summary>
    public string? GuardianAddress { get; private set; }

    /// <summary>
    /// 设置监护人地址
    /// </summary>
    /// <param name="guardianAddress">监护人地址</param>
    public void SetGuardianAddress(string? guardianAddress)
    {
        GuardianAddress = guardianAddress;
    }

    /// <summary>
    /// 监护人身份证
    /// </summary>
    public string? GuardianIdCard { get; private set; }

    /// <summary>
    /// 设置监护人身份证
    /// </summary>
    /// <param name="guardianIdCard">监护人身份证</param>
    public void SetGuardianIdCard(string? guardianIdCard)
    {
        GuardianIdCard = guardianIdCard;
    }

    /// <summary>
    /// 监护人身份证正面照
    /// </summary>
    public string? GuardianIdCardFrontPhoto { get; private set; }

    /// <summary>
    /// 设置监护人身份证正面照
    /// </summary>
    /// <param name="guardianIdCardFrontPhoto">监护人身份证正面照</param>
    public void SetGuardianIdCardFrontPhoto(string? guardianIdCardFrontPhoto)
    {
        GuardianIdCardFrontPhoto = guardianIdCardFrontPhoto;
    }

    /// <summary>
    /// 监护人身份证反面照
    /// </summary>
    public string? GuardianIdCardBackPhoto { get; private set; }

    /// <summary>
    /// 设置监护人身份证反面照
    /// </summary>
    /// <param name="guardianIdCardBackPhoto">监护人身份证反面照</param>
    public void SetGuardianIdCardBackPhoto(string? guardianIdCardBackPhoto)
    {
        GuardianIdCardBackPhoto = guardianIdCardBackPhoto;
    }

    /// <summary>
    /// 监护人身份证国徽照
    /// </summary>
    public string? GuardianIdCardEmblemPhoto { get; private set; }

    /// <summary>
    /// 设置监护人身份证国徽照
    /// </summary>
    /// <param name="guardianIdCardEmblemPhoto">监护人身份证国徽照</param>
    public void SetGuardianIdCardEmblemPhoto(string? guardianIdCardEmblemPhoto)
    {
        GuardianIdCardEmblemPhoto = guardianIdCardEmblemPhoto;
    }

    /// <summary>
    /// 监护人姓名
    /// </summary>
    public string? GuardianName { get; private set; }

    /// <summary>
    /// 设置监护人姓名
    /// </summary>
    /// <param name="guardianName">监护人姓名</param>
    public void SetGuardianName(string? guardianName)
    {
        GuardianName = guardianName;
    }

    /// <summary>
    /// 监护人性别
    /// </summary>
    public string? GuardianGender { get; private set; }

    /// <summary>
    /// 设置监护人性别
    /// </summary>
    /// <param name="guardianGender">监护人性别</param>
    public void SetGuardianGender(string? guardianGender)
    {
        GuardianGender = guardianGender;
    }

    /// <summary>
    /// 监护人民族
    /// </summary>
    public string? GuardianEthnicity { get; private set; }

    /// <summary>
    /// 设置监护人民族
    /// </summary>
    /// <param name="guardianEthnicity">监护人民族</param>
    public void SetGuardianEthnicity(string? guardianEthnicity)
    {
        GuardianEthnicity = guardianEthnicity;
    }

    /// <summary>
    /// 监护人政治面貌
    /// </summary>
    public string? GuardianPoliticalStatus { get; private set; }

    /// <summary>
    /// 设置监护人政治面貌
    /// </summary>
    /// <param name="guardianPoliticalStatus">监护人政治面貌</param>
    public void SetGuardianPoliticalStatus(string? guardianPoliticalStatus)
    {
        GuardianPoliticalStatus = guardianPoliticalStatus;
    }

    /// <summary>
    /// 监护人国籍
    /// </summary>
    public string? GuardianNationality { get; private set; }

    /// <summary>
    /// 设置监护人国籍
    /// </summary>
    /// <param name="guardianNationality">监护人国籍</param>
    public void SetGuardianNationality(string? guardianNationality)
    {
        GuardianNationality = guardianNationality;
    }

    /// <summary>
    /// 监护人籍贯
    /// </summary>
    public string? GuardianNativePlace { get; private set; }

    /// <summary>
    /// 设置监护人籍贯
    /// </summary>
    /// <param name="guardianNativePlace">监护人籍贯</param>
    public void SetGuardianNativePlace(string? guardianNativePlace)
    {
        GuardianNativePlace = guardianNativePlace;
    }

    /// <summary>
    /// 监护人健康状况
    /// </summary>
    public string? GuardianHealthStatus { get; private set; }

    /// <summary>
    /// 设置监护人健康状况
    /// </summary>
    /// <param name="guardianHealthStatus">监护人健康状况</param>
    public void SetGuardianHealthStatus(string? guardianHealthStatus)
    {
        GuardianHealthStatus = guardianHealthStatus;
    }

    /// <summary>
    /// 监护人婚姻状况
    /// </summary>
    public string? GuardianMaritalStatus { get; private set; }

    /// <summary>
    /// 设置监护人婚姻状况
    /// </summary>
    /// <param name="guardianMaritalStatus">监护人婚姻状况</param>
    public void SetGuardianMaritalStatus(string? guardianMaritalStatus)
    {
        GuardianMaritalStatus = guardianMaritalStatus;
    }

    /// <summary>
    /// 监护人血型
    /// </summary>
    public string? GuardianBloodType { get; private set; }

    /// <summary>
    /// 设置监护人血型
    /// </summary>
    /// <param name="guardianBloodType">监护人血型</param>
    public void SetGuardianBloodType(string? guardianBloodType)
    {
        GuardianBloodType = guardianBloodType;
    }

    /// <summary>
    /// 监护人现住址
    /// </summary>
    public string? GuardianCurrentAddress { get; private set; }

    /// <summary>
    /// 设置监护人现住址
    /// </summary>
    /// <param name="guardianCurrentAddress">监护人现住址</param>
    public void SetGuardianCurrentAddress(string? guardianCurrentAddress)
    {
        GuardianCurrentAddress = guardianCurrentAddress;
    }

    /// <summary>
    /// 监护人户籍地址
    /// </summary>
    public string? GuardianHouseholdAddress { get; private set; }

    /// <summary>
    /// 设置监护人户籍地址
    /// </summary>
    /// <param name="guardianHouseholdAddress">监护人户籍地址</param>
    public void SetGuardianHouseholdAddress(string? guardianHouseholdAddress)
    {
        GuardianHouseholdAddress = guardianHouseholdAddress;
    }

    /// <summary>
    /// 监护人居住证地址
    /// </summary>
    public string? GuardianResidencePermitAddress { get; private set; }

    /// <summary>
    /// 设置监护人居住证地址
    /// </summary>
    /// <param name="guardianResidencePermitAddress">监护人居住证地址</param>
    public void SetGuardianResidencePermitAddress(string? guardianResidencePermitAddress)
    {
        GuardianResidencePermitAddress = guardianResidencePermitAddress;
    }

    /// <summary>
    /// 监护人居住证有效期
    /// </summary>
    public string? GuardianResidencePermitValidity { get; private set; }

    /// <summary>
    /// 设置监护人居住证有效期
    /// </summary>
    /// <param name="guardianResidencePermitValidity">监护人居住证有效期</param>
    public void SetGuardianResidencePermitValidity(string? guardianResidencePermitValidity)
    {
        GuardianResidencePermitValidity = guardianResidencePermitValidity;
    }

    /// <summary>
    /// 监护人身份证有效期
    /// </summary>
    public string? GuardianIdCardValidity { get; private set; }

    /// <summary>
    /// 设置监护人身份证有效期
    /// </summary>
    /// <param name="guardianIdCardValidity">监护人身份证有效期</param>
    public void SetGuardianIdCardValidity(string? guardianIdCardValidity)
    {
        GuardianIdCardValidity = guardianIdCardValidity;
    }

    /// <summary>
    /// 监护人身份证地址
    /// </summary>
    public string? GuardianIdCardAddress { get; private set; }

    /// <summary>
    /// 设置监护人身份证地址
    /// </summary>
    /// <param name="guardianIdCardAddress">监护人身份证地址</param>
    public void SetGuardianIdCardAddress(string? guardianIdCardAddress)
    {
        GuardianIdCardAddress = guardianIdCardAddress;
    }

    /// <summary>
    /// 监护人身份证正面照
    /// </summary>
    public string? GuardianIdCardFrontPhotoDuplicate { get; private set; }

    /// <summary>
    /// 设置监护人身份证正面照
    /// </summary>
    /// <param name="guardianIdCardFrontPhotoDuplicate">监护人身份证正面照</param>
    public void SetGuardianIdCardFrontPhotoDuplicate(string? guardianIdCardFrontPhotoDuplicate)
    {
        GuardianIdCardFrontPhotoDuplicate = guardianIdCardFrontPhotoDuplicate;
    }

    /// <summary>
    /// 监护人身份证反面照
    /// </summary>
    public string? GuardianIdCardBackPhotoDuplicate { get; private set; }

    /// <summary>
    /// 设置监护人身份证反面照
    /// </summary>
    /// <param name="guardianIdCardBackPhotoDuplicate">监护人身份证反面照</param>
    public void SetGuardianIdCardBackPhotoDuplicate(string? guardianIdCardBackPhotoDuplicate)
    {
        GuardianIdCardBackPhotoDuplicate = guardianIdCardBackPhotoDuplicate;
    }

    /// <summary>
    /// 别名(藏族名，外文名，曾用名，其他)
    /// </summary>
    public string? Alias { get; private set; }

    /// <summary>
    /// 设置别名
    /// </summary>
    /// <param name="alias">别名</param>
    public void SetAlias(string? alias)
    {
        Alias = alias;
    }

    /// <summary>
    /// 病案号
    /// </summary>
    public string? MedicalRecordNumber { get; private set; }

    /// <summary>
    /// 设置病案号
    /// </summary>
    /// <param name="medicalRecordNumber">病案号</param>
    public void SetMedicalRecordNumber(string? medicalRecordNumber)
    {
        MedicalRecordNumber = medicalRecordNumber;
    }

    /// <summary>
    /// 是否开通登录功能
    /// </summary>
    public bool IsOpenLogin { get; private set; } 

    /// <summary>
    /// 设置是否开通登录功能
    /// </summary>
    /// <param name="isOpenLogin">是否开通登录功能</param>
    public void SetOpenLogin(bool isOpenLogin)
    {
        IsOpenLogin = isOpenLogin;
    }
}