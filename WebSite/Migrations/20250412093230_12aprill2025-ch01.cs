using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _12aprill2025ch01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "ContactMessage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageRefId",
                table: "ContactMessage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RealEstateProjectStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateProjectStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateProjectStatus_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RealEstateProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ShortTitle = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Tags = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AreaRange = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Iframe = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    RoomRange = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    BathroomRange = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ParkingRange = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Visit = table.Column<int>(type: "int", nullable: true),
                    StatusRefId = table.Column<int>(type: "int", nullable: true),
                    CityRefId = table.Column<int>(type: "int", nullable: true),
                    AgentRefId = table.Column<int>(type: "int", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateProject_Agent_AgentRefId",
                        column: x => x.AgentRefId,
                        principalTable: "Agent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealEstateProject_City_CityRefId",
                        column: x => x.CityRefId,
                        principalTable: "City",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealEstateProject_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealEstateProject_RealEstateProjectStatus_StatusRefId",
                        column: x => x.StatusRefId,
                        principalTable: "RealEstateProjectStatus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RealEstateProjectComment",
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
                    RealEstateRefId = table.Column<int>(type: "int", nullable: true),
                    RealEstateProjectId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateProjectComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateProjectComment_RealEstateProject_RealEstateProjectId",
                        column: x => x.RealEstateProjectId,
                        principalTable: "RealEstateProject",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealEstateProjectComment_RealEstate_RealEstateRefId",
                        column: x => x.RealEstateRefId,
                        principalTable: "RealEstate",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealEstateProjectComment_Users_UserRefId",
                        column: x => x.UserRefId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RealEstateProjectPhoto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    ProjectRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateProjectPhoto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateProjectPhoto_RealEstateProject_ProjectRefId",
                        column: x => x.ProjectRefId,
                        principalTable: "RealEstateProject",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactMessage_LanguageRefId",
                table: "ContactMessage",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProject_AgentRefId",
                table: "RealEstateProject",
                column: "AgentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProject_CityRefId",
                table: "RealEstateProject",
                column: "CityRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProject_LanguageRefId",
                table: "RealEstateProject",
                column: "LanguageRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProject_StatusRefId",
                table: "RealEstateProject",
                column: "StatusRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProjectComment_RealEstateProjectId",
                table: "RealEstateProjectComment",
                column: "RealEstateProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProjectComment_RealEstateRefId",
                table: "RealEstateProjectComment",
                column: "RealEstateRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProjectComment_UserRefId",
                table: "RealEstateProjectComment",
                column: "UserRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProjectPhoto_ProjectRefId",
                table: "RealEstateProjectPhoto",
                column: "ProjectRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProjectStatus_LanguageRefId",
                table: "RealEstateProjectStatus",
                column: "LanguageRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactMessage_Language_LanguageRefId",
                table: "ContactMessage",
                column: "LanguageRefId",
                principalTable: "Language",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactMessage_Language_LanguageRefId",
                table: "ContactMessage");

            migrationBuilder.DropTable(
                name: "RealEstateProjectComment");

            migrationBuilder.DropTable(
                name: "RealEstateProjectPhoto");

            migrationBuilder.DropTable(
                name: "RealEstateProject");

            migrationBuilder.DropTable(
                name: "RealEstateProjectStatus");

            migrationBuilder.DropIndex(
                name: "IX_ContactMessage_LanguageRefId",
                table: "ContactMessage");

            migrationBuilder.DropColumn(
                name: "LanguageRefId",
                table: "ContactMessage");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "ContactMessage",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
