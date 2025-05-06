using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Heal.Dict.EntityFrameworkCore.Migrations
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
                name: "AbpDictType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "父级Id", collation: "ascii_general_ci"),
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
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDictType", x => x.Id);
                },
                comment: "字典类型")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AbpDictItem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "Id", collation: "ascii_general_ci"),
                    Style = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: true, comment: "样式")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DictTypeId = table.Column<Guid>(type: "char(36)", nullable: false, comment: "所属类型Id", collation: "ascii_general_ci"),
                    Key = table.Column<string>(type: "varchar(95)", maxLength: 95, nullable: false, comment: "键")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ParentId = table.Column<Guid>(type: "char(36)", nullable: true, comment: "父级Id", collation: "ascii_general_ci"),
                    Alias = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: true, comment: "别名")
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
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbpDictItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbpDictItem_AbpDictType_DictTypeId",
                        column: x => x.DictTypeId,
                        principalTable: "AbpDictType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "字典项")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AbpDictItem_DictTypeId",
                table: "AbpDictItem",
                column: "DictTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbpDictItem");

            migrationBuilder.DropTable(
                name: "AbpDictType");
        }
    }
}
