using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_ASP.Migrations
{
    public partial class m6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoriesCategoryId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoriesCategoryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "Categories",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "CategoriesCategoryId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoriesCategoryId",
                table: "Books",
                column: "CategoriesCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoriesCategoryId",
                table: "Books",
                column: "CategoriesCategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
