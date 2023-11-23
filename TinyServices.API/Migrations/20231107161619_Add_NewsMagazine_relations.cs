using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyServices.API.Migrations
{
    /// <inheritdoc />
    public partial class Add_NewsMagazine_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsComment_NewsUsers_NewsUserId",
                table: "NewsComment");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsComment_News_NewsId",
                table: "NewsComment");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsDisLike_NewsUsers_NewsUserId",
                table: "NewsDisLike");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsDisLike_News_NewsPostId",
                table: "NewsDisLike");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsLike_NewsUsers_NewsUserId",
                table: "NewsLike");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsLike_News_NewsPostId",
                table: "NewsLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsLike",
                table: "NewsLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsDisLike",
                table: "NewsDisLike");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsComment",
                table: "NewsComment");

            migrationBuilder.RenameTable(
                name: "NewsLike",
                newName: "NewsLikes");

            migrationBuilder.RenameTable(
                name: "NewsDisLike",
                newName: "NewsDisLikes");

            migrationBuilder.RenameTable(
                name: "NewsComment",
                newName: "NewsComments");

            migrationBuilder.RenameIndex(
                name: "IX_NewsLike_NewsUserId",
                table: "NewsLikes",
                newName: "IX_NewsLikes_NewsUserId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsLike_NewsPostId",
                table: "NewsLikes",
                newName: "IX_NewsLikes_NewsPostId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsDisLike_NewsUserId",
                table: "NewsDisLikes",
                newName: "IX_NewsDisLikes_NewsUserId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsDisLike_NewsPostId",
                table: "NewsDisLikes",
                newName: "IX_NewsDisLikes_NewsPostId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsComment_NewsUserId",
                table: "NewsComments",
                newName: "IX_NewsComments_NewsUserId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsComment_NewsId",
                table: "NewsComments",
                newName: "IX_NewsComments_NewsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsLikes",
                table: "NewsLikes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsDisLikes",
                table: "NewsDisLikes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsComments",
                table: "NewsComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsComments_NewsUsers_NewsUserId",
                table: "NewsComments",
                column: "NewsUserId",
                principalTable: "NewsUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsComments_News_NewsId",
                table: "NewsComments",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsDisLikes_NewsUsers_NewsUserId",
                table: "NewsDisLikes",
                column: "NewsUserId",
                principalTable: "NewsUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsDisLikes_News_NewsPostId",
                table: "NewsDisLikes",
                column: "NewsPostId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsLikes_NewsUsers_NewsUserId",
                table: "NewsLikes",
                column: "NewsUserId",
                principalTable: "NewsUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsLikes_News_NewsPostId",
                table: "NewsLikes",
                column: "NewsPostId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NewsComments_NewsUsers_NewsUserId",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsComments_News_NewsId",
                table: "NewsComments");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsDisLikes_NewsUsers_NewsUserId",
                table: "NewsDisLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsDisLikes_News_NewsPostId",
                table: "NewsDisLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsLikes_NewsUsers_NewsUserId",
                table: "NewsLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_NewsLikes_News_NewsPostId",
                table: "NewsLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsLikes",
                table: "NewsLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsDisLikes",
                table: "NewsDisLikes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NewsComments",
                table: "NewsComments");

            migrationBuilder.RenameTable(
                name: "NewsLikes",
                newName: "NewsLike");

            migrationBuilder.RenameTable(
                name: "NewsDisLikes",
                newName: "NewsDisLike");

            migrationBuilder.RenameTable(
                name: "NewsComments",
                newName: "NewsComment");

            migrationBuilder.RenameIndex(
                name: "IX_NewsLikes_NewsUserId",
                table: "NewsLike",
                newName: "IX_NewsLike_NewsUserId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsLikes_NewsPostId",
                table: "NewsLike",
                newName: "IX_NewsLike_NewsPostId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsDisLikes_NewsUserId",
                table: "NewsDisLike",
                newName: "IX_NewsDisLike_NewsUserId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsDisLikes_NewsPostId",
                table: "NewsDisLike",
                newName: "IX_NewsDisLike_NewsPostId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsComments_NewsUserId",
                table: "NewsComment",
                newName: "IX_NewsComment_NewsUserId");

            migrationBuilder.RenameIndex(
                name: "IX_NewsComments_NewsId",
                table: "NewsComment",
                newName: "IX_NewsComment_NewsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsLike",
                table: "NewsLike",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsDisLike",
                table: "NewsDisLike",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewsComment",
                table: "NewsComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NewsComment_NewsUsers_NewsUserId",
                table: "NewsComment",
                column: "NewsUserId",
                principalTable: "NewsUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsComment_News_NewsId",
                table: "NewsComment",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsDisLike_NewsUsers_NewsUserId",
                table: "NewsDisLike",
                column: "NewsUserId",
                principalTable: "NewsUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsDisLike_News_NewsPostId",
                table: "NewsDisLike",
                column: "NewsPostId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsLike_NewsUsers_NewsUserId",
                table: "NewsLike",
                column: "NewsUserId",
                principalTable: "NewsUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NewsLike_News_NewsPostId",
                table: "NewsLike",
                column: "NewsPostId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
