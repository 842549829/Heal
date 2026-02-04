using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heal.Net.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class Update1010Rc2Doc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "AbpUserPasswordHistories",
                comment: "用户密码历史记录");

            migrationBuilder.AlterTable(
                name: "AbpUserPasskeys",
                comment: "用户密码");

            migrationBuilder.AlterTable(
                name: "AbpResourcePermissionGrants",
                comment: "资源权限管理");

            migrationBuilder.AlterTable(
                name: "AbpAuditLogExcelFiles",
                comment: "审计日志-文件");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "AbpUserPasswordHistories",
                type: "uniqueidentifier",
                nullable: true,
                comment: "租户Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "AbpUserPasswordHistories",
                type: "datetimeoffset",
                nullable: false,
                comment: "创建时间",
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "AbpUserPasswordHistories",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                comment: "密码",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AbpUserPasswordHistories",
                type: "uniqueidentifier",
                nullable: false,
                comment: "用户Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AbpUserPasskeys",
                type: "uniqueidentifier",
                nullable: false,
                comment: "用户Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "AbpUserPasskeys",
                type: "uniqueidentifier",
                nullable: true,
                comment: "租户Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "CredentialId",
                table: "AbpUserPasskeys",
                type: "varbinary(1024)",
                maxLength: 1024,
                nullable: false,
                comment: "凭证ID",
                oldClrType: typeof(byte[]),
                oldType: "varbinary(1024)",
                oldMaxLength: 1024);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "AbpResourcePermissionGrants",
                type: "uniqueidentifier",
                nullable: true,
                comment: "租户Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ResourceName",
                table: "AbpResourcePermissionGrants",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                comment: "资源名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "ResourceKey",
                table: "AbpResourcePermissionGrants",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                comment: "资源Key",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderName",
                table: "AbpResourcePermissionGrants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                comment: "权限提供者名称(如:角色R)",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AbpResourcePermissionGrants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                comment: "权限提供者Key(如:角色key admin)",
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AbpResourcePermissionGrants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                comment: "权限名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AbpResourcePermissionGrants",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceName",
                table: "AbpPermissions",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "资源名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ManagementPermissionName",
                table: "AbpPermissions",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                comment: "管理权限名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "AbpAuditLogExcelFiles",
                type: "uniqueidentifier",
                nullable: true,
                comment: "租户Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "AbpAuditLogExcelFiles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "文件名称",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "AbpAuditLogExcelFiles",
                type: "uniqueidentifier",
                nullable: true,
                comment: "创建人Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "AbpAuditLogExcelFiles",
                type: "datetime2",
                nullable: false,
                comment: "创建时间",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AbpAuditLogExcelFiles",
                type: "uniqueidentifier",
                nullable: false,
                comment: "Id",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterTable(
                name: "AbpUserPasswordHistories",
                oldComment: "用户密码历史记录");

            migrationBuilder.AlterTable(
                name: "AbpUserPasskeys",
                oldComment: "用户密码");

            migrationBuilder.AlterTable(
                name: "AbpResourcePermissionGrants",
                oldComment: "资源权限管理");

            migrationBuilder.AlterTable(
                name: "AbpAuditLogExcelFiles",
                oldComment: "审计日志-文件");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "AbpUserPasswordHistories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "租户Id");

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "CreatedAt",
                table: "AbpUserPasswordHistories",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset",
                oldComment: "创建时间");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "AbpUserPasswordHistories",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldComment: "密码");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AbpUserPasswordHistories",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "用户Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "AbpUserPasskeys",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "用户Id");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "AbpUserPasskeys",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "租户Id");

            migrationBuilder.AlterColumn<byte[]>(
                name: "CredentialId",
                table: "AbpUserPasskeys",
                type: "varbinary(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(1024)",
                oldMaxLength: 1024,
                oldComment: "凭证ID");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "AbpResourcePermissionGrants",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "租户Id");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceName",
                table: "AbpResourcePermissionGrants",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldComment: "资源名称");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceKey",
                table: "AbpResourcePermissionGrants",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldComment: "资源Key");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderName",
                table: "AbpResourcePermissionGrants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldComment: "权限提供者名称(如:角色R)");

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AbpResourcePermissionGrants",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64,
                oldComment: "权限提供者Key(如:角色key admin)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AbpResourcePermissionGrants",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldComment: "权限名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AbpResourcePermissionGrants",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "ResourceName",
                table: "AbpPermissions",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "资源名称");

            migrationBuilder.AlterColumn<string>(
                name: "ManagementPermissionName",
                table: "AbpPermissions",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true,
                oldComment: "管理权限名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "TenantId",
                table: "AbpAuditLogExcelFiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "租户Id");

            migrationBuilder.AlterColumn<string>(
                name: "FileName",
                table: "AbpAuditLogExcelFiles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true,
                oldComment: "文件名称");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "AbpAuditLogExcelFiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true,
                oldComment: "创建人Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "AbpAuditLogExcelFiles",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldComment: "创建时间");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "AbpAuditLogExcelFiles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldComment: "Id");
        }
    }
}
