using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _12aprill2025ch03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaRange",
                table: "RealEstateProject");

            migrationBuilder.DropColumn(
                name: "BathroomRange",
                table: "RealEstateProject");

            migrationBuilder.RenameColumn(
                name: "RoomRange",
                table: "RealEstateProject",
                newName: "Room");

            migrationBuilder.RenameColumn(
                name: "ParkingRange",
                table: "RealEstateProject",
                newName: "Bathroom");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "RealEstateProject",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "RealEstateProject");

            migrationBuilder.RenameColumn(
                name: "Room",
                table: "RealEstateProject",
                newName: "RoomRange");

            migrationBuilder.RenameColumn(
                name: "Bathroom",
                table: "RealEstateProject",
                newName: "ParkingRange");

            migrationBuilder.AddColumn<string>(
                name: "AreaRange",
                table: "RealEstateProject",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BathroomRange",
                table: "RealEstateProject",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
