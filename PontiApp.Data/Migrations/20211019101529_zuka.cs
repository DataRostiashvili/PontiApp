using Microsoft.EntityFrameworkCore.Migrations;

namespace PontiApp.Data.Migrations
{
    public partial class zuka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Places_PlaceEntityId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceEntityId",
                table: "Events",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Places_PlaceEntityId",
                table: "Events",
                column: "PlaceEntityId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_Places_PlaceEntityId",
                table: "Events");

            migrationBuilder.AlterColumn<int>(
                name: "PlaceEntityId",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Places_PlaceEntityId",
                table: "Events",
                column: "PlaceEntityId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
