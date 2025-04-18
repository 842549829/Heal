using Heal.Domain.Entities;
using Heal.Domain.Shared.Constants;
using Heal.Domain.Shared.Extensions;
using Volo.Abp;

namespace Heal.Net.Domain.Bases.Users.Entities;

/// <summary>
/// 医生
/// </summary>
/// <param name="id">id</param>
/// <param name="name">名称</param>
/// <param name="code">编码</param>
/// <param name="idCardType">证件类型</param>
/// <param name="idCardNo">证件号</param>
/// <param name="gender">性别</param>
/// <param name="phone">电话</param>
public class Doctor(Guid id, string name, string code, string idCardType, string idCardNo, string gender, string phone) : FullPersonnelAuditedAggregateRoot<Guid>(id, name, code, idCardType, idCardNo, gender, phone)
{
    /// <summary>
    /// 学历
    /// </summary>
    public string? Education { get; private set; }

    /// <summary>
    /// 毕业学校
    /// </summary>
    public string? MedicalSchool { get; private set; }

    /// <summary>
    /// 专业
    /// </summary>
    public string? Major { get; private set; }

    /// <summary>
    /// 毕业时间
    /// </summary>
    public DateTime? GraduationDate { get; private set; }

    /// <summary>
    /// 学历信息
    /// </summary>
    /// <param name="education">学历</param>
    /// <param name="medicalSchool">毕业学校</param>
    /// <param name="major">专业</param>
    /// <param name="graduationDate">毕业时间</param>
    public void SetEducationalBackground(string? education, string? medicalSchool, string? major, DateTime? graduationDate)
    {
        FieldValidatorExtension.ValidateFieldLength(education, "学历", 1, DoctorConsts.MaxEducationLength);
        FieldValidatorExtension.ValidateFieldLength(medicalSchool, "毕业学校", 1, DoctorConsts.MaxMedicalSchoolLength);
        FieldValidatorExtension.ValidateFieldLength(major, "专业", 1, DoctorConsts.MaxMajorLength);
        Education = education;
        MedicalSchool = medicalSchool;
        Major = major;
        GraduationDate = graduationDate;
    }

    /// <summary>
    /// 医生头像
    /// </summary>
    public string? Avatar { get; private set; }

    /// <summary>
    /// 执业证书编号
    /// </summary>
    public string? PracticeLicenseNumber { get; private set; }

    /// <summary>
    /// 执业范围
    /// </summary>
    public string? PracticeScope { get; private set; }

    /// <summary>
    /// 执业有效期
    /// </summary>
    public DateTime? PracticeValidityDate { get; private set; }

    /// <summary>
    /// 执业经验
    /// </summary>
    public string? PracticeExperience { get; private set; }

    /// <summary>
    /// 工作年限
    /// </summary>
    public string? WorkAgeLimit { get; private set; }

    /// <summary>
    /// 专业领域
    /// </summary>
    public string? Specialization { get; private set; }

    /// <summary>
    /// 研究成果
    /// </summary>
    public string? ResearchResult { get; private set; }

    /// <summary>
    /// 设置工作经验
    /// </summary>
    /// <param name="practiceLicenseNumber">执业证书编号</param>
    /// <param name="practiceScope">执业范围</param>
    /// <param name="practiceValidityDate">执业有效期</param>
    /// <param name="practiceExperience">执业经验</param>
    /// <param name="workAgeLimit">工作年限</param>
    /// <param name="specialization">专业领域</param>
    /// <param name="researchResult">研究成果</param>
    public void SetPracticeInfo(string? practiceLicenseNumber,
        string? practiceScope,
        DateTime? practiceValidityDate,
        string? practiceExperience,
        string? workAgeLimit,
        string? specialization,
        string? researchResult)
    {
        FieldValidatorExtension.ValidateFieldLength(practiceLicenseNumber, "执业证书编号", 1, DoctorConsts.MaxPracticeLicenseNumberLength);
        FieldValidatorExtension.ValidateFieldLength(practiceScope, "执业范围", 1, DoctorConsts.MaxPracticeScopeLength);
        FieldValidatorExtension.ValidateFieldLength(practiceExperience, "执业有效期", 1, DoctorConsts.MaxPracticeExperienceLength);
        FieldValidatorExtension.ValidateFieldLength(specialization, "专业领域", 1, DoctorConsts.MaxSpecializationLength);
        FieldValidatorExtension.ValidateFieldLength(researchResult, "研究成果", 1, DoctorConsts.MaxResearchResultLength);

        PracticeLicenseNumber = practiceLicenseNumber;
        PracticeScope = practiceScope;
        PracticeValidityDate = practiceValidityDate;
        PracticeExperience = practiceExperience;
        Specialization = specialization;
        ResearchResult = researchResult;

        SetWorkAgeLimit(workAgeLimit);
    }

    /// <summary>
    /// 设置工作年限
    /// </summary>
    /// <param name="workAgeLimit">工作年限</param>
    public void SetWorkAgeLimit(string? workAgeLimit)
    {
        Check.NotNull(workAgeLimit, nameof(workAgeLimit));
        FieldValidatorExtension.ValidateFieldLength(workAgeLimit, "工作年限", 1, DoctorConsts.MaxWorkAgeLimitLength);
        WorkAgeLimit = workAgeLimit;
    }

