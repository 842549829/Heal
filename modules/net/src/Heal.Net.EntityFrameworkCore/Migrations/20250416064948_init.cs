﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heal.Net.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpAuditLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    ApplicationName = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: true, comment: "应用程序名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "用户Id", collation: "ascii_general_ci"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "用户名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    TenantName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "租户名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImpersonatorUserId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "模拟用户Id", collation: "ascii_general_ci"),
                    ImpersonatorUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "模拟用户名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImpersonatorTenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "模拟租户Id", collation: "ascii_general_ci"),
                    ImpersonatorTenantName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "模拟租户名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExecutionTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "执行时间"),
                    ExecutionDuration = table.Column<int>(type: "int", nullable: false, comment: "执行耗时"),
                    ClientIpAddress = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "客户端IP")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "客户端名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientId = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "客户端Id")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorrelationId = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "相关联Id")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BrowserInfo = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "浏览器信息")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HttpMethod = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "请求方式")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Url = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "请求Url")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Exceptions = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Comments = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "评论")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HttpStatusCode = table.Column<int>(type: "int", nullable: true, comment: "请求响应状态码"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpAuditLogs", x => x.Id);
                },
                comment: "审计日志")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpBackgroundJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    JobName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "任务名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JobArgs = table.Column<string>(type: "longtext", maxLength: 1048576, nullable: false, comment: "任务参数")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TryCount = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0, comment: "重试次数"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    NextTryTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "下次运行时间"),
                    LastTryTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "最后一次运行时间"),
                    IsAbandoned = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否放弃了"),
                    Priority = table.Column<byte>(type: "tinyint unsigned", nullable: false, defaultValue: (byte)15, comment: "优先级"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpBackgroundJobs", x => x.Id);
                },
                comment: "后台任务")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpBlobContainers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpBlobContainers", x => x.Id);
                },
                comment: "Blob容器")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpCampus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    ShortName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "简称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Building = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "所在大楼")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Floor = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "所在楼层")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoomNumber = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "所在房间")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "所在详细地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacity = table.Column<int>(type: "int", nullable: false, comment: "院区容量"),
                    Phone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "联系电话")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "联系邮箱")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeadOfCampus = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "院区负责人")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeadOfCampusPhone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "院区负责人电话")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeadOfCampusEmail = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "院区负责人邮箱")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Website = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "院区网站")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServicesOffered = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "院区提供的服务")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyContact = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "紧急联系人名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyPhone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "紧急联系人电话")
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "名称")
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
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "父级Id", collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpCampus", x => x.Id);
                },
                comment: "院区")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpClaimTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Required = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否必填"),
                    IsStatic = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否静态"),
                    Regex = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "正则表达式")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RegexDescription = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "正则表达式描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValueType = table.Column<int>(type: "int", nullable: false, comment: "值类型"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpClaimTypes", x => x.Id);
                },
                comment: "声明类型表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpDepartment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    CampusId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "所在院区Id", collation: "ascii_general_ci"),
                    ShortName = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "简称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartmentTypeId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "科室类型Id", collation: "ascii_general_ci"),
                    Campuses = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Building = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "所在大楼")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Floor = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "所在楼层")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoomNumber = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "所在房间")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "所在详细地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacity = table.Column<int>(type: "int", nullable: false, comment: "科室容量"),
                    Phone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "联系电话")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "联系邮箱")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeadOfDepartment = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "科室负责人")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeadOfDepartmentPhone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "科室负责人电话")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeadOfDepartmentEmail = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "科室负责人邮箱")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Website = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "科室网站")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServicesOffered = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "科室提供的服务")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyContact = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "紧急联系人名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmergencyPhone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "紧急联系人电话")
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "名称")
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
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "父级Id", collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDepartment", x => x.Id);
                },
                comment: "科室")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpFeatureGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "显示名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatureGroups", x => x.Id);
                },
                comment: "功能分组定义记录")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    GroupName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "所属分组")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "父级名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "显示名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DefaultValue = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "默认值")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsVisibleToClients = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "对客户端可见"),
                    IsAvailableToHost = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "主机是否可用"),
                    AllowedProviders = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "允许供应商")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ValueType = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: true, comment: "值类型")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatures", x => x.Id);
                },
                comment: "功能定义")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpFeatureValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "值")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "提供者名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "提供者Key")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpFeatureValues", x => x.Id);
                },
                comment: "功能配置表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpLinkUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    SourceUserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "源用户Id", collation: "ascii_general_ci"),
                    SourceTenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "源租户", collation: "ascii_general_ci"),
                    TargetUserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "目标用户Id", collation: "ascii_general_ci"),
                    TargetTenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "目标租户", collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpLinkUsers", x => x.Id);
                },
                comment: "管理用户之间的关联关系")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "父级Id", collation: "ascii_general_ci"),
                    Code = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "编码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "显示名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityVersion = table.Column<int>(type: "int", nullable: false, comment: "版本"),
                    Address = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CoverImage = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true, comment: "封面图片")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Describe = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "备注描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Director = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "院长")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "邮箱")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EstablishmentDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "成立时间"),
                    Facilities = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true, comment: "医院设施")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Introduction = table.Column<string>(type: "varchar(4096)", maxLength: 4096, nullable: true, comment: "医院简介")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEmergencyServices = table.Column<bool>(type: "tinyint(1)", nullable: true, comment: "是否提供急诊服务"),
                    IsInsuranceAccepted = table.Column<bool>(type: "tinyint(1)", nullable: true, comment: "是否接受医保"),
                    Latitude = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "纬度"),
                    Level = table.Column<int>(type: "int", nullable: true, comment: "医院等级"),
                    Longitude = table.Column<decimal>(type: "decimal(65,30)", nullable: true, comment: "经度"),
                    OperatingHours = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "营业时间"),
                    ParkingInformation = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "停车信息")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "联系电话")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostalCode = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "邮政编码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ServiceHotline = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: true, comment: "服务热线")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrafficGuide = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "交通指南")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WebsiteUrl = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "官方网站")
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpPermissionGrants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "权限名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "权限提供者名称(如:角色R)")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "权限提供者Key(如:角色key admin)")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissionGrants", x => x.Id);
                },
                comment: "权限管理")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpPermissionGroups",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "权限组名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "权限组显示名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissionGroups", x => x.Id);
                },
                comment: "权限分组")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpPermissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    GroupName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "权限组名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "权限名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "权限父级名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "权限显示名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否启用"),
                    MultiTenancySide = table.Column<byte>(type: "tinyint unsigned", nullable: false, comment: "供应商多个,隔开"),
                    Providers = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "权限供应者")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StateCheckers = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "权限额外属性")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpPermissions", x => x.Id);
                },
                comment: "权限定义")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "标准名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDefault = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否默认"),
                    IsStatic = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否静态"),
                    IsPublic = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否公共"),
                    EntityVersion = table.Column<int>(type: "int", nullable: false, comment: "版本"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CustomDataPermission = table.Column<string>(type: "varchar(4096)", maxLength: 4096, nullable: false, defaultValue: "", comment: "自定义数据权限")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DataPermission = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "数据权限"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpRoles", x => x.Id);
                },
                comment: "角色表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpSecurityLogs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    ApplicationName = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: true, comment: "应用模块名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Identity = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: true, comment: "身份信息")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Action = table.Column<string>(type: "varchar(96)", maxLength: 96, nullable: true, comment: "操作Action")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "用户Id", collation: "ascii_general_ci"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "用户名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "租户名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientId = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "客户端Id")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorrelationId = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "相关Id")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientIpAddress = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "客户端IP地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BrowserInfo = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "浏览器信息")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSecurityLogs", x => x.Id);
                },
                comment: "身份安全日志")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpSessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    SessionId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "会话Id")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Device = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "设备")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeviceInfo = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "设备信息")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id", collation: "ascii_general_ci"),
                    ClientId = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "客户端Id")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IpAddresses = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: true, comment: "Ip地址")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SignedIn = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "用户登录的时间"),
                    LastAccessed = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "用户最近一次访问系统的时间"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSessions", x => x.Id);
                },
                comment: "会话信息")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpSettingDefinitions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "显示名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DefaultValue = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: true, comment: "默认值")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsVisibleToClients = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Providers = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true, comment: "提供者多个,隔开")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsInherited = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "此设置是从父作用域继承的吗"),
                    IsEncrypted = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "此设置是否以加密方式存储在数据源中"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSettingDefinitions", x => x.Id);
                },
                comment: "配置定义")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpSettings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "配置名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "varchar(2048)", maxLength: 2048, nullable: false, comment: "配置值")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "提供者名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "提供者Key")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpSettings", x => x.Id);
                },
                comment: "配置表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpTenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "标准化的名称（通常是去除空格、转换为小写等处理后的名称）")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityVersion = table.Column<int>(type: "int", nullable: false, comment: "实体版本号，用于并发控制或数据版本管理"),
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
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpTenants", x => x.Id);
                },
                comment: "租户")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserDelegations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    SourceUserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "源用户Id", collation: "ascii_general_ci"),
                    TargetUserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "目标用户Id", collation: "ascii_general_ci"),
                    StartTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "开始时间"),
                    EndTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "结束时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserDelegations", x => x.Id);
                },
                comment: "管理用户之间的委托关系")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "用户名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "用户名标准名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "名")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Surname = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "姓")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "邮箱")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "邮箱标准名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "邮箱确认"),
                    PasswordHash = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "密码散列")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "安全票据")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsExternal = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "是否外部"),
                    PhoneNumber = table.Column<string>(type: "varchar(16)", maxLength: 16, nullable: true, comment: "手机号码")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "手机号码确认"),
                    IsActive = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否活跃"),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "双因素认证"),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "锁定到期时间"),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false, comment: "锁定"),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "错误登录次数"),
                    ShouldChangePasswordOnNextLogin = table.Column<bool>(type: "tinyint(1)", nullable: false, comment: "是否需要更改密码"),
                    EntityVersion = table.Column<int>(type: "int", nullable: false, comment: "版本"),
                    LastPasswordChangeTime = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true, comment: "最后修改密码时间"),
                    Avatar = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: false, defaultValue: "", comment: "头像")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Identity = table.Column<int>(type: "int", nullable: false, defaultValue: 1, comment: "身份标识"),
                    OpenId = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, defaultValue: "", comment: "第三方登录唯一标识")
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUsers", x => x.Id);
                },
                comment: "用户表")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OpenIddictApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    ApplicationType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "与应用程序关联的应用程序类型")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "与当前应用程序关联的客户端标识符")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientSecret = table.Column<string>(type: "longtext", nullable: true, comment: "与当前应用程序关联的客户端密钥。注意：根据创建此实例的应用程序管理器，该属性可能出于安全原因被哈希或加密")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "与应用程序关联的客户端类型")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConsentType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "与当前应用程序关联的同意类型")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "longtext", nullable: true, comment: "与当前应用程序关联的显示名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayNames = table.Column<string>(type: "longtext", nullable: true, comment: "与当前应用程序关联的本地化显示名称，序列化为 JSON 对象")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    JsonWebKeySet = table.Column<string>(type: "longtext", nullable: true, comment: "与应用程序关联的 JSON Web Key Set，序列化为 JSON 对象")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Permissions = table.Column<string>(type: "longtext", nullable: true, comment: "与当前应用程序关联的权限，序列化为 JSON 数组")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostLogoutRedirectUris = table.Column<string>(type: "longtext", nullable: true, comment: "与当前应用程序关联的登出回调 URL，序列化为 JSON 数组")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Properties = table.Column<string>(type: "longtext", nullable: true, comment: "附加属性，序列化为 JSON 对象；如果未与当前应用程序关联任何属性，则为 null")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RedirectUris = table.Column<string>(type: "longtext", nullable: true, comment: "与当前应用程序关联的回调 URL，序列化为 JSON 数组")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Requirements = table.Column<string>(type: "longtext", nullable: true, comment: "与当前应用程序关联的要求，序列化为 JSON 数组")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Settings = table.Column<string>(type: "longtext", nullable: true, comment: "设置，序列化为 JSON 对象")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientUri = table.Column<string>(type: "longtext", nullable: true, comment: "指向客户端更多信息的 URI")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LogoUri = table.Column<string>(type: "longtext", nullable: true, comment: "指向客户端标志的 URI")
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictApplications", x => x.Id);
                },
                comment: "OpenIddict-应用程序")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OpenIddictScopes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    Description = table.Column<string>(type: "longtext", nullable: true, comment: "与当前作用域关联的公开描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Descriptions = table.Column<string>(type: "longtext", nullable: true, comment: "与当前作用域关联的本地化公开描述，序列化为 JSON 对象")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayName = table.Column<string>(type: "longtext", nullable: true, comment: "与当前作用域关联的显示名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisplayNames = table.Column<string>(type: "longtext", nullable: true, comment: "与当前作用域关联的本地化显示名称，序列化为 JSON 对象")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, comment: "与当前作用域关联的唯一名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Properties = table.Column<string>(type: "longtext", nullable: true, comment: "附加属性，序列化为 JSON 对象；如果未与当前作用域关联任何属性，则为 null")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Resources = table.Column<string>(type: "longtext", nullable: true, comment: "与当前作用域关联的资源，序列化为 JSON 数组")
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "删除时间")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictScopes", x => x.Id);
                },
                comment: "OpenIddict-授权范围")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpAuditLogActions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    AuditLogId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "AuditLogId", collation: "ascii_general_ci"),
                    ServiceName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true, comment: "服务名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MethodName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "方法名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Parameters = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true, comment: "参数")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExecutionTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "执行时间"),
                    ExecutionDuration = table.Column<int>(type: "int", nullable: false, comment: "执行耗时"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpEntityChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    AuditLogId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "AuditLogId", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    ChangeTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "变更时间"),
                    ChangeType = table.Column<byte>(type: "tinyint unsigned", nullable: false, comment: "变更类型"),
                    EntityTenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "审计实体租户Id", collation: "ascii_general_ci"),
                    EntityId = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "审计实体Id")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EntityTypeFullName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "审计实体全称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: true, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpBlobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    ContainerId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "容器ID", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<byte[]>(type: "longblob", maxLength: 2147483647, nullable: true, comment: "数据"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpOrganizationUnitRoles",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "角色Id", collation: "ascii_general_ci"),
                    OrganizationUnitId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "组织机构Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id", collation: "ascii_general_ci")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpRoleClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "角色Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    ClaimType = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "声明类型")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true, comment: "声明值")
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpTenantConnectionStrings",
                columns: table => new
                {
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: false, comment: "值")
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserClaims",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    ClaimType = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false, comment: "声明类型")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "varchar(1024)", maxLength: 1024, nullable: true, comment: "声明值")
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id", collation: "ascii_general_ci"),
                    LoginProvider = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "登录提供者")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    ProviderKey = table.Column<string>(type: "varchar(196)", maxLength: 196, nullable: false, comment: "登录提供者Key")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "登录提供者显示名称")
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserOrganizationUnits",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id", collation: "ascii_general_ci"),
                    OrganizationUnitId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "组织机构Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id", collation: "ascii_general_ci")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id", collation: "ascii_general_ci"),
                    RoleId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "角色Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id", collation: "ascii_general_ci"),
                    LoginProvider = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "登录提供者")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    Value = table.Column<string>(type: "longtext", nullable: true, comment: "值")
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OpenIddictAuthorizations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    ApplicationId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "与当前授权关联的应用程序的唯一标识符", collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "当前授权的 UTC 创建日期"),
                    Properties = table.Column<string>(type: "longtext", nullable: true, comment: "附加属性，序列化为 JSON 对象；如果未与当前授权关联任何属性，则为 null")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Scopes = table.Column<string>(type: "longtext", nullable: true, comment: "与当前授权关联的作用域，序列化为 JSON 数组")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "当前授权的状态")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Subject = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true, comment: "与当前授权关联的主体")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "当前授权的类型")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpEntityPropertyChanges",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    EntityChangeId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    NewValue = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "新值")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OriginalValue = table.Column<string>(type: "varchar(512)", maxLength: 512, nullable: true, comment: "旧值")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false, comment: "属性名称")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PropertyTypeFullName = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false, comment: "属性全称")
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OpenIddictTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    ApplicationId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "与当前令牌关联的应用程序的唯一标识符", collation: "ascii_general_ci"),
                    AuthorizationId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "与当前令牌关联的授权的唯一标识符", collation: "ascii_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "当前令牌的 UTC 创建日期"),
                    ExpirationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "当前令牌的 UTC 过期日期"),
                    Payload = table.Column<string>(type: "longtext", nullable: true, comment: "当前令牌的有效载荷（如果适用）。注意：此属性仅用于引用令牌，可能出于安全原因被加密")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Properties = table.Column<string>(type: "longtext", nullable: true, comment: "附加属性，序列化为 JSON 对象；如果未与当前令牌关联任何属性，则为 null")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RedemptionDate = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "当前令牌的 UTC 兑换日期"),
                    ReferenceId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, comment: "与当前令牌关联的引用标识符（如果适用）。注意：此属性仅用于引用令牌，可能出于安全原因被哈希或加密")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "当前令牌的状态")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Subject = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true, comment: "与当前令牌关联的主体")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, comment: "当前令牌的类型")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ExtraProperties = table.Column<string>(type: "longtext", nullable: false, comment: "扩展字段")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "varchar(40)", maxLength: 40, nullable: false, comment: "迸发标记")
                        .Annotation("MySql:CharSet", "utf8mb4")
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
                .Annotation("MySql:CharSet", "utf8mb4");

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
                name: "AbpBackgroundJobs");

            migrationBuilder.DropTable(
                name: "AbpBlobs");

            migrationBuilder.DropTable(
                name: "AbpCampus");

            migrationBuilder.DropTable(
                name: "AbpClaimTypes");

            migrationBuilder.DropTable(
                name: "AbpDepartment");

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
                name: "AbpUserClaims");

            migrationBuilder.DropTable(
                name: "AbpUserDelegations");

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
                name: "AbpEntityChanges");

            migrationBuilder.DropTable(
                name: "AbpTenants");

            migrationBuilder.DropTable(
                name: "AbpOrganizationUnits");

            migrationBuilder.DropTable(
                name: "AbpRoles");

            migrationBuilder.DropTable(
                name: "AbpUsers");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations");

            migrationBuilder.DropTable(
                name: "AbpAuditLogs");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications");
        }
    }
}
