namespace Heal.Domain.Shared.Constants;

/// <summary>
/// 患者常量
/// </summary>
public static class PatientConstants
{
    /// <summary>
    /// 工作单位最大长度
    /// </summary>
    public static int MaxWorkUnitLength { get; set; } = 64;

    /// <summary>
    /// 工作单位地址最大长度
    /// </summary>
    public static int MaxWorkUnitAddressLength { get; set; } = 128;

    /// <summary>
    /// 工作单位电话最大长度
    /// </summary>
    public static int MaxWorkUnitPhoneLength { get; set; } = 16;

    /// <summary>
    /// 紧急联系人最大长度
    /// </summary>
    public static int MaxEmergencyContactLength { get; set; } = 32;

    /// <summary>
    /// 紧急联系人电话最大长度
    /// </summary>
    public static int MaxEmergencyContactPhoneLength { get; set; } = 16;

    /// <summary>
    /// 紧急联系人关系最大长度
    /// </summary>
    public static int MaxEmergencyContactRelationshipLength { get; set; } = 16;

    /// <summary>
    /// 紧急联系人地址最大长度
    /// </summary>
    public static int MaxEmergencyContactAddressLength { get; set; } = 128;

    /// <summary>
    /// 民族最大长度
    /// </summary>
    public static int MaxEthnicityLength { get; set; } = 16;

    /// <summary>
    /// 政治面貌最大长度
    /// </summary>
    public static int MaxPoliticalStatusLength { get; set; } = 16;

    /// <summary>
    /// 国籍最大长度
    /// </summary>
    public static int MaxNationalityLength { get; set; } = 32;

    /// <summary>
    /// 籍贯最大长度
    /// </summary>
    public static int MaxNativePlaceLength { get; set; } = 64;

    /// <summary>
    /// 健康状况最大长度
    /// </summary>
    public static int MaxHealthStatusLength { get; set; } = 16;

    /// <summary>
    /// 婚姻状况最大长度
    /// </summary>
    public static int MaxMaritalStatusLength { get; set; } = 16;

    /// <summary>
    /// 血型最大长度
    /// </summary>
    public static int MaxBloodTypeLength { get; set; } = 8;

    /// <summary>
    /// 现住址最大长度
    /// </summary>
    public static int MaxCurrentAddressLength { get; set; } = 128;

    /// <summary>
    /// 户籍地址最大长度
    /// </summary>
    public static int MaxHouseholdAddressLength { get; set; } = 128;

    /// <summary>
    /// 居住证地址最大长度
    /// </summary>
    public static int MaxResidencePermitAddressLength { get; set; } = 128;

    /// <summary>
    /// 居住证有效期最大长度
    /// </summary>
    public static int MaxResidencePermitValidityLength { get; set; } = 32;

    /// <summary>
    /// 身份证有效期最大长度
    /// </summary>
    public static int MaxIdCardValidityLength { get; set; } = 32;

    /// <summary>
    /// 身份证地址最大长度
    /// </summary>
    public static int MaxIdCardAddressLength { get; set; } = 128;

    /// <summary>
    /// 身份证正面照URL最大长度
    /// </summary>
    public static int MaxIdCardFrontPhotoLength { get; set; } = 256;

    /// <summary>
    /// 身份证反面照URL最大长度
    /// </summary>
    public static int MaxIdCardBackPhotoLength { get; set; } = 256;

    /// <summary>
    /// 身份证国徽照URL最大长度
    /// </summary>
    public static int MaxIdCardEmblemPhotoLength { get; set; } = 256;

    /// <summary>
    /// 身份证号码最大长度
    /// </summary>
    public static int MaxIdCardNumberLength { get; set; } = 18;

    /// <summary>
    /// 就诊卡号最大长度
    /// </summary>
    public static int MaxMedicalCardNumberLength { get; set; } = 32;

    /// <summary>
    /// 来源最大长度 (门诊，住院，体检，其他)
    /// </summary>
    public static int MaxSourceLength { get; set; } = 16;

    /// <summary>
    /// 监护人ID最大长度
    /// </summary>
    public static int MaxGuardianIdLength { get; set; } = 32;

