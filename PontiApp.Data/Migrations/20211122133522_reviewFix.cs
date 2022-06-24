using Microsoft.EntityFrameworkCore.Migrations;

namespace PontiApp.Data.Migrations
{
    public partial class reviewFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventReviews_Users_UserEntityId",
                table: "EventReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceReviews_Users_UserEntityId",
                table: "PlaceReviews");

            migrationBuilder.DropColumn(
                name: "EventReviewEntityId",
                table: "EventReviews");

            migrationBuilder.AlterColumn<int>(
                name: "UserEntityId",
                table: "PlaceReviews",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "UserEntityId",
                table: "EventReviews",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_EventReviews_Users_UserEntityId",
                table: "EventReviews",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceReviews_Users_UserEntityId",
                table: "PlaceReviews",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventReviews_Users_UserEntityId",
                table: "EventReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceReviews_Users_UserEntityId",
                table: "PlaceReviews");

            migrationBuilder.AlterColumn<int>(
                name: "UserEntityId",
                table: "PlaceReviews",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserEntityId",
                table: "EventReviews",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EventReviewEntityId",
                table: "EventReviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_EventReviews_Users_UserEntityId",
                table: "EventReviews",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceReviews_Users_UserEntityId",
                table: "PlaceReviews",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
