namespace Heal.Domain.Shared.Constants;

/// <summary>
/// Doctor Constants
/// </summary>
public static class DoctorConstants
{
    /// <summary>
    /// 学历最大长度
    /// </summary>
    public static int MaxEducationLength { get; set; } = 16;

    /// <summary>
    /// 毕业学校最大长度
    /// </summary>
    public static int MaxMedicalSchoolLength { get; set; } = 64;

    /// <summary>
    /// 专业最大长度
    /// </summary>
    public static int MaxMajorLength { get; set; } = 64;

    /// <summary>
    /// 医生头像URL最大长度
    /// </summary>
    public static int MaxAvatarLength { get; set; } = 256;

    /// <summary>
    /// 执业证书编号最大长度
    /// </summary>
    public static int MaxPracticeLicenseNumberLength { get; set; } = 32;

    /// <summary>
    /// 执业范围最大长度
    /// </summary>
    public static int MaxPracticeScopeLength { get; set; } = 128;

    /// <summary>
    /// 执业经验描述最大长度
    /// </summary>
    public static int MaxPracticeExperienceLength { get; set; } = 512;

    /// <summary>
    /// 工作年限最大长度
    /// </summary>
    public static int MaxWorkAgeLimitLength { get; set; } = 16;

    /// <summary>
    /// 专业领域最大长度
    /// </summary>
    public static int MaxSpecializationLength { get; set; } = 128;

    /// <summary>
    /// 研究成果最大长度
    /// </summary>
    public static int MaxResearchResultLength { get; set; } = 512;

    /// <summary>
    /// 类型(按医疗专业分类)最大长度
    /// </summary>
    public static int MaxProfessionalClassifyLength { get; set; } = 64;

    /// <summary>
    /// 类型(按医生的类型和评价)最大长度
    /// </summary>
    public static int MaxEvaluateClassifyLength { get; set; } = 64;

    /// <summary>
    /// 类型(按工作内容和职责分类)最大长度
    /// </summary>
    public static int MaxWorkClassifyLength { get; set; } = 64;

    /// <summary>
    /// 类型(按执业类别分类)最大长度
    /// </summary>
    public static int MaxPracticeClassifyLength { get; set; } = 64;

    /// <summary>
    /// 类型(按特质类型分类)最大长度
    /// </summary>
    public static int MaxPeculiarityClassifyLength { get; set; } = 64;

    /// <summary>
    /// 类型(按执业范围分类)最大长度
    /// </summary>
    public static int MaxScopeClassifyLength { get; set; } = 64;

    /// <summary>
    /// 类型(按职业发展阶段分类)最大长度
    /// </summary>
    public static int MaxOccupationClassifyLength { get; set; } = 64;
}