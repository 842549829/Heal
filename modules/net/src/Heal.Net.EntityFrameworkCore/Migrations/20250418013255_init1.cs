using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heal.Net.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AbpDoctor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    Education = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "学历")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicalSchool = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "毕业院校")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Major = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "专业")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GraduationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "毕业时间"),
                    Avatar = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "头像")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PracticeLicenseNumber = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "执业许可证编号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PracticeScope = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "执业范围")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PracticeValidityDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "执业有效期"),
                    PracticeExperience = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "执业经历")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkAgeLimit = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "工作年限")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Specialization = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "专长")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResearchResult = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "科研成果")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProfessionalClassify = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "专业分类")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EvaluateClassify = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "评价分类")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkClassify = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "工作分类")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PracticeClassify = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "执业分类")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PeculiarityClassify = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "类型(按特质类型分类)")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ScopeClassify = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "类型(按范围分类)")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OccupationClassify = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "类型(按职业分类)")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsOpenLogin = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否开放登录"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "最后更新时间"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "最后更新人", collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "删除标记"),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "删除人Id", collation: "ascii_general_ci"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "编码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pinyin = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false, comment: "拼音")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PinyinFirstLetters = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "拼音首字母")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "启用状态"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序字段"),
                    CreatorName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "创建人名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModificationName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "最后修改人名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletionName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "删除人名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Describe = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "组织Id", collation: "ascii_general_ci"),
                    OrganizationCode = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "组织Code")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NationCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "国家代码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProvinceCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "省份代码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "城市代码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DistrictCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "区县代码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "街道")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "详细地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "岁"),
                    Month = table.Column<int>(type: "int", nullable: false, comment: "月"),
                    Day = table.Column<int>(type: "int", nullable: false, comment: "天"),
                    IdCardType = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false, comment: "证件类型")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCardNo = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "证件号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "性别")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthday = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "生日"),
                    Phone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "手机")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "邮箱")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDoctor", x => x.Id);
                },
                comment: "医生")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpPatient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    WorkUnit = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "工作单位")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkUnitAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "工作单位地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorkUnitPhone = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "工作单位电话")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyContact = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "紧急联系人")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyContactPhone = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "紧急联系人电话")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyContactRelationship = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "紧急联系人关系")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyContactAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "紧急联系人地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ethnicity = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "民族")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PoliticalStatus = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "政治面貌")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nationality = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "国籍")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NativePlace = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "籍贯")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HealthStatus = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "健康状况")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaritalStatus = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "婚姻状况")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BloodType = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true, comment: "血型")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CurrentAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "现居住地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HouseholdAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "户籍地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResidencePermitAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "居住证地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResidencePermitValidity = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "居住证有效期")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCardValidity = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "身份证有效期")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCardAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "身份证地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCardFrontPhoto = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "身份证正面照")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCardBackPhoto = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "身份证反面照")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCardEmblemPhoto = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "身份证国徽照")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCardNumber = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: true, comment: "身份证编号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicalCardNumber = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "医保卡号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Source = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "来源")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianId = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "监护人ID")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianRelationship = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "监护人关系")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianPhone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "监护人电话")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "监护人地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianIdCard = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "监护人身份证号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianIdCardFrontPhoto = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "监护人身份证正面照")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianIdCardBackPhoto = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "监护人身份证反面照")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianIdCardEmblemPhoto = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "监护人身份证国徽照")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "监护人姓名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianGender = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true, comment: "监护人性别")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianEthnicity = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "监护人民族")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianPoliticalStatus = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "监护人政治面貌")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianNationality = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "监护人国籍")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianNativePlace = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "监护人籍贯")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianHealthStatus = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "监护人健康状况")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianMaritalStatus = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "监护人婚姻状况")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianBloodType = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true, comment: "监护人血型")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianCurrentAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "监护人现居住地")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianHouseholdAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "监护人户籍地")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianResidencePermitAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "监护人居住证地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianResidencePermitValidity = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "监护人居住证有效期")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianIdCardValidity = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "监护人身份证有效期")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianIdCardAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "监护人身份证地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianIdCardFrontPhotoDuplicate = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GuardianIdCardBackPhotoDuplicate = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "监护人身份证反面照")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Alias = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "别名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MedicalRecordNumber = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "病案号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsOpenLogin = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否开通登录功能"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id", collation: "ascii_general_ci"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "最后更新时间"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "最后更新人", collation: "ascii_general_ci"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "删除标记"),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "删除人Id", collation: "ascii_general_ci"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Code = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "编码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pinyin = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false, comment: "拼音")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PinyinFirstLetters = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "拼音首字母")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "启用状态"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序字段"),
                    CreatorName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "创建人名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastModificationName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "最后修改人名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeletionName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "删除人名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Describe = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "组织Id", collation: "ascii_general_ci"),
                    OrganizationCode = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "组织Code")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NationCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "国家代码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProvinceCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "省份代码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CityCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "城市代码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DistrictCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "区县代码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Street = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "街道")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AddressLine = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "详细地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "岁"),
                    Month = table.Column<int>(type: "int", nullable: false, comment: "月"),
                    Day = table.Column<int>(type: "int", nullable: false, comment: "天"),
                    IdCardType = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false, comment: "证件类型")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdCardNo = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "证件号")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "性别")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Birthday = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "生日"),
                    Phone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "手机")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "邮箱")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPatient", x => x.Id);
                },
                comment: "患者")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AbpDoctor_Code",
                table: "AbpDoctor",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AbpDoctor_IdCardNo",
                table: "AbpDoctor",
                column: "IdCardNo");

            migrationBuilder.CreateIndex(
                name: "IX_AbpDoctor_Name",
                table: "AbpDoctor",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AbpDoctor_Phone",
                table: "AbpDoctor",
                column: "Phone");

            migrationBuilder.CreateIndex(
                name: "IX_AbpPatient_Code",
                table: "AbpPatient",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AbpPatient_IdCardNo",
                table: "AbpPatient",
                column: "IdCardNo");

            migrationBuilder.CreateIndex(
                name: "IX_AbpPatient_Name",
                table: "AbpPatient",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AbpPatient_Phone",
                table: "AbpPatient",
                column: "Phone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpDoctor");

            migrationBuilder.DropTable(
                name: "AbpPatient");
        }
    }
}
