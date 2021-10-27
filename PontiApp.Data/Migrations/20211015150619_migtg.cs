using Microsoft.EntityFrameworkCore.Migrations;

namespace PontiApp.Data.Migrations
{
    public partial class migtg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "PlaceCategories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "EveventCategories",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "PlaceCategories");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "EveventCategories");
        }
    }
}
