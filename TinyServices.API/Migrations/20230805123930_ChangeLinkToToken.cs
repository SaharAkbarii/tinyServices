using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyServices.API.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLinkToToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShortenLink",
                table: "ShortLinks",
                newName: "Token");

            migrationBuilder.RenameColumn(
                name: "ShortenLink",
                table: "DeepLinks",
                newName: "Token");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Token",
                table: "ShortLinks",
                newName: "ShortenLink");

            migrationBuilder.RenameColumn(
                name: "Token",
                table: "DeepLinks",
                newName: "ShortenLink");
        }
    }
}
