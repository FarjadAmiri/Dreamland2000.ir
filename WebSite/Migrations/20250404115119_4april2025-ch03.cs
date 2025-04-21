using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebSite.Migrations
{
    /// <inheritdoc />
    public partial class _4april2025ch03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Service",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ServiceComment",
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
                    ServiceRefId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceComment_Service_ServiceRefId",
                        column: x => x.ServiceRefId,
                        principalTable: "Service",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ServiceComment_Users_UserRefId",
                        column: x => x.UserRefId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceComment_ServiceRefId",
                table: "ServiceComment",
                column: "ServiceRefId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceComment_UserRefId",
                table: "ServiceComment",
                column: "UserRefId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceComment");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Service");
        }
    }
}
