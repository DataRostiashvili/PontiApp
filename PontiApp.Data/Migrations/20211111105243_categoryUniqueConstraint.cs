using Microsoft.EntityFrameworkCore.Migrations;

namespace PontiApp.Data.Migrations
{
    public partial class categoryUniqueConstraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Categories_Category",
                table: "Categories",
                column: "Category",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Categories_Category",
                table: "Categories");
        }
    }
}
