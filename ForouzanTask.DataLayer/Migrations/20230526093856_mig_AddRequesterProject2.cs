using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForouzanTask.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_AddRequesterProject2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbProjectRequests_TbProjects_TbProjectId",
                table: "TbProjectRequests");

            migrationBuilder.DropIndex(
                name: "IX_TbProjectRequests_TbProjectId",
                table: "TbProjectRequests");

            migrationBuilder.DropColumn(
                name: "TbProjectId",
                table: "TbProjectRequests");

            migrationBuilder.CreateIndex(
                name: "IX_TbProjectRequests_ProjectId",
                table: "TbProjectRequests",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbProjectRequests_TbProjects_ProjectId",
                table: "TbProjectRequests",
                column: "ProjectId",
                principalTable: "TbProjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbProjectRequests_TbProjects_ProjectId",
                table: "TbProjectRequests");

            migrationBuilder.DropIndex(
                name: "IX_TbProjectRequests_ProjectId",
                table: "TbProjectRequests");

            migrationBuilder.AddColumn<Guid>(
                name: "TbProjectId",
                table: "TbProjectRequests",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbProjectRequests_TbProjectId",
                table: "TbProjectRequests",
                column: "TbProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbProjectRequests_TbProjects_TbProjectId",
                table: "TbProjectRequests",
                column: "TbProjectId",
                principalTable: "TbProjects",
                principalColumn: "Id");
        }
    }
}
