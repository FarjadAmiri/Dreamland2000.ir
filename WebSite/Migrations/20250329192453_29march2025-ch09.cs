using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _29march2025ch09 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "RealEstate");

            migrationBuilder.AddColumn<int>(
                name: "AgeRefId",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Area",
                table: "RealEstate",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateTable(
                name: "RealEstateAge",
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
                    table.PrimaryKey("PK_RealEstateAge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateAge_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_AgeRefId",
                table: "RealEstate",
                column: "AgeRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateAge_LanguageRefId",
                table: "RealEstateAge",
                column: "LanguageRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateAge_AgeRefId",
                table: "RealEstate",
                column: "AgeRefId",
                principalTable: "RealEstateAge",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateAge_AgeRefId",
                table: "RealEstate");

            migrationBuilder.DropTable(
                name: "RealEstateAge");

            migrationBuilder.DropIndex(
                name: "IX_RealEstate_AgeRefId",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "AgeRefId",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "Cooling",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "Heating",
                table: "RealEstate");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "RealEstate",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
