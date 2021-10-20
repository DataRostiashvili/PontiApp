using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PontiApp.Data.Migrations
{
    public partial class meramdeneUkve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PlaceCategories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EventCategories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaceCategories",
                table: "PlaceCategories",
                columns: new[] { "PlaceEntityId", "CategoryEntityId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories",
                columns: new[] { "EventEntityId", "CategoryEntityId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaceCategories",
                table: "PlaceCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventCategories",
                table: "EventCategories");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "PlaceCategories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "EventCategories",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
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
    }
}
