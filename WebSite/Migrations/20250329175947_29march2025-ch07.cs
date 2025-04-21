using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _29march2025ch07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RealEstateOption",
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
                    table.PrimaryKey("PK_RealEstateOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateOption_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RealEstateJoinOption",
                columns: table => new
                {
                    JoinId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RealEstateRefId = table.Column<int>(type: "int", nullable: true),
                    OptionRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateJoinOption", x => x.JoinId);
                    table.ForeignKey(
                        name: "FK_RealEstateJoinOption_RealEstateOption_OptionRefId",
                        column: x => x.OptionRefId,
                        principalTable: "RealEstateOption",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RealEstateJoinOption_RealEstate_RealEstateRefId",
                        column: x => x.RealEstateRefId,
                        principalTable: "RealEstate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateJoinOption_OptionRefId",
                table: "RealEstateJoinOption",
                column: "OptionRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateJoinOption_RealEstateRefId",
                table: "RealEstateJoinOption",
                column: "RealEstateRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateOption_LanguageRefId",
                table: "RealEstateOption",
                column: "LanguageRefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RealEstateJoinOption");

            migrationBuilder.DropTable(
                name: "RealEstateOption");
        }
    }
}
