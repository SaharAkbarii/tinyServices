using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyServices.API.Migrations
{
    /// <inheritdoc />
    public partial class MakedisLikeComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsDisLikes_News_LikedEntityId",
                table: "NewsDisLikes");

            migrationBuilder.RenameColumn(
                name: "LikedEntityId",
                table: "NewsDisLikes",
                newName: "DisLikedEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsDisLikes_LikedEntityId",
                table: "NewsDisLikes",
                newName: "IX_NewsDisLikes_DisLikedEntityId");

            migrationBuilder.CreateTable(
                name: "NewsCommentDisLikes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DisLikedEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    NewsUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsCommentDisLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsCommentDisLikes_NewsComments_DisLikedEntityId",
                        column: x => x.DisLikedEntityId,
                        principalTable: "NewsComments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewsCommentDisLikes_NewsUsers_NewsUserId",
                        column: x => x.NewsUserId,
                        principalTable: "NewsUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsCommentDisLikes_DisLikedEntityId",
                table: "NewsCommentDisLikes",
                column: "DisLikedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsCommentDisLikes_NewsUserId",
                table: "NewsCommentDisLikes",
                column: "NewsUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsDisLikes_News_DisLikedEntityId",
                table: "NewsDisLikes",
                column: "DisLikedEntityId",
                principalTable: "News",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsDisLikes_News_DisLikedEntityId",
                table: "NewsDisLikes");

            migrationBuilder.DropTable(
                name: "NewsCommentDisLikes");

            migrationBuilder.RenameColumn(
                name: "DisLikedEntityId",
                table: "NewsDisLikes",
                newName: "LikedEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsDisLikes_DisLikedEntityId",
                table: "NewsDisLikes",
                newName: "IX_NewsDisLikes_LikedEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsDisLikes_News_LikedEntityId",
                table: "NewsDisLikes",
                column: "LikedEntityId",
                principalTable: "News",
                principalColumn: "Id");
        }
    }
}
