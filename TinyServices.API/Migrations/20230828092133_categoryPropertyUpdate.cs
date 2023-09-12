using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TinyServices.API.Migrations
{
    /// <inheritdoc />
    public partial class categoryPropertyUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProperties_Categories_CategoryId",
                table: "CategoryProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyValues_Advertisements_AdvertisementId",
                table: "PropertyValues");

            migrationBuilder.AlterColumn<Guid>(
                name: "AdvertisementId",
                table: "PropertyValues",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "CategoryProperties",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProperties_Categories_CategoryId",
                table: "CategoryProperties",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyValues_Advertisements_AdvertisementId",
                table: "PropertyValues",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryProperties_Categories_CategoryId",
                table: "CategoryProperties");

            migrationBuilder.DropForeignKey(
                name: "FK_PropertyValues_Advertisements_AdvertisementId",
                table: "PropertyValues");

            migrationBuilder.AlterColumn<Guid>(
                name: "AdvertisementId",
                table: "PropertyValues",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<Guid>(
                name: "CategoryId",
                table: "CategoryProperties",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryProperties_Categories_CategoryId",
                table: "CategoryProperties",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyValues_Advertisements_AdvertisementId",
                table: "PropertyValues",
                column: "AdvertisementId",
                principalTable: "Advertisements",
                principalColumn: "Id");
        }
    }
}
