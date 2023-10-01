using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForouzanTask.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_AddProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmployee",
                table: "TbRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsManager",
                table: "TbRoles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "TbProjectTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedUserIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModifiedUserMac = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbProjects_TbProjectTypes_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "TbProjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbProjectRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HasAccessForView = table.Column<bool>(type: "bit", nullable: false),
                    HasAccessForEdit = table.Column<bool>(type: "bit", nullable: false),
                    HasAccessForDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedUserIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModifiedUserMac = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProjectRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbProjectRoles_TbProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "TbProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbUserInProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedUserIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModifiedUserMac = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbUserInProjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbUserInProjects_TbProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "TbProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbUserInProjects_TbUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "TbUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbProjectRoles_ProjectId",
                table: "TbProjectRoles",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProjects_ProjectTypeId",
                table: "TbProjects",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TbUserInProjects_ProjectId",
                table: "TbUserInProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TbUserInProjects_UserId",
                table: "TbUserInProjects",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbProjectRoles");

            migrationBuilder.DropTable(
                name: "TbUserInProjects");

            migrationBuilder.DropTable(
                name: "TbProjects");

            migrationBuilder.DropTable(
                name: "TbProjectTypes");

            migrationBuilder.DropColumn(
                name: "IsEmployee",
                table: "TbRoles");

            migrationBuilder.DropColumn(
                name: "IsManager",
                table: "TbRoles");
        }
    }
}
