using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForouzanTask.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_TaskRequested : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbTaskRequesteds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    TaskId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RequestedTitle = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTaskRequesteds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbTaskRequesteds_TbProjectTasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "TbProjectTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbTaskRequestedValues",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    RequestedId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbTaskRequestedValues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbTaskRequestedValues_TbTaskRequesteds_RequestedId",
                        column: x => x.RequestedId,
                        principalTable: "TbTaskRequesteds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbTaskRequesteds_TaskId",
                table: "TbTaskRequesteds",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TbTaskRequestedValues_RequestedId",
                table: "TbTaskRequestedValues",
                column: "RequestedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbTaskRequestedValues");

            migrationBuilder.DropTable(
                name: "TbTaskRequesteds");
        }
    }
}
