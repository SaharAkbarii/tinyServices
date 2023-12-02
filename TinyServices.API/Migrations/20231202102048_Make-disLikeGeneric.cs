using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyServices.API.Migrations
{
    /// <inheritdoc />
    public partial class MakedisLikeGeneric : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsDisLikes_News_NewsPostId",
                table: "NewsDisLikes");

            migrationBuilder.DropIndex(
                name: "IX_NewsDisLikes_NewsPostId",
                table: "NewsDisLikes");

            migrationBuilder.DropColumn(
                name: "NewsPostId",
                table: "NewsDisLikes");

            migrationBuilder.AddColumn<Guid>(
                name: "LikedEntityId",
                table: "NewsDisLikes",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_NewsDisLikes_LikedEntityId",
                table: "NewsDisLikes",
                column: "LikedEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsDisLikes_News_LikedEntityId",
                table: "NewsDisLikes",
                column: "LikedEntityId",
                principalTable: "News",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsDisLikes_News_LikedEntityId",
                table: "NewsDisLikes");

            migrationBuilder.DropIndex(
                name: "IX_NewsDisLikes_LikedEntityId",
                table: "NewsDisLikes");

            migrationBuilder.DropColumn(
                name: "LikedEntityId",
                table: "NewsDisLikes");

            migrationBuilder.AddColumn<Guid>(
                name: "NewsPostId",
                table: "NewsDisLikes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_NewsDisLikes_NewsPostId",
                table: "NewsDisLikes",
                column: "NewsPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsDisLikes_News_NewsPostId",
                table: "NewsDisLikes",
                column: "NewsPostId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
