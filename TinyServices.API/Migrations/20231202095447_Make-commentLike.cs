using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyServices.API.Migrations
{
    /// <inheritdoc />
    public partial class MakecommentLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NewsCommentLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LikedEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    NewsUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCommentLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsCommentLikes_NewsComments_LikedEntityId",
                        column: x => x.LikedEntityId,
                        principalTable: "NewsComments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewsCommentLikes_NewsUsers_NewsUserId",
                        column: x => x.NewsUserId,
                        principalTable: "NewsUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsCommentLikes_LikedEntityId",
                table: "NewsCommentLikes",
                column: "LikedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsCommentLikes_NewsUserId",
                table: "NewsCommentLikes",
                column: "NewsUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsCommentLikes");
        }
    }
}
