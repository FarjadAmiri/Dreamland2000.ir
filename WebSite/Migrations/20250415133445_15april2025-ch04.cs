using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _15april2025ch04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BaseArea",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GarbageCost",
                table: "RealEstate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LandArea",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TerraceArea",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnitCharge",
                table: "RealEstate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsageRefId",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YardArea",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_UsageRefId",
                table: "RealEstate",
                column: "UsageRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateUsageStatus_UsageRefId",
                table: "RealEstate",
                column: "UsageRefId",
                principalTable: "RealEstateUsageStatus",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateUsageStatus_UsageRefId",
                table: "RealEstate");

            migrationBuilder.DropIndex(
                name: "IX_RealEstate_UsageRefId",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "BaseArea",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "GarbageCost",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "LandArea",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "TerraceArea",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "UnitCharge",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "UsageRefId",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "YardArea",
                table: "RealEstate");
        }
    }
}
