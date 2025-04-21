using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _29march2025ch06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VisibleStatusId",
                table: "RealEstateGroup");

            migrationBuilder.AddColumn<bool>(
                name: "IsVisible",
                table: "RealEstateGroup",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TypeRefId",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RealEstateType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: true),
                    Count = table.Column<int>(type: "int", nullable: true),
                    IsVisible = table.Column<bool>(type: "bit", nullable: true),
                    LanguageRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RealEstateType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RealEstateType_Language_LanguageRefId",
                        column: x => x.LanguageRefId,
                        principalTable: "Language",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_TypeRefId",
                table: "RealEstate",
                column: "TypeRefId");

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateType_LanguageRefId",
                table: "RealEstateType",
                column: "LanguageRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateType_TypeRefId",
                table: "RealEstate",
                column: "TypeRefId",
                principalTable: "RealEstateType",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateType_TypeRefId",
                table: "RealEstate");

            migrationBuilder.DropTable(
                name: "RealEstateType");

            migrationBuilder.DropIndex(
                name: "IX_RealEstate_TypeRefId",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "IsVisible",
                table: "RealEstateGroup");

            migrationBuilder.DropColumn(
                name: "TypeRefId",
                table: "RealEstate");

            migrationBuilder.AddColumn<int>(
                name: "VisibleStatusId",
                table: "RealEstateGroup",
                type: "int",
                nullable: true);
        }
    }
}
