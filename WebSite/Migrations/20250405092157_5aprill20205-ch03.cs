using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _5aprill20205ch03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "RealEstate",
                type: "real",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RentPeriodRefId",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RealEstateRentPeriod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateRentPeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateRentPeriod_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_RentPeriodRefId",
                table: "RealEstate",
                column: "RentPeriodRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateRentPeriod_LanguageRefId",
                table: "RealEstateRentPeriod",
                column: "LanguageRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateRentPeriod_RentPeriodRefId",
                table: "RealEstate",
                column: "RentPeriodRefId",
                principalTable: "RealEstateRentPeriod",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateRentPeriod_RentPeriodRefId",
                table: "RealEstate");

            migrationBuilder.DropTable(
                name: "RealEstateRentPeriod");

            migrationBuilder.DropIndex(
                name: "IX_RealEstate_RentPeriodRefId",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "RentPeriodRefId",
                table: "RealEstate");

            migrationBuilder.AlterColumn<string>(
                name: "Price",
                table: "RealEstate",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 100,
                oldNullable: true);
        }
    }
}
