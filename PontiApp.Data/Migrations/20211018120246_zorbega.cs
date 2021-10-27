using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PontiApp.Data.Migrations
{
    public partial class zorbega : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaceCategories",
                table: "PlaceCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories");

            migrationBuilder.RenameColumn(
                name: "WeekEntityId",
                table: "WeekDays",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlaceCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventCategories",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaceCategories",
                table: "PlaceCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceCategories_PlaceEntityId",
                table: "PlaceCategories",
                column: "PlaceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventCategories_EventEntityId",
                table: "EventCategories",
                column: "EventEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaceCategories",
                table: "PlaceCategories");

            migrationBuilder.DropIndex(
                name: "IX_PlaceCategories_PlaceEntityId",
                table: "PlaceCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories");

            migrationBuilder.DropIndex(
                name: "IX_EventCategories_EventEntityId",
                table: "EventCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlaceCategories");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventCategories");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "WeekDays",
                newName: "WeekEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaceCategories",
                table: "PlaceCategories",
                columns: new[] { "PlaceEntityId", "CategoryEntityId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories",
                columns: new[] { "EventEntityId", "CategoryEntityId" });
        }
    }
}
