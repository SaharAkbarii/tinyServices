using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyServices.API.Migrations
{
    /// <inheritdoc />
    public partial class Add_EmailToLinkedinUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LinkedinUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Email_Value = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedinUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "linkedinPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ImageUrls = table.Column<List<string>>(type: "text[]", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_linkedinPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_linkedinPosts_LinkedinUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "LinkedinUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedinPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedinUserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_LinkedinUsers_LinkedinUserId",
                        column: x => x.LinkedinUserId,
                        principalTable: "LinkedinUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_linkedinPosts_LinkedinPostId",
                        column: x => x.LinkedinPostId,
                        principalTable: "linkedinPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedinPostId = table.Column<Guid>(type: "uuid", nullable: false),
                    LinkedinUserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_LinkedinUsers_LinkedinUserId",
                        column: x => x.LinkedinUserId,
                        principalTable: "LinkedinUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_linkedinPosts_LinkedinPostId",
                        column: x => x.LinkedinPostId,
                        principalTable: "linkedinPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_LinkedinPostId",
                table: "Comments",
                column: "LinkedinPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_LinkedinUserId",
                table: "Comments",
                column: "LinkedinUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LinkedinPostId",
                table: "Likes",
                column: "LinkedinPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LinkedinUserId",
                table: "Likes",
                column: "LinkedinUserId");

            migrationBuilder.CreateIndex(
                name: "IX_linkedinPosts_UserId",
                table: "linkedinPosts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LinkedinUsers_Email_Value",
                table: "LinkedinUsers",
                column: "Email_Value",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "linkedinPosts");

            migrationBuilder.DropTable(
                name: "LinkedinUsers");
        }
    }
}
