using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForouzanTask.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_AddProjectTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "TbUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "TbProjectTasks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedUserIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModifiedUserMac = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProjectTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbProjectTasks_TbProjects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "TbProjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbProjectTaskDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Desctiption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentFileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedUserIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModifiedUserMac = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProjectTaskDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbProjectTaskDetails_TbProjectTasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TbProjectTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbProjectTaskDetails_TaskId",
                table: "TbProjectTaskDetails",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TbProjectTasks_ProjectId",
                table: "TbProjectTasks",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbProjectTaskDetails");

            migrationBuilder.DropTable(
                name: "TbProjectTasks");

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
        }
    }
}
