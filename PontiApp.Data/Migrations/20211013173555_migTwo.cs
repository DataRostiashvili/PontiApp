using Microsoft.EntityFrameworkCore.Migrations;

namespace PontiApp.Data.Migrations
{
    public partial class migTwo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryEntityId",
                table: "Categories",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryEntityId");
        }
    }
}
