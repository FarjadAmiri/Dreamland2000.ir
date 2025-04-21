using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _5aprill20205ch02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateAge_AgeRefId",
                table: "RealEstate");

            migrationBuilder.RenameColumn(
                name: "AgeRefId",
                table: "RealEstate",
                newName: "RealEstateAgeId");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstate_AgeRefId",
                table: "RealEstate",
                newName: "IX_RealEstate_RealEstateAgeId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateAge_RealEstateAgeId",
                table: "RealEstate",
                column: "RealEstateAgeId",
                principalTable: "RealEstateAge",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateAge_RealEstateAgeId",
                table: "RealEstate");

            migrationBuilder.RenameColumn(
                name: "RealEstateAgeId",
                table: "RealEstate",
                newName: "AgeRefId");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstate_RealEstateAgeId",
                table: "RealEstate",
                newName: "IX_RealEstate_AgeRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateAge_AgeRefId",
                table: "RealEstate",
                column: "AgeRefId",
                principalTable: "RealEstateAge",
                principalColumn: "Id");
        }
    }
}
