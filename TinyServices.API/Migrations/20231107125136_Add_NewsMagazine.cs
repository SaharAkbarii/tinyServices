using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyServices.API.Migrations
{
    /// <inheritdoc />
    public partial class Add_NewsMagazine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PublishAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    NewsNumber = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email_Value = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NewsComment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NewsId = table.Column<Guid>(type: "uuid", nullable: false),
                    NewsUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsComment_NewsUsers_NewsUserId",
                        column: x => x.NewsUserId,
                        principalTable: "NewsUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsComment_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsDisLike",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NewsPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    NewsUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsDisLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsDisLike_NewsUsers_NewsUserId",
                        column: x => x.NewsUserId,
                        principalTable: "NewsUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsDisLike_News_NewsPostId",
                        column: x => x.NewsPostId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NewsLike",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    NewsPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    NewsUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NewsLike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NewsLike_NewsUsers_NewsUserId",
                        column: x => x.NewsUserId,
                        principalTable: "NewsUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NewsLike_News_NewsPostId",
                        column: x => x.NewsPostId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NewsComment_NewsId",
                table: "NewsComment",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsComment_NewsUserId",
                table: "NewsComment",
                column: "NewsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsDisLike_NewsPostId",
                table: "NewsDisLike",
                column: "NewsPostId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsDisLike_NewsUserId",
                table: "NewsDisLike",
                column: "NewsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsLike_NewsPostId",
                table: "NewsLike",
                column: "NewsPostId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsLike_NewsUserId",
                table: "NewsLike",
                column: "NewsUserId");

            migrationBuilder.CreateIndex(
                name: "IX_NewsUsers_Email_Value",
                table: "NewsUsers",
                column: "Email_Value",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NewsComment");

            migrationBuilder.DropTable(
                name: "NewsDisLike");

            migrationBuilder.DropTable(
                name: "NewsLike");

            migrationBuilder.DropTable(
                name: "NewsUsers");

            migrationBuilder.DropTable(
                name: "News");
        }
    }
}
