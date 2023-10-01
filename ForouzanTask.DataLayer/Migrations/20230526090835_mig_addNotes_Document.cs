using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForouzanTask.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_addNotes_Document : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "TbUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "TbProjects",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TbProjectDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    DocumentDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedUserIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModifiedUserMac = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProjectDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbProjectDocuments_TbProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "TbProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbProjectNotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedUserIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModifiedUserMac = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProjectNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbProjectNotes_TbProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "TbProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbProjectDocuments_ProjectId",
                table: "TbProjectDocuments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProjectNotes_ProjectId",
                table: "TbProjectNotes",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbProjectDocuments");

            migrationBuilder.DropTable(
                name: "TbProjectNotes");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "TbProjects");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "TbUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);
        }
    }
}
