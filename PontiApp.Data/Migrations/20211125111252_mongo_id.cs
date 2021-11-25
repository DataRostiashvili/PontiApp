using Microsoft.EntityFrameworkCore.Migrations;

namespace PontiApp.Data.Migrations
{
    public partial class mongo_id : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PicturesId",
                table: "Places",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PicturesId",
                table: "Events",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PicturesId",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "PicturesId",
                table: "Events");
        }
    }
}
