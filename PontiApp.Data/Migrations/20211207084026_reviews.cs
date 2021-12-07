using Microsoft.EntityFrameworkCore.Migrations;

namespace PontiApp.Data.Migrations
{
    public partial class reviews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventReviews_Users_UserEntityId",
                table: "EventReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceReviews_Users_UserEntityId",
                table: "PlaceReviews");

            migrationBuilder.DropIndex(
                name: "IX_PlaceReviews_UserEntityId",
                table: "PlaceReviews");

            migrationBuilder.DropIndex(
                name: "IX_EventReviews_UserEntityId",
                table: "EventReviews");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "PlaceReviews");

            migrationBuilder.DropColumn(
                name: "UserEntityId",
                table: "EventReviews");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "PlaceReviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "EventReviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlaceReviews_UserId",
                table: "PlaceReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventReviews_UserId",
                table: "EventReviews",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventReviews_Users_UserId",
                table: "EventReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceReviews_Users_UserId",
                table: "PlaceReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventReviews_Users_UserId",
                table: "EventReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceReviews_Users_UserId",
                table: "PlaceReviews");

            migrationBuilder.DropIndex(
                name: "IX_PlaceReviews_UserId",
                table: "PlaceReviews");

            migrationBuilder.DropIndex(
                name: "IX_EventReviews_UserId",
                table: "EventReviews");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "PlaceReviews");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "EventReviews");

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "PlaceReviews",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserEntityId",
                table: "EventReviews",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlaceReviews_UserEntityId",
                table: "PlaceReviews",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventReviews_UserEntityId",
                table: "EventReviews",
                column: "UserEntityId");

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
    }
}
