using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _29march2025ch02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAccept",
                table: "Blog");

            migrationBuilder.AddColumn<int>(
                name: "Visit",
                table: "Team",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityRefId",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_CityRefId",
                table: "RealEstate",
                column: "CityRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_City_CityRefId",
                table: "RealEstate",
                column: "CityRefId",
                principalTable: "City",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_City_CityRefId",
                table: "RealEstate");

            migrationBuilder.DropIndex(
                name: "IX_RealEstate_CityRefId",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "Visit",
                table: "Team");

            migrationBuilder.DropColumn(
                name: "CityRefId",
                table: "RealEstate");

            migrationBuilder.AddColumn<bool>(
                name: "IsAccept",
                table: "Blog",
                type: "bit",
                nullable: true);
        }
    }
}
