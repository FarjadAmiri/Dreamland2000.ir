using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _12aprill2025ch02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateProjectComment_RealEstateProject_RealEstateProjectId",
                table: "RealEstateProjectComment");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateProjectComment_RealEstate_RealEstateRefId",
                table: "RealEstateProjectComment");

            migrationBuilder.DropIndex(
                name: "IX_RealEstateProjectComment_RealEstateProjectId",
                table: "RealEstateProjectComment");

            migrationBuilder.DropColumn(
                name: "RealEstateProjectId",
                table: "RealEstateProjectComment");

            migrationBuilder.RenameColumn(
                name: "RealEstateRefId",
                table: "RealEstateProjectComment",
                newName: "ProjectRefId");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstateProjectComment_RealEstateRefId",
                table: "RealEstateProjectComment",
                newName: "IX_RealEstateProjectComment_ProjectRefId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateProjectComment_RealEstateProject_ProjectRefId",
                table: "RealEstateProjectComment",
                column: "ProjectRefId",
                principalTable: "RealEstateProject",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RealEstateProjectComment_RealEstateProject_ProjectRefId",
                table: "RealEstateProjectComment");

            migrationBuilder.RenameColumn(
                name: "ProjectRefId",
                table: "RealEstateProjectComment",
                newName: "RealEstateRefId");

            migrationBuilder.RenameIndex(
                name: "IX_RealEstateProjectComment_ProjectRefId",
                table: "RealEstateProjectComment",
                newName: "IX_RealEstateProjectComment_RealEstateRefId");

            migrationBuilder.AddColumn<int>(
                name: "RealEstateProjectId",
                table: "RealEstateProjectComment",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealEstateProjectComment_RealEstateProjectId",
                table: "RealEstateProjectComment",
                column: "RealEstateProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateProjectComment_RealEstateProject_RealEstateProjectId",
                table: "RealEstateProjectComment",
                column: "RealEstateProjectId",
                principalTable: "RealEstateProject",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstateProjectComment_RealEstate_RealEstateRefId",
                table: "RealEstateProjectComment",
                column: "RealEstateRefId",
                principalTable: "RealEstate",
                principalColumn: "Id");
        }
    }
}
