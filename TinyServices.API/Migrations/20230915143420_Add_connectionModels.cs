using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyServices.API.Migrations
{
    /// <inheritdoc />
    public partial class Add_connectionModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConnectionRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SenderId = table.Column<Guid>(type: "uuid", nullable: false),
                    ReceiverId = table.Column<Guid>(type: "uuid", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConnectionRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConnectionRequests_LinkedinUsers_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "LinkedinUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConnectionRequests_LinkedinUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "LinkedinUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ConnectionUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Connections_LinkedinUsers_ConnectionUserId",
                        column: x => x.ConnectionUserId,
                        principalTable: "LinkedinUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Connections_LinkedinUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "LinkedinUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionRequests_ReceiverId",
                table: "ConnectionRequests",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_ConnectionRequests_SenderId",
                table: "ConnectionRequests",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_ConnectionUserId",
                table: "Connections",
                column: "ConnectionUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Connections_UserId",
                table: "Connections",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConnectionRequests");

            migrationBuilder.DropTable(
                name: "Connections");
        }
    }
}
