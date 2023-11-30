using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyServices.API.Migrations
{
    /// <inheritdoc />
    public partial class MakeLikeGeneric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsLikes_News_NewsPostId",
                table: "NewsLikes");

            migrationBuilder.DropIndex(
                name: "IX_NewsLikes_NewsPostId",
                table: "NewsLikes");

            migrationBuilder.DropColumn(
                name: "NewsPostId",
                table: "NewsLikes");

            migrationBuilder.AddColumn<Guid>(
                name: "LikedEntityId",
                table: "NewsLikes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewsLikes_LikedEntityId",
                table: "NewsLikes",
                column: "LikedEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsLikes_News_LikedEntityId",
                table: "NewsLikes",
                column: "LikedEntityId",
                principalTable: "News",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsLikes_News_LikedEntityId",
                table: "NewsLikes");

            migrationBuilder.DropIndex(
                name: "IX_NewsLikes_LikedEntityId",
                table: "NewsLikes");

            migrationBuilder.DropColumn(
                name: "LikedEntityId",
                table: "NewsLikes");

            migrationBuilder.AddColumn<Guid>(
                name: "NewsPostId",
                table: "NewsLikes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_NewsLikes_NewsPostId",
                table: "NewsLikes",
                column: "NewsPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsLikes_News_NewsPostId",
                table: "NewsLikes",
                column: "NewsPostId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
