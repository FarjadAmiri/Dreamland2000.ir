using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _29march2025ch05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agent_Agent_AgentId",
                table: "Agent");

            migrationBuilder.DropIndex(
                name: "IX_Agent_AgentId",
                table: "Agent");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Agent");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgentId",
                table: "Agent",
                type: "int",
                nullable: true);

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
        }
    }
}
