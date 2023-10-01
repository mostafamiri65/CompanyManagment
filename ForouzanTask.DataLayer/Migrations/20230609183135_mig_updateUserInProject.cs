using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForouzanTask.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_updateUserInProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectRoleId",
                table: "TbUserInProjects",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_TbUserInProjects_ProjectRoleId",
                table: "TbUserInProjects",
                column: "ProjectRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbUserInProjects_TbProjectRoles_ProjectRoleId",
                table: "TbUserInProjects",
                column: "ProjectRoleId",
                principalTable: "TbProjectRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbUserInProjects_TbProjectRoles_ProjectRoleId",
                table: "TbUserInProjects");

            migrationBuilder.DropIndex(
                name: "IX_TbUserInProjects_ProjectRoleId",
                table: "TbUserInProjects");

            migrationBuilder.DropColumn(
                name: "ProjectRoleId",
                table: "TbUserInProjects");
        }
    }
}
