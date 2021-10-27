using Microsoft.EntityFrameworkCore.Migrations;

namespace PontiApp.Data.Migrations
{
    public partial class _0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EveventCategories_Categories_CategoryEntityId",
                table: "EveventCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_EveventCategories_Events_EventEntityId",
                table: "EveventCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EveventCategories",
                table: "EveventCategories");

            migrationBuilder.RenameTable(
                name: "EveventCategories",
                newName: "EventCategories");

            migrationBuilder.RenameIndex(
                name: "IX_EveventCategories_CategoryEntityId",
                table: "EventCategories",
                newName: "IX_EventCategories_CategoryEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories",
                columns: new[] { "EventEntityId", "CategoryEntityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategories_Categories_CategoryEntityId",
                table: "EventCategories",
                column: "CategoryEntityId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategories_Events_EventEntityId",
                table: "EventCategories",
                column: "EventEntityId",
                principalTable: "Events",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCategories_Categories_CategoryEntityId",
                table: "EventCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCategories_Events_EventEntityId",
                table: "EventCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories");

            migrationBuilder.RenameTable(
                name: "EventCategories",
                newName: "EveventCategories");

            migrationBuilder.RenameIndex(
                name: "IX_EventCategories_CategoryEntityId",
                table: "EveventCategories",
                newName: "IX_EveventCategories_CategoryEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EveventCategories",
                table: "EveventCategories",
                columns: new[] { "EventEntityId", "CategoryEntityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EveventCategories_Categories_CategoryEntityId",
                table: "EveventCategories",
                column: "CategoryEntityId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EveventCategories_Events_EventEntityId",
                table: "EveventCategories",
                column: "EventEntityId",
                principalTable: "Events",
                principalColumn: "Id");
        }
    }
}