    /// <summary>
    /// 类型(按医疗专业分类)
    /// 内科医生
    /// 外科医生
    /// 儿科医生
    /// 妇产科医生
    /// 精神病医生
    /// 男科医生
    /// 老年病医生
    /// 急诊科医生
    /// 病理科医生
    /// 职业病医生
    /// 心脏病专家
    /// 肿瘤医生
    /// 眼科医生
    /// 全科医生
    /// 康复医学医生
    /// 放射科医生
    /// 影像科医生
    /// 口腔科医生
    /// </summary>
    public string? ProfessionalClassify { get; private set; }

    /// <summary>
    /// 类型(按医生的类型和评价)
    /// 偶像型医生：常在媒体上露面，通过形象建立吸引患者。
    /// 默默经营型医生：通过长期的医疗实践和患者的引介来吸引患者。
    /// 江湖型医生：善于察言观色，能言善道，为达到目的可以不择手段。
    /// </summary>
    public string? EvaluateClassify { get; private set; }

    /// <summary>
    /// 类型(按工作内容和职责分类)
    /// 医师：负责诊断、治疗疾病、预防疾病和保健。
    /// 护士：负责给病人提供护理和护理服务，同时还要负责病人的药物管理，协助医生做化验检查等。
    /// 技术人员：指研究、技术分析、调研、实验、设备维护等技术型的医疗人员。
    /// </summary>
    public string? WorkClassify { get; private set; }

    /// <summary>
    /// 类型(按执业类别分类)
    /// 临床医生
    /// 中医医生
    /// 口腔医生
    /// 预防医学医生
    /// </summary>
    public string? PracticeClassify { get; private set; }

    /// <summary>
    /// 类型(按特质类型分类)
    /// 权威型医生：年长且不重视新信息。
    /// 教授型医生：学术性强，偏好深入讨论。
    /// 投资家型医生：关注市场与经济信息。
    /// 实干家型医生：忙碌，注重实际帮助。
    /// </summary>
    public string? PeculiarityClassify { get; private set; }

    /// <summary>
    /// 类型(按执业范围分类)
    /// 重症医学医生
    /// 内科医生
    /// 外科医生
    /// 妇科医生
    /// 儿科医生
    /// 肿瘤科医生
    /// 超声医学医生
    /// 放射科医生
    /// 影像科医生
    /// </summary>
    public string? ScopeClassify { get; private set; }

    /// <summary>
    /// 类型(按职业发展阶段分类)
    /// 住院医师
    /// 主治医师
    /// 副主任医师
    /// 主任医师
    /// 教授/副教授
    /// </summary>
    public string? OccupationClassify { get; private set; }

    /// <summary>
    /// 设置医生类型
    /// </summary>
    /// <param name="professionalClassify">类型(按医疗专业分类)</param>
    /// <param name="evaluateClassify">类型(按医生的类型和评价)</param>
    /// <param name="workClassify">类型(按工作内容和职责分类)</param>
    /// <param name="practiceClassify">类型(按执业类别分类)</param>
    /// <param name="peculiarityClassify">类型(按特质类型分类)</param>
    /// <param name="scopeClassify">类型(按执业范围分类)</param>
    /// <param name="occupationClassify">类型(按职业发展阶段分类)</param>
    public void SetClassify(string? professionalClassify,
        string? evaluateClassify,
        string? workClassify,
        string? practiceClassify,
        string? peculiarityClassify,
        string? scopeClassify,
        string? occupationClassify)
    {
        FieldValidatorExtension.ValidateFieldLength(professionalClassify, "按医疗专业分类", 1, DoctorConsts.MaxProfessionalClassifyLength);
        FieldValidatorExtension.ValidateFieldLength(evaluateClassify, "按医生的类型和评价", 1, DoctorConsts.MaxEvaluateClassifyLength);
        FieldValidatorExtension.ValidateFieldLength(workClassify, "按工作内容和职责分类", 1, DoctorConsts.MaxWorkClassifyLength);
        FieldValidatorExtension.ValidateFieldLength(practiceClassify, "按执业类别分类", 1, DoctorConsts.MaxPracticeClassifyLength);
        FieldValidatorExtension.ValidateFieldLength(peculiarityClassify, "按特质类型分类", 1, DoctorConsts.MaxPeculiarityClassifyLength);
        FieldValidatorExtension.ValidateFieldLength(scopeClassify, "按执业范围分类", 1, DoctorConsts.MaxScopeClassifyLength);
        FieldValidatorExtension.ValidateFieldLength(occupationClassify, "按职业发展阶段分类", 1, DoctorConsts.MaxOccupationClassifyLength);

        ProfessionalClassify = professionalClassify;
        EvaluateClassify = evaluateClassify;
        WorkClassify = workClassify;
        PracticeClassify = practiceClassify;
        PeculiarityClassify = peculiarityClassify;
        ScopeClassify = scopeClassify;
        SetOccupationClassify(occupationClassify);
    }

    /// <summary>
    /// 设置头像
    /// </summary>
    /// <param name="avatar">avatar</param>
    public void SetAvatar(string? avatar)
    {
        FieldValidatorExtension.ValidateFieldLength(avatar, "头像", 1, DoctorConsts.MaxAvatarLength);
        Avatar = avatar;
    }

    /// <summary>
    /// 设置职业类型
    /// </summary>
    /// <param name="occupationClassify">类型(按职业发展阶段分类)</param>
    public void SetOccupationClassify(string? occupationClassify)
    {
        FieldValidatorExtension.ValidateFieldLength(occupationClassify, "职业类型", 1, DoctorConsts.MaxOccupationClassifyLength);
        OccupationClassify = occupationClassify;
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