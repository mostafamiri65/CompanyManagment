using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForouzanTask.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_AddCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "TbArticles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TbCategories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCategories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbArticles_CategoryId",
                table: "TbArticles",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbArticles_TbCategories_CategoryId",
                table: "TbArticles",
                column: "CategoryId",
                principalTable: "TbCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbArticles_TbCategories_CategoryId",
                table: "TbArticles");

            migrationBuilder.DropTable(
                name: "TbCategories");

            migrationBuilder.DropIndex(
                name: "IX_TbArticles_CategoryId",
                table: "TbArticles");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "TbArticles");
        }
    }
}
