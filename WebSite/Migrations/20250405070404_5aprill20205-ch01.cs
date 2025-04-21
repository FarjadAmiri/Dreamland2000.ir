using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _5aprill20205ch01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cooling",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "Heating",
                table: "RealEstate");

            migrationBuilder.RenameColumn(
                name: "ParkingCount",
                table: "RealEstate",
                newName: "StatusRefId");

            migrationBuilder.AddColumn<string>(
                name: "Iframe",
                table: "RealEstate",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "RealEstate",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RealEstateStatus",
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
                    table.PrimaryKey("PK_RealEstateStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateStatus_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_StatusRefId",
                table: "RealEstate",
                column: "StatusRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateStatus_LanguageRefId",
                table: "RealEstateStatus",
                column: "LanguageRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateStatus_StatusRefId",
                table: "RealEstate",
                column: "StatusRefId",
                principalTable: "RealEstateStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateStatus_StatusRefId",
                table: "RealEstate");

            migrationBuilder.DropTable(
                name: "RealEstateStatus");

            migrationBuilder.DropIndex(
                name: "IX_RealEstate_StatusRefId",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "Iframe",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "RealEstate");

            migrationBuilder.RenameColumn(
                name: "StatusRefId",
                table: "RealEstate",
                newName: "ParkingCount");

            migrationBuilder.AddColumn<string>(
                name: "Cooling",
                table: "RealEstate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Heating",
                table: "RealEstate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
