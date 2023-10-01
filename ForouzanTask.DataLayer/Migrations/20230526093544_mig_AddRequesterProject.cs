using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForouzanTask.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_AddRequesterProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TbProjectNotes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(newid())",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TbProjectDocuments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(newid())",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "TbProjectRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequesterName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RequesterMobile = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    TbProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedUserIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModifiedUserMac = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbProjectRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbProjectRequests_TbProjects_TbProjectId",
                        column: x => x.TbProjectId,
                        principalTable: "TbProjects",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbProjectRequests_TbProjectId",
                table: "TbProjectRequests",
                column: "TbProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbProjectRequests");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TbProjectNotes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "(newid())");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TbProjectDocuments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "(newid())");
        }
    }
}
