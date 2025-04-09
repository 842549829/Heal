using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heal.Net.EntityFrameworkCore.Migrations
{
    /// <inheritdoc />
    public partial class init3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AbpOrganizationUnits",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true,
                comment: "地址")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CoverImage",
                table: "AbpOrganizationUnits",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: true,
                comment: "封面图片")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Describe",
                table: "AbpOrganizationUnits",
                type: "varchar(512)",
                maxLength: 512,
                nullable: true,
                comment: "备注描述")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "AbpOrganizationUnits",
                type: "varchar(64)",
                maxLength: 64,
                nullable: true,
                comment: "院长")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "AbpOrganizationUnits",
                type: "varchar(64)",
                maxLength: 64,
                nullable: true,
                comment: "邮箱")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "EstablishmentDate",
                table: "AbpOrganizationUnits",
                type: "datetime(6)",
                nullable: true,
                comment: "成立时间");

            migrationBuilder.AddColumn<string>(
                name: "Facilities",
                table: "AbpOrganizationUnits",
                type: "varchar(1024)",
                maxLength: 1024,
                nullable: true,
                comment: "医院设施")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Introduction",
                table: "AbpOrganizationUnits",
                type: "varchar(4096)",
                maxLength: 4096,
                nullable: true,
                comment: "医院简介")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsEmergencyServices",
                table: "AbpOrganizationUnits",
                type: "tinyint(1)",
                nullable: true,
                comment: "是否提供急诊服务");

            migrationBuilder.AddColumn<bool>(
                name: "IsInsuranceAccepted",
                table: "AbpOrganizationUnits",
                type: "tinyint(1)",
                nullable: true,
                comment: "是否接受医保");

            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "AbpOrganizationUnits",
                type: "decimal(65,30)",
                nullable: true,
                comment: "纬度");

            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "AbpOrganizationUnits",
                type: "int",
                nullable: true,
                comment: "医院等级");

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "AbpOrganizationUnits",
                type: "decimal(65,30)",
                nullable: true,
                comment: "经度");

            migrationBuilder.AddColumn<DateTime>(
                name: "OperatingHours",
                table: "AbpOrganizationUnits",
                type: "datetime(6)",
                nullable: true,
                comment: "营业时间");

            migrationBuilder.AddColumn<string>(
                name: "ParkingInformation",
                table: "AbpOrganizationUnits",
                type: "varchar(512)",
                maxLength: 512,
                nullable: true,
                comment: "停车信息")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AbpOrganizationUnits",
                type: "longtext",
                nullable: true,
                comment: "联系电话")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "AbpOrganizationUnits",
                type: "varchar(16)",
                maxLength: 16,
                nullable: true,
                comment: "邮政编码")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ServiceHotline",
                table: "AbpOrganizationUnits",
                type: "varchar(32)",
                maxLength: 32,
                nullable: true,
                comment: "服务热线")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "TrafficGuide",
                table: "AbpOrganizationUnits",
                type: "varchar(512)",
                maxLength: 512,
                nullable: true,
                comment: "交通指南")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "WebsiteUrl",
                table: "AbpOrganizationUnits",
                type: "varchar(128)",
                maxLength: 128,
                nullable: true,
                comment: "官方网站")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "CoverImage",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "Describe",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "Director",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "EstablishmentDate",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "Facilities",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "Introduction",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "IsEmergencyServices",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "IsInsuranceAccepted",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "OperatingHours",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "ParkingInformation",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "ServiceHotline",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "TrafficGuide",
                table: "AbpOrganizationUnits");

            migrationBuilder.DropColumn(
                name: "WebsiteUrl",
                table: "AbpOrganizationUnits");
        }
    }
}
