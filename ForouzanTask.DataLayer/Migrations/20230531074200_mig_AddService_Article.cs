using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForouzanTask.DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_AddService_Article : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbArticles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    MainImageName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    IsApproal = table.Column<bool>(type: "bit", nullable: false),
                    SliderPicture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    IsShown = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedUserIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModifiedUserMac = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbArticles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbOurProjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedUserIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModifiedUserMac = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbOurProjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbOurServices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    ServiceMainIcon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ServiceDescription = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    servicePicture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedUserIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModifiedUserMac = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbOurServices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbSubArticles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "(newid())"),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    NumberOfParagraph = table.Column<int>(type: "int", nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    LoadPictureInMaxSize = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedUserIp = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    LastModifiedUserMac = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ModifiedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbSubArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbSubArticles_TbArticles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "TbArticles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbSubArticles_ArticleId",
                table: "TbSubArticles",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbOurProjects");

            migrationBuilder.DropTable(
                name: "TbOurServices");

            migrationBuilder.DropTable(
                name: "TbSubArticles");

            migrationBuilder.DropTable(
                name: "TbArticles");
        }
    }
}
