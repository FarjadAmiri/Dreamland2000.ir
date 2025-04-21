using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _29march2025ch01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SenderTell = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SenderEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsArchive = table.Column<bool>(type: "bit", nullable: true),
                    IsAnswer = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    ParentRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Permission_Permission_ParentRefId",
                        column: x => x.ParentRefId,
                        principalTable: "Permission",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhotoGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mobile = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DisposablePassword = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SerialNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastLoggedIn = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmailActiveCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsEmailActive = table.Column<bool>(type: "bit", nullable: true),
                    MobileActiveCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsMobileActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "About",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Video = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_About", x => x.Id);
                    table.ForeignKey(
                        name: "FK_About_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BlogGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    VisibleStatusId = table.Column<int>(type: "int", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogGroup_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Tell = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Website = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Telegram = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Instagram = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    WhatsApp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Fact",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fact_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Faq",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faq", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faq_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    IsVisible = table.Column<bool>(type: "bit", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Province_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RealEstateGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    VisibleStatusId = table.Column<int>(type: "int", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateGroup_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceGroup",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceGroup_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Slider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SlideText = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    SlideTag = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SlideUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SlideDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
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
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Responsibility = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhotoAlbum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Visit = table.Column<int>(type: "int", nullable: true),
                    GroupRefId = table.Column<int>(type: "int", nullable: true)
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
                name: "PermissionJoinRole",
                columns: table => new
                {
                    JoinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionRefId = table.Column<int>(type: "int", nullable: true),
                    RoleRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionJoinRole", x => x.JoinId);
                    table.ForeignKey(
                        name: "FK_PermissionJoinRole_Permission_PermissionRefId",
                        column: x => x.PermissionRefId,
                        principalTable: "Permission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PermissionJoinRole_Role_RoleRefId",
                        column: x => x.RoleRefId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserJoinRole",
                columns: table => new
                {
                    JoinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRefId = table.Column<int>(type: "int", nullable: false),
                    RoleRefId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJoinRole", x => x.JoinId);
                    table.ForeignKey(
                        name: "FK_UserJoinRole_Role_RoleRefId",
                        column: x => x.RoleRefId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserJoinRole_Users_UserRefId",
                        column: x => x.UserRefId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VideoGallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AparatUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Visit = table.Column<int>(type: "int", nullable: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: true),
                    GroupRefId = table.Column<int>(type: "int", nullable: true),
                    TypeRefId = table.Column<int>(type: "int", nullable: true)
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
                name: "Blog",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlogDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Visit = table.Column<int>(type: "int", nullable: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: true),
                    GroupRefId = table.Column<int>(type: "int", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blog_BlogGroup_GroupRefId",
                        column: x => x.GroupRefId,
                        principalTable: "BlogGroup",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Blog_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: true),
                    ProvinceRefId = table.Column<int>(type: "int", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_City_Province_ProvinceRefId",
                        column: x => x.ProvinceRefId,
                        principalTable: "Province",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RealEstate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Visit = table.Column<int>(type: "int", nullable: true),
                    GroupRefId = table.Column<int>(type: "int", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstate_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealEstate_RealEstateGroup_GroupRefId",
                        column: x => x.GroupRefId,
                        principalTable: "RealEstateGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    Visit = table.Column<int>(type: "int", nullable: true),
                    GroupRefId = table.Column<int>(type: "int", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Service_ServiceGroup_GroupRefId",
                        column: x => x.GroupRefId,
                        principalTable: "ServiceGroup",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PhotoAlbumComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Tell = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: true),
                    UserRefId = table.Column<int>(type: "int", nullable: true),
                    AlbumRefId = table.Column<int>(type: "int", nullable: true)
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
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Photographer = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: true),
                    Visit = table.Column<int>(type: "int", nullable: true),
                    AlbumRefId = table.Column<int>(type: "int", nullable: true),
                    UserRefId = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "BlogComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tell = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: true),
                    UserRefId = table.Column<int>(type: "int", nullable: true),
                    BlogRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogComment_Blog_BlogRefId",
                        column: x => x.BlogRefId,
                        principalTable: "Blog",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlogComment_Users_UserRefId",
                        column: x => x.UserRefId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BlogPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    BlogRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPhoto_Blog_BlogRefId",
                        column: x => x.BlogRefId,
                        principalTable: "Blog",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RealEstateComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tell = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: true),
                    UserRefId = table.Column<int>(type: "int", nullable: true),
                    RealEstateRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateComment_RealEstate_RealEstateRefId",
                        column: x => x.RealEstateRefId,
                        principalTable: "RealEstate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealEstateComment_Users_UserRefId",
                        column: x => x.UserRefId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RealEstatePhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    RealEstateRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstatePhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstatePhoto_RealEstate_RealEstateRefId",
                        column: x => x.RealEstateRefId,
                        principalTable: "RealEstate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_About_LanguageRefId",
                table: "About",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_GroupRefId",
                table: "Blog",
                column: "GroupRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Blog_LanguageRefId",
                table: "Blog",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComment_BlogRefId",
                table: "BlogComment",
                column: "BlogRefId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogComment_UserRefId",
                table: "BlogComment",
                column: "UserRefId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogGroup_LanguageRefId",
                table: "BlogGroup",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPhoto_BlogRefId",
                table: "BlogPhoto",
                column: "BlogRefId");

            migrationBuilder.CreateIndex(
                name: "IX_City_LanguageRefId",
                table: "City",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_City_ProvinceRefId",
                table: "City",
                column: "ProvinceRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_LanguageRefId",
                table: "Contact",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Fact_LanguageRefId",
                table: "Fact",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Faq_LanguageRefId",
                table: "Faq",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Permission_ParentRefId",
                table: "Permission",
                column: "ParentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionJoinRole_PermissionRefId",
                table: "PermissionJoinRole",
                column: "PermissionRefId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionJoinRole_RoleRefId",
                table: "PermissionJoinRole",
                column: "RoleRefId");

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
                name: "IX_Province_LanguageRefId",
                table: "Province",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_GroupRefId",
                table: "RealEstate",
                column: "GroupRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_LanguageRefId",
                table: "RealEstate",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateComment_RealEstateRefId",
                table: "RealEstateComment",
                column: "RealEstateRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateComment_UserRefId",
                table: "RealEstateComment",
                column: "UserRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateGroup_LanguageRefId",
                table: "RealEstateGroup",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstatePhoto_RealEstateRefId",
                table: "RealEstatePhoto",
                column: "RealEstateRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_GroupRefId",
                table: "Service",
                column: "GroupRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_LanguageRefId",
                table: "Service",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceGroup_LanguageRefId",
                table: "ServiceGroup",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Slider_LanguageRefId",
                table: "Slider",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_LanguageRefId",
                table: "Team",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJoinRole_RoleRefId",
                table: "UserJoinRole",
                column: "RoleRefId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJoinRole_UserRefId",
                table: "UserJoinRole",
                column: "UserRefId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGallery_GroupRefId",
                table: "VideoGallery",
                column: "GroupRefId");

            migrationBuilder.CreateIndex(
                name: "IX_VideoGallery_TypeRefId",
                table: "VideoGallery",
                column: "TypeRefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "About");

            migrationBuilder.DropTable(
                name: "BlogComment");

            migrationBuilder.DropTable(
                name: "BlogPhoto");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "ContactMessage");

            migrationBuilder.DropTable(
                name: "Fact");

            migrationBuilder.DropTable(
                name: "Faq");

            migrationBuilder.DropTable(
                name: "PermissionJoinRole");

            migrationBuilder.DropTable(
                name: "PhotoAlbumComment");

            migrationBuilder.DropTable(
                name: "PhotoGallery");

            migrationBuilder.DropTable(
                name: "RealEstateComment");

            migrationBuilder.DropTable(
                name: "RealEstatePhoto");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Slider");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "UserJoinRole");

            migrationBuilder.DropTable(
                name: "VideoGallery");

            migrationBuilder.DropTable(
                name: "Blog");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "PhotoAlbum");

            migrationBuilder.DropTable(
                name: "RealEstate");

            migrationBuilder.DropTable(
                name: "ServiceGroup");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VideoGroup");

            migrationBuilder.DropTable(
                name: "VideoType");

            migrationBuilder.DropTable(
                name: "BlogGroup");

            migrationBuilder.DropTable(
                name: "PhotoGroup");

            migrationBuilder.DropTable(
                name: "RealEstateGroup");

            migrationBuilder.DropTable(
                name: "Language");
        }
    }
}
