using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _29march2025ch04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentRefId",
                table: "RealEstate",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Agent",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RealEstate_AgentRefId",
                table: "RealEstate",
                column: "AgentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Agent_AgentId",
                table: "Agent",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agent_Agent_AgentId",
                table: "Agent",
                column: "AgentId",
                principalTable: "Agent",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RealEstate_Agent_AgentRefId",
                table: "RealEstate",
                column: "AgentRefId",
                principalTable: "Agent",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Agent_AgentId",
                table: "Agent");

            migrationBuilder.DropForeignKey(
                name: "FK_RealEstate_Agent_AgentRefId",
                table: "RealEstate");

            migrationBuilder.DropIndex(
                name: "IX_RealEstate_AgentRefId",
                table: "RealEstate");

            migrationBuilder.DropIndex(
                name: "IX_Agent_AgentId",
                table: "Agent");

            migrationBuilder.DropColumn(
                name: "AgentRefId",
                table: "RealEstate");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Agent");
        }
    }
}
