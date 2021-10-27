using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PontiApp.Data.Migrations
{
    public partial class zoriak : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceReviews_Places_PlaceEntityId",
                table: "PlaceReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlacePics",
                table: "PlacePics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventReviews",
                table: "EventReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventPics",
                table: "EventPics");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "UserGuestPlaces",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "UserGuestEvents",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Places",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "PlaceReviewEntityId",
                table: "PlaceReviews",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "PlaceCategories",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Events",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "EventCategories",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Categories",
                newName: "IsDeleted");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WeekDays",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserGuestPlaces",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserGuestEvents",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PlaceReviews",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "PlacePicEntityId",
                table: "PlacePics",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "PlacePics",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "PlacePics",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "EventReviewEntityId",
                table: "EventReviews",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventReviews",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EventReviews",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "EventPicEntityId",
                table: "EventPics",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EventPics",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EventPics",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlacePics",
                table: "PlacePics",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventReviews",
                table: "EventReviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventPics",
                table: "EventPics",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceReviews_Places_PlaceEntityId",
                table: "PlaceReviews",
                column: "PlaceEntityId",
                principalTable: "Places",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlaceReviews_Places_PlaceEntityId",
                table: "PlaceReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlacePics",
                table: "PlacePics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventReviews",
                table: "EventReviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventPics",
                table: "EventPics");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WeekDays");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserGuestPlaces");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserGuestEvents");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PlaceReviews");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlacePics");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "PlacePics");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventReviews");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EventReviews");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EventPics");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EventPics");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "UserGuestPlaces",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "UserGuestEvents",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Places",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PlaceReviews",
                newName: "PlaceReviewEntityId");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "PlaceCategories",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Events",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "EventCategories",
                newName: "IsActive");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                table: "Categories",
                newName: "IsActive");

            migrationBuilder.AlterColumn<int>(
                name: "PlacePicEntityId",
                table: "PlacePics",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "EventReviewEntityId",
                table: "EventReviews",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "EventPicEntityId",
                table: "EventPics",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlacePics",
                table: "PlacePics",
                column: "PlacePicEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventReviews",
                table: "EventReviews",
                column: "EventReviewEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventPics",
                table: "EventPics",
                column: "EventPicEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlaceReviews_Places_PlaceEntityId",
                table: "PlaceReviews",
                column: "PlaceEntityId",
                principalTable: "Places",
                principalColumn: "Id");
        }
    }
}
