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
            migrationBuilder.CreateTable(
                name: "AbpUserCampus",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id", collation: "ascii_general_ci"),
                    CampusId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "院区Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id", collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserCampus", x => new { x.UserId, x.CampusId });
                },
                comment: "用户院区")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpUserDepartment",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "用户Id", collation: "ascii_general_ci"),
                    DepartmentId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "科室Id", collation: "ascii_general_ci"),
                    TenantId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "租户Id", collation: "ascii_general_ci"),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    CreatorId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "创建人Id", collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpUserDepartment", x => new { x.UserId, x.DepartmentId });
                },
                comment: "用户科室")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AbpDepartment_CampusId",
                table: "AbpDepartment",
                column: "CampusId");

            migrationBuilder.CreateIndex(
                name: "IX_AbpCampus_OrganizationId",
                table: "AbpCampus",
                column: "OrganizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AbpCampus_AbpOrganizationUnits_OrganizationId",
                table: "AbpCampus",
                column: "OrganizationId",
                principalTable: "AbpOrganizationUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AbpDepartment_AbpCampus_CampusId",
                table: "AbpDepartment",
                column: "CampusId",
                principalTable: "AbpCampus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AbpCampus_AbpOrganizationUnits_OrganizationId",
                table: "AbpCampus");

            migrationBuilder.DropForeignKey(
                name: "FK_AbpDepartment_AbpCampus_CampusId",
                table: "AbpDepartment");

            migrationBuilder.DropTable(
                name: "AbpUserCampus");

            migrationBuilder.DropTable(
                name: "AbpUserDepartment");

            migrationBuilder.DropIndex(
                name: "IX_AbpDepartment_CampusId",
                table: "AbpDepartment");

            migrationBuilder.DropIndex(
                name: "IX_AbpCampus_OrganizationId",
                table: "AbpCampus");
        }
    }
}
