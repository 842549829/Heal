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
            migrationBuilder.AddColumn<string>(
                name: "Avatar",
                table: "AbpUsers",
                type: "varchar(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OpenId",
                table: "AbpUsers",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CustomDataPermission",
                table: "AbpRoles",
                type: "varchar(4096)",
                maxLength: 4096,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "DataPermission",
                table: "AbpRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Avatar",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "OpenId",
                table: "AbpUsers");

            migrationBuilder.DropColumn(
                name: "CustomDataPermission",
                table: "AbpRoles");

            migrationBuilder.DropColumn(
                name: "DataPermission",
                table: "AbpRoles");
        }
    }
}
