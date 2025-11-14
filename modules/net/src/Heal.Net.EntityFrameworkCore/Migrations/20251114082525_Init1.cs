using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heal.Net.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpAuditLogExcelFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true),
                    FileName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogExcelFiles", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpAuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    ApplicationName = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: true, comment: "应用程序名称"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "用户Id"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "用户名"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    TenantName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "租户名称"),
                    ImpersonatorUserId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "模拟用户Id"),
                    ImpersonatorUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "模拟用户名"),
                    ImpersonatorTenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "模拟租户Id"),
                    ImpersonatorTenantName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "模拟租户名称"),
                    ExecutionTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "执行时间"),
                    ExecutionDuration = table.Column<int>(type: "int", nullable: false, comment: "执行耗时"),
                    ClientIpAddress = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "客户端IP"),
                    ClientName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "客户端名称"),
                    ClientId = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "客户端Id"),
                    CorrelationId = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "相关联Id"),
                    BrowserInfo = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "浏览器信息"),
                    HttpMethod = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "请求方式"),
                    Url = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "请求Url"),
                    Exceptions = table.Column<string>(type: "longtext", nullable: true),
                    Comments = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "评论"),
                    HttpStatusCode = table.Column<int>(type: "int", nullable: true, comment: "请求响应状态码"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogs", x => x.Id);
                },
                comment: "审计日志")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpBackgroundJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    ApplicationName = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: true),
                    JobName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "任务名称"),
                    JobArgs = table.Column<string>(type: "longtext", maxLength: 1048576, nullable: false, comment: "任务参数"),
                    TryCount = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0, comment: "重试次数"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    NextTryTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "下次运行时间"),
                    LastTryTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "最后一次运行时间"),
                    IsAbandoned = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否放弃了"),
                    Priority = table.Column<byte>(type: "tinyint unsigned", nullable: false, defaultValue: (byte)15, comment: "优先级"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpBackgroundJobs", x => x.Id);
                },
                comment: "后台任务")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpBlobContainers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "名称"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpBlobContainers", x => x.Id);
                },
                comment: "Blob容器")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpClaimTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "名称"),
                    Required = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否必填"),
                    IsStatic = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否静态"),
                    Regex = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "正则表达式"),
                    RegexDescription = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "正则表达式描述"),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "描述"),
                    ValueType = table.Column<int>(type: "int", nullable: false, comment: "值类型"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpClaimTypes", x => x.Id);
                },
                comment: "声明类型表")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpDoctor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    Education = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "学历"),
                    MedicalSchool = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "毕业院校"),
                    Major = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "专业"),
                    GraduationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "毕业时间"),
                    Avatar = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "头像"),
                    PracticeLicenseNumber = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "执业许可证编号"),
                    PracticeScope = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "执业范围"),
                    PracticeValidityDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "执业有效期"),
                    PracticeExperience = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "执业经历"),
                    WorkAgeLimit = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "工作年限"),
                    Specialization = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "专长"),
                    ResearchResult = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "科研成果"),
                    ProfessionalClassify = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "专业分类"),
                    EvaluateClassify = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "评价分类"),
                    WorkClassify = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "工作分类"),
                    PracticeClassify = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "执业分类"),
                    PeculiarityClassify = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "类型(按特质类型分类)"),
                    ScopeClassify = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "类型(按范围分类)"),
                    OccupationClassify = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "类型(按职业分类)"),
                    IsOpenLogin = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否开放登录"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "最后更新时间"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "最后更新人"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "删除标记"),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "删除人Id"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    Name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "名称"),
                    Code = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "编码"),
                    Pinyin = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false, comment: "拼音"),
                    PinyinFirstLetters = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "拼音首字母"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "启用状态"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序字段"),
                    CreatorName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "创建人名称"),
                    LastModificationName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "最后修改人名称"),
                    DeletionName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "删除人名称"),
                    Describe = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "描述"),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "组织Id"),
                    OrganizationCode = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "组织Code"),
                    NationCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "国家代码"),
                    ProvinceCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "省份代码"),
                    CityCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "城市代码"),
                    DistrictCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "区县代码"),
                    Street = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "街道"),
                    AddressLine = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "详细地址"),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "岁"),
                    Month = table.Column<int>(type: "int", nullable: false, comment: "月"),
                    Day = table.Column<int>(type: "int", nullable: false, comment: "天"),
                    IdCardType = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false, comment: "证件类型"),
                    IdCardNo = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "证件号"),
                    Gender = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "性别"),
                    Birthday = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "生日"),
                    Phone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "手机"),
                    Email = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "邮箱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDoctor", x => x.Id);
                },
                comment: "医生")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpFeatureGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "名称"),
                    DisplayName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "显示名称"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatureGroups", x => x.Id);
                },
                comment: "功能分组定义记录")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    GroupName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "所属分组"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "名称"),
                    ParentName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "父级名称"),
                    DisplayName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "显示名称"),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "描述"),
                    DefaultValue = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "默认值"),
                    IsVisibleToClients = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "对客户端可见"),
                    IsAvailableToHost = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "主机是否可用"),
                    AllowedProviders = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "允许供应商"),
                    ValueType = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: true, comment: "值类型"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatures", x => x.Id);
                },
                comment: "功能定义")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpFeatureValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "名称"),
                    Value = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "值"),
                    ProviderName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "提供者名称"),
                    ProviderKey = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "提供者Key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatureValues", x => x.Id);
                },
                comment: "功能配置表")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpLinkUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    SourceUserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "源用户Id"),
                    SourceTenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "源租户"),
                    TargetUserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "目标用户Id"),
                    TargetTenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "目标租户")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpLinkUsers", x => x.Id);
                },
                comment: "管理用户之间的关联关系")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "父级Id"),
                    Code = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "编码"),
                    DisplayName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "显示名称"),
                    EntityVersion = table.Column<int>(type: "int", nullable: false, comment: "版本"),
                    Address = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "地址"),
                    CoverImage = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true, comment: "封面图片"),
                    Describe = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "备注描述"),
                    Director = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "院长"),
                    Email = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "邮箱"),
                    EstablishmentDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "成立时间"),
                    Facilities = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true, comment: "医院设施"),
                    Introduction = table.Column<string>(type: "varchar(4096)", maxLength: 4096, nullable: true, comment: "医院简介"),
                    IsEmergencyServices = table.Column<bool>(type: "tinyint(1)", nullable: true, comment: "是否提供急诊服务"),
                    IsInsuranceAccepted = table.Column<bool>(type: "tinyint(1)", nullable: true, comment: "是否接受医保"),
                    Latitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "纬度"),
                    Level = table.Column<int>(type: "int", nullable: true, comment: "医院等级"),
                    Longitude = table.Column<decimal>(type: "decimal(18,2)", nullable: true, comment: "经度"),
                    OperatingHours = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "营业时间"),
                    ParkingInformation = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "停车信息"),
                    Phone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "联系电话"),
                    PostalCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "邮政编码"),
                    ServiceHotline = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "服务热线"),
                    TrafficGuide = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "交通指南"),
                    WebsiteUrl = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "官方网站"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "最后更新时间"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "最后更新人"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "删除标记"),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "删除人Id"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpOrganizationUnits_AbpOrganizationUnits_ParentId",
                        column: x => x.ParentId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id");
                },
                comment: "组织机构")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpPatient",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    WorkUnit = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "工作单位"),
                    WorkUnitAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "工作单位地址"),
                    WorkUnitPhone = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "工作单位电话"),
                    EmergencyContact = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "紧急联系人"),
                    EmergencyContactPhone = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "紧急联系人电话"),
                    EmergencyContactRelationship = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "紧急联系人关系"),
                    EmergencyContactAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "紧急联系人地址"),
                    Ethnicity = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "民族"),
                    PoliticalStatus = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "政治面貌"),
                    Nationality = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "国籍"),
                    NativePlace = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "籍贯"),
                    HealthStatus = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "健康状况"),
                    MaritalStatus = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "婚姻状况"),
                    BloodType = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true, comment: "血型"),
                    CurrentAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "现居住地址"),
                    HouseholdAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "户籍地址"),
                    ResidencePermitAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "居住证地址"),
                    ResidencePermitValidity = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "居住证有效期"),
                    IdCardValidity = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "身份证有效期"),
                    IdCardAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "身份证地址"),
                    IdCardFrontPhoto = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "身份证正面照"),
                    IdCardBackPhoto = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "身份证反面照"),
                    IdCardEmblemPhoto = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "身份证国徽照"),
                    IdCardNumber = table.Column<string>(type: "varchar(18)", maxLength: 18, nullable: true, comment: "身份证编号"),
                    MedicalCardNumber = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "医保卡号"),
                    Source = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "来源"),
                    GuardianId = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "监护人ID"),
                    GuardianRelationship = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "监护人关系"),
                    GuardianPhone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "监护人电话"),
                    GuardianAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "监护人地址"),
                    GuardianIdCard = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "监护人身份证号"),
                    GuardianIdCardFrontPhoto = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "监护人身份证正面照"),
                    GuardianIdCardBackPhoto = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "监护人身份证反面照"),
                    GuardianIdCardEmblemPhoto = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "监护人身份证国徽照"),
                    GuardianName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "监护人姓名"),
                    GuardianGender = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true, comment: "监护人性别"),
                    GuardianEthnicity = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "监护人民族"),
                    GuardianPoliticalStatus = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "监护人政治面貌"),
                    GuardianNationality = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "监护人国籍"),
                    GuardianNativePlace = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "监护人籍贯"),
                    GuardianHealthStatus = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "监护人健康状况"),
                    GuardianMaritalStatus = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "监护人婚姻状况"),
                    GuardianBloodType = table.Column<string>(type: "varchar(8)", maxLength: 8, nullable: true, comment: "监护人血型"),
                    GuardianCurrentAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "监护人现居住地"),
                    GuardianHouseholdAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "监护人户籍地"),
                    GuardianResidencePermitAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "监护人居住证地址"),
                    GuardianResidencePermitValidity = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "监护人居住证有效期"),
                    GuardianIdCardValidity = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "监护人身份证有效期"),
                    GuardianIdCardAddress = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "监护人身份证地址"),
                    GuardianIdCardFrontPhotoDuplicate = table.Column<string>(type: "longtext", nullable: true),
                    GuardianIdCardBackPhotoDuplicate = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "监护人身份证反面照"),
                    Alias = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "别名"),
                    MedicalRecordNumber = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "病案号"),
                    IsOpenLogin = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否开通登录功能"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "最后更新时间"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "最后更新人"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "删除标记"),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "删除人Id"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    Name = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "名称"),
                    Code = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "编码"),
                    Pinyin = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false, comment: "拼音"),
                    PinyinFirstLetters = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "拼音首字母"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "启用状态"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序字段"),
                    CreatorName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "创建人名称"),
                    LastModificationName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "最后修改人名称"),
                    DeletionName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "删除人名称"),
                    Describe = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "描述"),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "组织Id"),
                    OrganizationCode = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "组织Code"),
                    NationCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "国家代码"),
                    ProvinceCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "省份代码"),
                    CityCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "城市代码"),
                    DistrictCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "区县代码"),
                    Street = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "街道"),
                    AddressLine = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "详细地址"),
                    Year = table.Column<int>(type: "int", nullable: false, comment: "岁"),
                    Month = table.Column<int>(type: "int", nullable: false, comment: "月"),
                    Day = table.Column<int>(type: "int", nullable: false, comment: "天"),
                    IdCardType = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: false, comment: "证件类型"),
                    IdCardNo = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "证件号"),
                    Gender = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "性别"),
                    Birthday = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "生日"),
                    Phone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false, comment: "手机"),
                    Email = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "邮箱")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPatient", x => x.Id);
                },
                comment: "患者")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpPermissionGrants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "权限名称"),
                    ProviderName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "权限提供者名称(如:角色R)"),
                    ProviderKey = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "权限提供者Key(如:角色key admin)")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissionGrants", x => x.Id);
                },
                comment: "权限管理")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpPermissionGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "权限组名称"),
                    DisplayName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "权限组显示名称"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissionGroups", x => x.Id);
                },
                comment: "权限分组")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    GroupName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "权限组名称"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "权限名称"),
                    ParentName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "权限父级名称"),
                    DisplayName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "权限显示名称"),
                    IsEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否启用"),
                    MultiTenancySide = table.Column<byte>(type: "tinyint unsigned", nullable: false, comment: "供应商多个,隔开"),
                    Providers = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "权限供应者"),
                    StateCheckers = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "权限额外属性"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissions", x => x.Id);
                },
                comment: "权限定义")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "名称"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "标准名称"),
                    IsDefault = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否默认"),
                    IsStatic = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否静态"),
                    IsPublic = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否公共"),
                    EntityVersion = table.Column<int>(type: "int", nullable: false, comment: "版本"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CustomDataPermission = table.Column<string>(type: "varchar(4096)", maxLength: 4096, nullable: false, defaultValue: "", comment: "自定义数据权限"),
                    DataPermission = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "数据权限"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoles", x => x.Id);
                },
                comment: "角色表")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpSecurityLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    ApplicationName = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: true, comment: "应用模块名称"),
                    Identity = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: true, comment: "身份信息"),
                    Action = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: true, comment: "操作Action"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "用户Id"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "用户名"),
                    TenantName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "租户名称"),
                    ClientId = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "客户端Id"),
                    CorrelationId = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "相关Id"),
                    ClientIpAddress = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "客户端IP地址"),
                    BrowserInfo = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "浏览器信息"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSecurityLogs", x => x.Id);
                },
                comment: "身份安全日志")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    SessionId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "会话Id"),
                    Device = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "设备"),
                    DeviceInfo = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "设备信息"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id"),
                    ClientId = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "客户端Id"),
                    IpAddresses = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: true, comment: "Ip地址"),
                    SignedIn = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "用户登录的时间"),
                    LastAccessed = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "用户最近一次访问系统的时间"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSessions", x => x.Id);
                },
                comment: "会话信息")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpSettingDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "名称"),
                    DisplayName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "显示名称"),
                    Description = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "描述"),
                    DefaultValue = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: true, comment: "默认值"),
                    IsVisibleToClients = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Providers = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true, comment: "提供者多个,隔开"),
                    IsInherited = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "此设置是从父作用域继承的吗"),
                    IsEncrypted = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "此设置是否以加密方式存储在数据源中"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSettingDefinitions", x => x.Id);
                },
                comment: "配置定义")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "配置名称"),
                    Value = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: false, comment: "配置值"),
                    ProviderName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "提供者名称"),
                    ProviderKey = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "提供者Key")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSettings", x => x.Id);
                },
                comment: "配置表")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpTenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "名称"),
                    NormalizedName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "标准化的名称（通常是去除空格、转换为小写等处理后的名称）"),
                    EntityVersion = table.Column<int>(type: "int", nullable: false, comment: "实体版本号，用于并发控制或数据版本管理"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "最后更新时间"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "最后更新人"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "删除标记"),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "删除人Id"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenants", x => x.Id);
                },
                comment: "租户")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserCampus",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id"),
                    CampusId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "院区Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserCampus", x => new { x.UserId, x.CampusId });
                },
                comment: "用户院区")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserDelegations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    SourceUserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "源用户Id"),
                    TargetUserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "目标用户Id"),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "开始时间"),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "结束时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserDelegations", x => x.Id);
                },
                comment: "管理用户之间的委托关系")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserDepartment",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id"),
                    DepartmentId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "科室Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserDepartment", x => new { x.UserId, x.DepartmentId });
                },
                comment: "用户科室")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "用户名"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "用户名标准名"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "名"),
                    Surname = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "姓"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "邮箱"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "邮箱标准名称"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "邮箱确认"),
                    PasswordHash = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "密码散列"),
                    SecurityStamp = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "安全票据"),
                    IsExternal = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否外部"),
                    PhoneNumber = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "手机号码"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "手机号码确认"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否活跃"),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "双因素认证"),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true, comment: "锁定到期时间"),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "锁定"),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "错误登录次数"),
                    ShouldChangePasswordOnNextLogin = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否需要更改密码"),
                    EntityVersion = table.Column<int>(type: "int", nullable: false, comment: "版本"),
                    LastPasswordChangeTime = table.Column<DateTimeOffset>(type: "datetime", nullable: true, comment: "最后修改密码时间"),
                    Avatar = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false, defaultValue: "", comment: "头像"),
                    Identity = table.Column<int>(type: "int", nullable: false, defaultValue: 1, comment: "身份标识"),
                    OpenId = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, defaultValue: "", comment: "第三方登录唯一标识"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "最后更新时间"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "最后更新人"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "删除标记"),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "删除人Id"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUsers", x => x.Id);
                },
                comment: "用户表")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OpenIddictApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    ApplicationType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "与应用程序关联的应用程序类型"),
                    ClientId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "与当前应用程序关联的客户端标识符"),
                    ClientSecret = table.Column<string>(type: "longtext", nullable: true, comment: "与当前应用程序关联的客户端密钥。注意：根据创建此实例的应用程序管理器，该属性可能出于安全原因被哈希或加密"),
                    ClientType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "与应用程序关联的客户端类型"),
                    ConsentType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "与当前应用程序关联的同意类型"),
                    DisplayName = table.Column<string>(type: "longtext", nullable: true, comment: "与当前应用程序关联的显示名称"),
                    DisplayNames = table.Column<string>(type: "longtext", nullable: true, comment: "与当前应用程序关联的本地化显示名称，序列化为 JSON 对象"),
                    JsonWebKeySet = table.Column<string>(type: "longtext", nullable: true, comment: "与应用程序关联的 JSON Web Key Set，序列化为 JSON 对象"),
                    Permissions = table.Column<string>(type: "longtext", nullable: true, comment: "与当前应用程序关联的权限，序列化为 JSON 数组"),
                    PostLogoutRedirectUris = table.Column<string>(type: "longtext", nullable: true, comment: "与当前应用程序关联的登出回调 URL，序列化为 JSON 数组"),
                    Properties = table.Column<string>(type: "longtext", nullable: true, comment: "附加属性，序列化为 JSON 对象；如果未与当前应用程序关联任何属性，则为 null"),
                    RedirectUris = table.Column<string>(type: "longtext", nullable: true, comment: "与当前应用程序关联的回调 URL，序列化为 JSON 数组"),
                    Requirements = table.Column<string>(type: "longtext", nullable: true, comment: "与当前应用程序关联的要求，序列化为 JSON 数组"),
                    Settings = table.Column<string>(type: "longtext", nullable: true, comment: "设置，序列化为 JSON 对象"),
                    FrontChannelLogoutUri = table.Column<string>(type: "longtext", nullable: true, comment: "前通道注销Uri"),
                    ClientUri = table.Column<string>(type: "longtext", nullable: true, comment: "指向客户端更多信息的 URI"),
                    LogoUri = table.Column<string>(type: "longtext", nullable: true, comment: "指向客户端标志的 URI"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "最后更新时间"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "最后更新人"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "删除标记"),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "删除人Id"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictApplications", x => x.Id);
                },
                comment: "OpenIddict-应用程序")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OpenIddictScopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    Description = table.Column<string>(type: "longtext", nullable: true, comment: "与当前作用域关联的公开描述"),
                    Descriptions = table.Column<string>(type: "longtext", nullable: true, comment: "与当前作用域关联的本地化公开描述，序列化为 JSON 对象"),
                    DisplayName = table.Column<string>(type: "longtext", nullable: true, comment: "与当前作用域关联的显示名称"),
                    DisplayNames = table.Column<string>(type: "longtext", nullable: true, comment: "与当前作用域关联的本地化显示名称，序列化为 JSON 对象"),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, comment: "与当前作用域关联的唯一名称"),
                    Properties = table.Column<string>(type: "longtext", nullable: true, comment: "附加属性，序列化为 JSON 对象；如果未与当前作用域关联任何属性，则为 null"),
                    Resources = table.Column<string>(type: "longtext", nullable: true, comment: "与当前作用域关联的资源，序列化为 JSON 数组"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "最后更新时间"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "最后更新人"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "删除标记"),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "删除人Id"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictScopes", x => x.Id);
                },
                comment: "OpenIddict-授权范围")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpAuditLogActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    AuditLogId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "AuditLogId"),
                    ServiceName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "服务名称"),
                    MethodName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "方法名称"),
                    Parameters = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true, comment: "参数"),
                    ExecutionTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "执行时间"),
                    ExecutionDuration = table.Column<int>(type: "int", nullable: false, comment: "执行耗时"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpAuditLogActions_AbpAuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalTable: "AbpAuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "审计日志-Action")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpEntityChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    AuditLogId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "AuditLogId"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    ChangeTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "变更时间"),
                    ChangeType = table.Column<byte>(type: "tinyint unsigned", nullable: false, comment: "变更类型"),
                    EntityTenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "审计实体租户Id"),
                    EntityId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "审计实体Id"),
                    EntityTypeFullName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "审计实体全称"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityChanges_AbpAuditLogs_AuditLogId",
                        column: x => x.AuditLogId,
                        principalTable: "AbpAuditLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "审计日志-Entity")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpBlobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    ContainerId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "容器ID"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "名称"),
                    Content = table.Column<byte[]>(type: "longblob", maxLength: 2147483647, nullable: true, comment: "数据"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpBlobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpBlobs_AbpBlobContainers_ContainerId",
                        column: x => x.ContainerId,
                        principalTable: "AbpBlobContainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Blob")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpCampus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    ShortName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "简称"),
                    Building = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "所在大楼"),
                    Floor = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "所在楼层"),
                    RoomNumber = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "所在房间"),
                    Address = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "所在详细地址"),
                    Capacity = table.Column<int>(type: "int", nullable: false, comment: "院区容量"),
                    Phone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "联系电话"),
                    Email = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "联系邮箱"),
                    HeadOfCampus = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "院区负责人"),
                    HeadOfCampusPhone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "院区负责人电话"),
                    HeadOfCampusEmail = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "院区负责人邮箱"),
                    Website = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "院区网站"),
                    ServicesOffered = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "院区提供的服务"),
                    EmergencyContact = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "紧急联系人名称"),
                    EmergencyPhone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "紧急联系人电话"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "最后更新时间"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "最后更新人"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "删除标记"),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "删除人Id"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "名称"),
                    Code = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "编码"),
                    Pinyin = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false, comment: "拼音"),
                    PinyinFirstLetters = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "拼音首字母"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "启用状态"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序字段"),
                    CreatorName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "创建人名称"),
                    LastModificationName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "最后修改人名称"),
                    DeletionName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "删除人名称"),
                    Describe = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "描述"),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "组织Id"),
                    OrganizationCode = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "组织Code"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "父级Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpCampus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpCampus_AbpOrganizationUnits_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "院区")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnitRoles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "角色Id"),
                    OrganizationUnitId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "组织机构Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpOrganizationUnitRoles", x => new { x.OrganizationUnitId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AbpOrganizationUnitRoles_AbpOrganizationUnits_OrganizationUn~",
                        column: x => x.OrganizationUnitId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpOrganizationUnitRoles_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "组织机构角色")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpRoleClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "角色Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    ClaimType = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "声明类型"),
                    ClaimValue = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true, comment: "声明值")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpRoleClaims_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "角色声明表")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpTenantConnectionStrings",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "名称"),
                    Value = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: false, comment: "值")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenantConnectionStrings", x => new { x.TenantId, x.Name });
                    table.ForeignKey(
                        name: "FK_AbpTenantConnectionStrings_AbpTenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "AbpTenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "租户配置")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    ClaimType = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "声明类型"),
                    ClaimValue = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true, comment: "声明值")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpUserClaims_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "用户声明表")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id"),
                    LoginProvider = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "登录提供者"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    ProviderKey = table.Column<string>(type: "varchar(196)", maxLength: 196, nullable: false, comment: "登录提供者Key"),
                    ProviderDisplayName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "登录提供者显示名称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserLogins", x => new { x.UserId, x.LoginProvider });
                    table.ForeignKey(
                        name: "FK_AbpUserLogins_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "外部登录")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserOrganizationUnits",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id"),
                    OrganizationUnitId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "组织机构Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserOrganizationUnits", x => new { x.OrganizationUnitId, x.UserId });
                    table.ForeignKey(
                        name: "FK_AbpUserOrganizationUnits_AbpOrganizationUnits_OrganizationUn~",
                        column: x => x.OrganizationUnitId,
                        principalTable: "AbpOrganizationUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpUserOrganizationUnits_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "用户组织机构关系表")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "角色Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AbpUserRoles_AbpRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AbpRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AbpUserRoles_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "用户角色关系表")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id"),
                    LoginProvider = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "登录提供者"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "名称"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    Value = table.Column<string>(type: "longtext", nullable: true, comment: "值")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AbpUserTokens_AbpUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "外部服务生成的令牌")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OpenIddictAuthorizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    ApplicationId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "与当前授权关联的应用程序的唯一标识符"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "当前授权的 UTC 创建日期"),
                    Properties = table.Column<string>(type: "longtext", nullable: true, comment: "附加属性，序列化为 JSON 对象；如果未与当前授权关联任何属性，则为 null"),
                    Scopes = table.Column<string>(type: "longtext", nullable: true, comment: "与当前授权关联的作用域，序列化为 JSON 数组"),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "当前授权的状态"),
                    Subject = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true, comment: "与当前授权关联的主体"),
                    Type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "当前授权的类型"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictAuthorizations_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                },
                comment: "OpenIddict-授权信息")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpEntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    EntityChangeId = table.Column<Guid>(type: "char(36)", nullable: false),
                    NewValue = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "新值"),
                    OriginalValue = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "旧值"),
                    PropertyName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "属性名称"),
                    PropertyTypeFullName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "属性全称")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpEntityPropertyChanges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpEntityPropertyChanges_AbpEntityChanges_EntityChangeId",
                        column: x => x.EntityChangeId,
                        principalTable: "AbpEntityChanges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "审计日志-Entity-Property")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    CampusId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "所在院区Id"),
                    ShortName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "简称"),
                    DepartmentTypeId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "科室类型Id"),
                    Campuses = table.Column<string>(type: "longtext", nullable: true),
                    Building = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "所在大楼"),
                    Floor = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "所在楼层"),
                    RoomNumber = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "所在房间"),
                    Address = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "所在详细地址"),
                    Capacity = table.Column<int>(type: "int", nullable: false, comment: "科室容量"),
                    Phone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "联系电话"),
                    Email = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "联系邮箱"),
                    HeadOfDepartment = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "科室负责人"),
                    HeadOfDepartmentPhone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "科室负责人电话"),
                    HeadOfDepartmentEmail = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "科室负责人邮箱"),
                    Website = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "科室网站"),
                    ServicesOffered = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "科室提供的服务"),
                    EmergencyContact = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "紧急联系人名称"),
                    EmergencyPhone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "紧急联系人电话"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id"),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "最后更新时间"),
                    LastModifierId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "最后更新人"),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "删除标记"),
                    DeleterId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "删除人Id"),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "名称"),
                    Code = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "编码"),
                    Pinyin = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false, comment: "拼音"),
                    PinyinFirstLetters = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "拼音首字母"),
                    Status = table.Column<int>(type: "int", nullable: false, comment: "启用状态"),
                    Sort = table.Column<int>(type: "int", nullable: false, comment: "排序字段"),
                    CreatorName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "创建人名称"),
                    LastModificationName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "最后修改人名称"),
                    DeletionName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "删除人名称"),
                    Describe = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "描述"),
                    OrganizationId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "组织Id"),
                    OrganizationCode = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "组织Code"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "父级Id")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDepartment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpDepartment_AbpCampus_CampusId",
                        column: x => x.CampusId,
                        principalTable: "AbpCampus",
                        principalColumn: "Id");
                },
                comment: "科室")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OpenIddictTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id"),
                    ApplicationId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "与当前令牌关联的应用程序的唯一标识符"),
                    AuthorizationId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "与当前令牌关联的授权的唯一标识符"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "当前令牌的 UTC 创建日期"),
                    ExpirationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "当前令牌的 UTC 过期日期"),
                    Payload = table.Column<string>(type: "longtext", nullable: true, comment: "当前令牌的有效载荷（如果适用）。注意：此属性仅用于引用令牌，可能出于安全原因被加密"),
                    Properties = table.Column<string>(type: "longtext", nullable: true, comment: "附加属性，序列化为 JSON 对象；如果未与当前令牌关联任何属性，则为 null"),
                    RedemptionDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "当前令牌的 UTC 兑换日期"),
                    ReferenceId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "与当前令牌关联的引用标识符（如果适用）。注意：此属性仅用于引用令牌，可能出于安全原因被哈希或加密"),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "当前令牌的状态"),
                    Subject = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true, comment: "与当前令牌关联的主体"),
                    Type = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true, comment: "当前令牌的类型"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "OpenIddictAuthorizations",
                        principalColumn: "Id");
                },
                comment: "OpenIddict-颁发的Token")
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogActions_AuditLogId",
                table: "AbpAuditLogActions",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogActions_TenantId_ServiceName_MethodName_Execution~",
                table: "AbpAuditLogActions",
                columns: new[] { "TenantId", "ServiceName", "MethodName", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_ExecutionTime",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpAuditLogs_TenantId_UserId_ExecutionTime",
                table: "AbpAuditLogs",
                columns: new[] { "TenantId", "UserId", "ExecutionTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpBackgroundJobs_IsAbandoned_NextTryTime",
                table: "AbpBackgroundJobs",
                columns: new[] { "IsAbandoned", "NextTryTime" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpBlobContainers_TenantId_Name",
                table: "AbpBlobContainers",
                columns: new[] { "TenantId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpBlobs_ContainerId",
                table: "AbpBlobs",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpBlobs_TenantId_ContainerId_Name",
                table: "AbpBlobs",
                columns: new[] { "TenantId", "ContainerId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpCampus_OrganizationId",
                table: "AbpCampus",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpDepartment_CampusId",
                table: "AbpDepartment",
                column: "CampusId");

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
                name: "IX_AbpEntityChanges_AuditLogId",
                table: "AbpEntityChanges",
                column: "AuditLogId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityChanges_TenantId_EntityTypeFullName_EntityId",
                table: "AbpEntityChanges",
                columns: new[] { "TenantId", "EntityTypeFullName", "EntityId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpEntityPropertyChanges_EntityChangeId",
                table: "AbpEntityPropertyChanges",
                column: "EntityChangeId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatureGroups_Name",
                table: "AbpFeatureGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatures_GroupName",
                table: "AbpFeatures",
                column: "GroupName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatures_Name",
                table: "AbpFeatures",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpFeatureValues_Name_ProviderName_ProviderKey",
                table: "AbpFeatureValues",
                columns: new[] { "Name", "ProviderName", "ProviderKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpLinkUsers_SourceUserId_SourceTenantId_TargetUserId_Target~",
                table: "AbpLinkUsers",
                columns: new[] { "SourceUserId", "SourceTenantId", "TargetUserId", "TargetTenantId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnitRoles_RoleId_OrganizationUnitId",
                table: "AbpOrganizationUnitRoles",
                columns: new[] { "RoleId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_Code",
                table: "AbpOrganizationUnits",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_AbpOrganizationUnits_ParentId",
                table: "AbpOrganizationUnits",
                column: "ParentId");

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

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissionGrants_TenantId_Name_ProviderName_ProviderKey",
                table: "AbpPermissionGrants",
                columns: new[] { "TenantId", "Name", "ProviderName", "ProviderKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissionGroups_Name",
                table: "AbpPermissionGroups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissions_GroupName",
                table: "AbpPermissions",
                column: "GroupName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpPermissions_Name",
                table: "AbpPermissions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoleClaims_RoleId",
                table: "AbpRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpRoles_NormalizedName",
                table: "AbpRoles",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpSecurityLogs_TenantId_Action",
                table: "AbpSecurityLogs",
                columns: new[] { "TenantId", "Action" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpSecurityLogs_TenantId_ApplicationName",
                table: "AbpSecurityLogs",
                columns: new[] { "TenantId", "ApplicationName" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpSecurityLogs_TenantId_Identity",
                table: "AbpSecurityLogs",
                columns: new[] { "TenantId", "Identity" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpSecurityLogs_TenantId_UserId",
                table: "AbpSecurityLogs",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpSessions_Device",
                table: "AbpSessions",
                column: "Device");

            migrationBuilder.CreateIndex(
                name: "IX_AbpSessions_SessionId",
                table: "AbpSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpSessions_TenantId_UserId",
                table: "AbpSessions",
                columns: new[] { "TenantId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpSettingDefinitions_Name",
                table: "AbpSettingDefinitions",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpSettings_Name_ProviderName_ProviderKey",
                table: "AbpSettings",
                columns: new[] { "Name", "ProviderName", "ProviderKey" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_Name",
                table: "AbpTenants",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_AbpTenants_NormalizedName",
                table: "AbpTenants",
                column: "NormalizedName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserClaims_UserId",
                table: "AbpUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserLogins_LoginProvider_ProviderKey",
                table: "AbpUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserOrganizationUnits_UserId_OrganizationUnitId",
                table: "AbpUserOrganizationUnits",
                columns: new[] { "UserId", "OrganizationUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUserRoles_RoleId_UserId",
                table: "AbpUserRoles",
                columns: new[] { "RoleId", "UserId" });

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_Email",
                table: "AbpUsers",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_NormalizedEmail",
                table: "AbpUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_NormalizedUserName",
                table: "AbpUsers",
                column: "NormalizedUserName");

            migrationBuilder.CreateIndex(
                name: "IX_AbpUsers_UserName",
                table: "AbpUsers",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplications_ClientId",
                table: "OpenIddictApplications",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type",
                table: "OpenIddictAuthorizations",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictScopes_Name",
                table: "OpenIddictScopes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ApplicationId_Status_Subject_Type",
                table: "OpenIddictTokens",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_AuthorizationId",
                table: "OpenIddictTokens",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                table: "OpenIddictTokens",
                column: "ReferenceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpAuditLogActions");

            migrationBuilder.DropTable(
                name: "AbpAuditLogExcelFiles");

            migrationBuilder.DropTable(
                name: "AbpBackgroundJobs");

            migrationBuilder.DropTable(
                name: "AbpBlobs");

            migrationBuilder.DropTable(
                name: "AbpClaimTypes");

            migrationBuilder.DropTable(
                name: "AbpDepartment");

            migrationBuilder.DropTable(
                name: "AbpDoctor");

            migrationBuilder.DropTable(
                name: "AbpEntityPropertyChanges");

            migrationBuilder.DropTable(
                name: "AbpFeatureGroups");

            migrationBuilder.DropTable(
                name: "AbpFeatures");

            migrationBuilder.DropTable(
                name: "AbpFeatureValues");

            migrationBuilder.DropTable(
                name: "AbpLinkUsers");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnitRoles");

            migrationBuilder.DropTable(
                name: "AbpPatient");

            migrationBuilder.DropTable(
                name: "AbpPermissionGrants");

            migrationBuilder.DropTable(
                name: "AbpPermissionGroups");

            migrationBuilder.DropTable(
                name: "AbpPermissions");

            migrationBuilder.DropTable(
                name: "AbpRoleClaims");

            migrationBuilder.DropTable(
                name: "AbpSecurityLogs");

            migrationBuilder.DropTable(
                name: "AbpSessions");

            migrationBuilder.DropTable(
                name: "AbpSettingDefinitions");

            migrationBuilder.DropTable(
                name: "AbpSettings");

            migrationBuilder.DropTable(
                name: "AbpTenantConnectionStrings");

            migrationBuilder.DropTable(
                name: "AbpUserCampus");

            migrationBuilder.DropTable(
                name: "AbpUserClaims");

            migrationBuilder.DropTable(
                name: "AbpUserDelegations");

            migrationBuilder.DropTable(
                name: "AbpUserDepartment");

            migrationBuilder.DropTable(
                name: "AbpUserLogins");

            migrationBuilder.DropTable(
                name: "AbpUserOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AbpUserRoles");

            migrationBuilder.DropTable(
                name: "AbpUserTokens");

            migrationBuilder.DropTable(
                name: "OpenIddictScopes");

            migrationBuilder.DropTable(
                name: "OpenIddictTokens");

            migrationBuilder.DropTable(
                name: "AbpBlobContainers");

            migrationBuilder.DropTable(
                name: "AbpCampus");

            migrationBuilder.DropTable(
                name: "AbpEntityChanges");

            migrationBuilder.DropTable(
                name: "AbpTenants");

            migrationBuilder.DropTable(
                name: "AbpRoles");

            migrationBuilder.DropTable(
                name: "AbpUsers");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AbpAuditLogs");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications");
        }
    }
}
