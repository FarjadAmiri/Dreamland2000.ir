using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _16april2025ch01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DirectionRefId",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_DirectionRefId",
                table: "RealEstate",
                column: "DirectionRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_RealEstateBuildingDirection_DirectionRefId",
                table: "RealEstate",
                column: "DirectionRefId",
                principalTable: "RealEstateBuildingDirection",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_RealEstateBuildingDirection_DirectionRefId",
                table: "RealEstate");

            migrationBuilder.DropIndex(
                name: "IX_RealEstate_DirectionRefId",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "DirectionRefId",
                table: "RealEstate");
        }
    }
}