    /// <summary>
    /// 监护人姓名最大长度
    /// </summary>
    public static int MaxGuardianNameLength { get; set; } = 32;

    /// <summary>
    /// 监护人性别最大长度
    /// </summary>
    public static int MaxGuardianGenderLength { get; set; } = 8;

    /// <summary>
    /// 监护人民族最大长度
    /// </summary>
    public static int MaxGuardianEthnicityLength { get; set; } = 16;

    /// <summary>
    /// 监护人政治面貌最大长度
    /// </summary>
    public static int MaxGuardianPoliticalStatusLength { get; set; } = 16;

    /// <summary>
    /// 监护人国籍最大长度
    /// </summary>
    public static int MaxGuardianNationalityLength { get; set; } = 32;

    /// <summary>
    /// 监护人籍贯最大长度
    /// </summary>
    public static int MaxGuardianNativePlaceLength { get; set; } = 64;

    /// <summary>
    /// 监护人健康状况最大长度
    /// </summary>
    public static int MaxGuardianHealthStatusLength { get; set; } = 16;

    /// <summary>
    /// 监护人婚姻状况最大长度
    /// </summary>
    public static int MaxGuardianMaritalStatusLength { get; set; } = 16;

    /// <summary>
    /// 监护人血型最大长度
    /// </summary>
    public static int MaxGuardianBloodTypeLength { get; set; } = 8;

    /// <summary>
    /// 监护人现住址最大长度
    /// </summary>
    public static int MaxGuardianCurrentAddressLength { get; set; } = 128;

    /// <summary>
    /// 监护人户籍地址最大长度
    /// </summary>
    public static int MaxGuardianHouseholdAddressLength { get; set; } = 128;

    /// <summary>
    /// 监护人居住证地址最大长度
    /// </summary>
    public static int MaxGuardianResidencePermitAddressLength { get; set; } = 128;

    /// <summary>
    /// 监护人居住证有效期最大长度
    /// </summary>
    public static int MaxGuardianResidencePermitValidityLength { get; set; } = 32;

    /// <summary>
    /// 监护人身份证有效期最大长度
    /// </summary>
    public static int MaxGuardianIdCardValidityLength { get; set; } = 32;

    /// <summary>
    /// 监护人身份证地址最大长度
    /// </summary>
    public static int MaxGuardianIdCardAddressLength { get; set; } = 128;

    /// <summary>
    /// 监护人身份证正面照URL最大长度
    /// </summary>
    public static int MaxGuardianIdCardFrontPhotoLength { get; set; } = 256;

    /// <summary>
    /// 监护人身份证反面照URL最大长度
    /// </summary>
    public static int MaxGuardianIdCardBackPhotoLength { get; set; } = 256;

    /// <summary>
    /// 别名最大长度 (藏族名，外文名，曾用名，其他)
    /// </summary>
    public static int MaxAliasLength { get; set; } = 64;

    /// <summary>
    /// 病案号最大长度
    /// </summary>
    public static int MaxMedicalRecordNumberLength { get; set; } = 32;

    /// <summary>
    /// 监护人身份证国徽照URL最大长度
    /// </summary>
    public static int MaxGuardianIdCardEmblemPhotoLength { get; set; } = 256;

    /// <summary>
    /// 监护人关系最大长度
    /// </summary>
    public static int MaxGuardianRelationshipLength { get; set; } = 16;

    /// <summary>
    /// 监护人手机号最大长度
    /// </summary>
    public static int MaxGuardianPhoneLength { get; set; } = 32;

    /// <summary>
    /// 监护人地址最大长度
    /// </summary>
    public static int MaxGuardianAddressLength { get; set; } = 128;

    /// <summary>
    /// 监护人身份证最大长度
    /// </summary>
    public static int MaxGuardianIdCardLength { get; set; } = 32;

    /// <summary>
    /// 监护人身份证正面照URL重复最大长度
    /// </summary>
    public static int MaxGuardianIdCardFrontPhotoDuplicateLength { get; set; } = 256;

    /// <summary>
    /// 监护人身份证反面照URL重复最大长度
    /// </summary>
    public static int MaxGuardianIdCardBackPhotoDuplicateLength { get; set; } = 256;
}