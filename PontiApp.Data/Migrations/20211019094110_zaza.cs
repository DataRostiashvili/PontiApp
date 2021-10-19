using Microsoft.EntityFrameworkCore.Migrations;

namespace PontiApp.Data.Migrations
{
    public partial class zaza : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCategories_Categories_CategoryEntityId",
                table: "EventCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCategories_Events_EventEntityId",
                table: "EventCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_EventPics_Events_EventEntityId",
                table: "EventPics");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReviews_Events_EventEntityId",
                table: "EventReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Places_PlaceEntityId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UserEntityId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceCategories_Categories_CategoryEntityId",
                table: "PlaceCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceCategories_Places_PlaceEntityId",
                table: "PlaceCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PlacePics_Places_PlaceEntityId",
                table: "PlacePics");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Users_UserEntityId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGuestEvents_Events_EventEntityId",
                table: "UserGuestEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGuestEvents_Users_UserEntityId",
                table: "UserGuestEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGuestPlaces_Places_PlaceEntityId",
                table: "UserGuestPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGuestPlaces_Users_UserEntityId",
                table: "UserGuestPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekDays_Places_PlaceEntityId",
                table: "WeekDays");

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategories_Categories_CategoryEntityId",
                table: "EventCategories",
                column: "CategoryEntityId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventCategories_Events_EventEntityId",
                table: "EventCategories",
                column: "EventEntityId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventPics_Events_EventEntityId",
                table: "EventPics",
                column: "EventEntityId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventReviews_Events_EventEntityId",
                table: "EventReviews",
                column: "EventEntityId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Places_PlaceEntityId",
                table: "Events",
                column: "PlaceEntityId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_UserEntityId",
                table: "Events",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceCategories_Categories_CategoryEntityId",
                table: "PlaceCategories",
                column: "CategoryEntityId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceCategories_Places_PlaceEntityId",
                table: "PlaceCategories",
                column: "PlaceEntityId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlacePics_Places_PlaceEntityId",
                table: "PlacePics",
                column: "PlaceEntityId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Users_UserEntityId",
                table: "Places",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuestEvents_Events_EventEntityId",
                table: "UserGuestEvents",
                column: "EventEntityId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuestEvents_Users_UserEntityId",
                table: "UserGuestEvents",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuestPlaces_Places_PlaceEntityId",
                table: "UserGuestPlaces",
                column: "PlaceEntityId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuestPlaces_Users_UserEntityId",
                table: "UserGuestPlaces",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WeekDays_Places_PlaceEntityId",
                table: "WeekDays",
                column: "PlaceEntityId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventCategories_Categories_CategoryEntityId",
                table: "EventCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_EventCategories_Events_EventEntityId",
                table: "EventCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_EventPics_Events_EventEntityId",
                table: "EventPics");

            migrationBuilder.DropForeignKey(
                name: "FK_EventReviews_Events_EventEntityId",
                table: "EventReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Places_PlaceEntityId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_UserEntityId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceCategories_Categories_CategoryEntityId",
                table: "PlaceCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PlaceCategories_Places_PlaceEntityId",
                table: "PlaceCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_PlacePics_Places_PlaceEntityId",
                table: "PlacePics");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_Users_UserEntityId",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGuestEvents_Events_EventEntityId",
                table: "UserGuestEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGuestEvents_Users_UserEntityId",
                table: "UserGuestEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGuestPlaces_Places_PlaceEntityId",
                table: "UserGuestPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGuestPlaces_Users_UserEntityId",
                table: "UserGuestPlaces");

            migrationBuilder.DropForeignKey(
                name: "FK_WeekDays_Places_PlaceEntityId",
                table: "WeekDays");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EventPics_Events_EventEntityId",
                table: "EventPics",
                column: "EventEntityId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventReviews_Events_EventEntityId",
                table: "EventReviews",
                column: "EventEntityId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Places_PlaceEntityId",
                table: "Events",
                column: "PlaceEntityId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_UserEntityId",
                table: "Events",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceCategories_Categories_CategoryEntityId",
                table: "PlaceCategories",
                column: "CategoryEntityId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceCategories_Places_PlaceEntityId",
                table: "PlaceCategories",
                column: "PlaceEntityId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlacePics_Places_PlaceEntityId",
                table: "PlacePics",
                column: "PlaceEntityId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_Users_UserEntityId",
                table: "Places",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuestEvents_Events_EventEntityId",
                table: "UserGuestEvents",
                column: "EventEntityId",
                principalTable: "Events",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuestEvents_Users_UserEntityId",
                table: "UserGuestEvents",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuestPlaces_Places_PlaceEntityId",
                table: "UserGuestPlaces",
                column: "PlaceEntityId",
                principalTable: "Places",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGuestPlaces_Users_UserEntityId",
                table: "UserGuestPlaces",
                column: "UserEntityId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WeekDays_Places_PlaceEntityId",
                table: "WeekDays",
                column: "PlaceEntityId",
                principalTable: "Places",
                principalColumn: "Id");
        }
    }
}
