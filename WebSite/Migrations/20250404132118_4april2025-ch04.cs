using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _4april2025ch04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Agent",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AgentComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tell = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsAccept = table.Column<bool>(type: "bit", nullable: true),
                    UserRefId = table.Column<int>(type: "int", nullable: true),
                    AgentRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentComment_Agent_AgentRefId",
                        column: x => x.AgentRefId,
                        principalTable: "Agent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgentComment_Users_UserRefId",
                        column: x => x.UserRefId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AgentMessage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SenderTell = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SenderEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", maxLength: 5000, nullable: true),
                    SendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsArchive = table.Column<bool>(type: "bit", nullable: true),
                    IsAnswer = table.Column<bool>(type: "bit", nullable: true),
                    AgentRefId = table.Column<int>(type: "int", nullable: true),
                    UserRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AgentMessage_Agent_AgentRefId",
                        column: x => x.AgentRefId,
                        principalTable: "Agent",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AgentMessage_Users_UserRefId",
                        column: x => x.UserRefId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AgentComment_AgentRefId",
                table: "AgentComment",
                column: "AgentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentComment_UserRefId",
                table: "AgentComment",
                column: "UserRefId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentMessage_AgentRefId",
                table: "AgentMessage",
                column: "AgentRefId");

            migrationBuilder.CreateIndex(
                name: "IX_AgentMessage_UserRefId",
                table: "AgentMessage",
                column: "UserRefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentComment");

            migrationBuilder.DropTable(
                name: "AgentMessage");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Agent");
        }
    }
}
