using Microsoft.EntityFrameworkCore.Migrations;

namespace Projekt_ASP.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoriesCategoryId",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookCategory = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoriesCategoryId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoriesCategoryId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CategoriesCategoryId",
                table: "Books");
        }
    }
}
