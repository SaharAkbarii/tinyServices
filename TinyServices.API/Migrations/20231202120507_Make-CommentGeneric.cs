using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyServices.API.Migrations
{
    /// <inheritdoc />
    public partial class MakeCommentGeneric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsComments_News_NewsId",
                table: "NewsComments");

            migrationBuilder.DropIndex(
                name: "IX_NewsComments_NewsId",
                table: "NewsComments");

            migrationBuilder.DropColumn(
                name: "NewsId",
                table: "NewsComments");

            migrationBuilder.AddColumn<Guid>(
                name: "CommentEntityId",
                table: "NewsComments",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NewsComment<NewsComment<News>>Id",
                table: "NewsCommentLikes",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "NewsComment<NewsComment<News>>Id",
                table: "NewsCommentDisLikes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "NewsComment<NewsComment<News>>",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CommentEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    NewsUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    NewsCommentNewsCommentNewsId = table.Column<Guid>(name: "NewsComment<NewsComment<News>>Id", type: "uuid", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsComment<NewsComment<News>>", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsComment<NewsComment<News>>_NewsComment<NewsComment<News~",
                        column: x => x.NewsCommentNewsCommentNewsId,
                        principalTable: "NewsComment<NewsComment<News>>",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewsComment<NewsComment<News>>_NewsComments_CommentEntityId",
                        column: x => x.CommentEntityId,
                        principalTable: "NewsComments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_NewsComment<NewsComment<News>>_NewsUsers_NewsUserId",
                        column: x => x.NewsUserId,
                        principalTable: "NewsUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsComments_CommentEntityId",
                table: "NewsComments",
                column: "CommentEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsCommentLikes_NewsComment<NewsComment<News>>Id",
                table: "NewsCommentLikes",
                column: "NewsComment<NewsComment<News>>Id");

            migrationBuilder.CreateIndex(
                name: "IX_NewsCommentDisLikes_NewsComment<NewsComment<News>>Id",
                table: "NewsCommentDisLikes",
                column: "NewsComment<NewsComment<News>>Id");

            migrationBuilder.CreateIndex(
                name: "IX_NewsComment<NewsComment<News>>_CommentEntityId",
                table: "NewsComment<NewsComment<News>>",
                column: "CommentEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsComment<NewsComment<News>>_NewsComment<NewsComment<News~",
                table: "NewsComment<NewsComment<News>>",
                column: "NewsComment<NewsComment<News>>Id");

            migrationBuilder.CreateIndex(
                name: "IX_NewsComment<NewsComment<News>>_NewsUserId",
                table: "NewsComment<NewsComment<News>>",
                column: "NewsUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsCommentDisLikes_NewsComment<NewsComment<News>>_NewsComm~",
                table: "NewsCommentDisLikes",
                column: "NewsComment<NewsComment<News>>Id",
                principalTable: "NewsComment<NewsComment<News>>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsCommentLikes_NewsComment<NewsComment<News>>_NewsComment~",
                table: "NewsCommentLikes",
                column: "NewsComment<NewsComment<News>>Id",
                principalTable: "NewsComment<NewsComment<News>>",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsComments_News_CommentEntityId",
                table: "NewsComments",
                column: "CommentEntityId",
                principalTable: "News",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsCommentDisLikes_NewsComment<NewsComment<News>>_NewsComm~",
                table: "NewsCommentDisLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsCommentLikes_NewsComment<NewsComment<News>>_NewsComment~",
                table: "NewsCommentLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsComments_News_CommentEntityId",
                table: "NewsComments");

            migrationBuilder.DropTable(
                name: "NewsComment<NewsComment<News>>");

            migrationBuilder.DropIndex(
                name: "IX_NewsComments_CommentEntityId",
                table: "NewsComments");

            migrationBuilder.DropIndex(
                name: "IX_NewsCommentLikes_NewsComment<NewsComment<News>>Id",
                table: "NewsCommentLikes");

            migrationBuilder.DropIndex(
                name: "IX_NewsCommentDisLikes_NewsComment<NewsComment<News>>Id",
                table: "NewsCommentDisLikes");

            migrationBuilder.DropColumn(
                name: "CommentEntityId",
                table: "NewsComments");

            migrationBuilder.DropColumn(
                name: "NewsComment<NewsComment<News>>Id",
                table: "NewsCommentLikes");

            migrationBuilder.DropColumn(
                name: "NewsComment<NewsComment<News>>Id",
                table: "NewsCommentDisLikes");

            migrationBuilder.AddColumn<Guid>(
                name: "NewsId",
                table: "NewsComments",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_NewsComments_NewsId",
                table: "NewsComments",
                column: "NewsId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsComments_News_NewsId",
                table: "NewsComments",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
