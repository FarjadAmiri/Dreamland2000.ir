using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _6aprill2025ch01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateAge_RealEstateAgeId",
                table: "RealEstate");

            migrationBuilder.DropTable(
                name: "PhotoAlbumComment");

            migrationBuilder.DropTable(
                name: "PhotoGallery");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "VideoGallery");

            migrationBuilder.DropTable(
                name: "PhotoAlbum");

            migrationBuilder.DropTable(
                name: "VideoGroup");

            migrationBuilder.DropTable(
                name: "VideoType");

            migrationBuilder.DropTable(
                name: "PhotoGroup");

            migrationBuilder.DropIndex(
                name: "IX_RealEstate_RealEstateAgeId",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "RealEstateAgeId",
                table: "RealEstate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RealEstateAgeId",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PhotoGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SlideDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SlideTag = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SlideText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SlideUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slider", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slider_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VideoGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Count = table.Column<int>(type: "int", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhotoAlbum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupRefId = table.Column<int>(type: "int", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Visit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoAlbum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoAlbum_PhotoGroup_GroupRefId",
                        column: x => x.GroupRefId,
                        principalTable: "PhotoGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "VideoGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupRefId = table.Column<int>(type: "int", nullable: true),
                    TypeRefId = table.Column<int>(type: "int", nullable: true),
                    AparatUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Visit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoGallery_VideoGroup_GroupRefId",
                        column: x => x.GroupRefId,
                        principalTable: "VideoGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_VideoGallery_VideoType_TypeRefId",
                        column: x => x.TypeRefId,
                        principalTable: "VideoType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhotoAlbumComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumRefId = table.Column<int>(type: "int", nullable: true),
                    UserRefId = table.Column<int>(type: "int", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Tell = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoAlbumComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoAlbumComment_PhotoAlbum_AlbumRefId",
                        column: x => x.AlbumRefId,
                        principalTable: "PhotoAlbum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhotoAlbumComment_Users_UserRefId",
                        column: x => x.UserRefId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhotoGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlbumRefId = table.Column<int>(type: "int", nullable: true),
                    UserRefId = table.Column<int>(type: "int", nullable: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Photographer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Visit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoGallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoGallery_PhotoAlbum_AlbumRefId",
                        column: x => x.AlbumRefId,
                        principalTable: "PhotoAlbum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PhotoGallery_Users_UserRefId",
                        column: x => x.UserRefId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_RealEstateAgeId",
                table: "RealEstate",
                column: "RealEstateAgeId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoAlbum_GroupRefId",
                table: "PhotoAlbum",
                column: "GroupRefId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoAlbumComment_AlbumRefId",
                table: "PhotoAlbumComment",
                column: "AlbumRefId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoAlbumComment_UserRefId",
                table: "PhotoAlbumComment",
                column: "UserRefId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoGallery_AlbumRefId",
                table: "PhotoGallery",
                column: "AlbumRefId");

            migrationBuilder.CreateIndex(
                name: "IX_PhotoGallery_UserRefId",
                table: "PhotoGallery",
                column: "UserRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Slider_LanguageRefId",
                table: "Slider",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGallery_GroupRefId",
                table: "VideoGallery",
                column: "GroupRefId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGallery_TypeRefId",
                table: "VideoGallery",
                column: "TypeRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateAge_RealEstateAgeId",
                table: "RealEstate",
                column: "RealEstateAgeId",
                principalTable: "RealEstateAge",
                principalColumn: "Id");
        }
    }
}
