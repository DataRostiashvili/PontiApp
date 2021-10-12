using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PontiApp.Data.Migrations
{
    public partial class firstMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cetegory = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surename = table.Column<string>(type: "text", nullable: true),
                    Mail = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    AverageRanking = table.Column<float>(type: "real", nullable: false),
                    TotalReviewerCount = table.Column<int>(type: "integer", nullable: false),
                    IsVerifiedUser = table.Column<bool>(type: "boolean", nullable: false),
                    MongoKey = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    QueueId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Places",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Mail = table.Column<string>(type: "text", nullable: true),
                    TicketBuyUrl = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UserEntityId = table.Column<int>(type: "integer", nullable: false),
                    QueueId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Places", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Places_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Mail = table.Column<string>(type: "text", nullable: true),
                    TicketBuyUrl = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    PlaceEntityId = table.Column<int>(type: "integer", nullable: false),
                    UserEntityId = table.Column<int>(type: "integer", nullable: false),
                    QueueId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Places_PlaceEntityId",
                        column: x => x.PlaceEntityId,
                        principalTable: "Places",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Events_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlaceCategories",
                columns: table => new
                {
                    PlaceEntityId = table.Column<int>(type: "integer", nullable: false),
                    CategoryEntityId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceCategories", x => new { x.PlaceEntityId, x.CategoryEntityId });
                    table.ForeignKey(
                        name: "FK_PlaceCategories_Categories_CategoryEntityId",
                        column: x => x.CategoryEntityId,
                        principalTable: "Categories",
                        principalColumn: "CategoryEntityId");
                    table.ForeignKey(
                        name: "FK_PlaceCategories_Places_PlaceEntityId",
                        column: x => x.PlaceEntityId,
                        principalTable: "Places",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlacePics",
                columns: table => new
                {
                    PlacePicEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MongoKey = table.Column<string>(type: "text", nullable: true),
                    PlaceEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacePics", x => x.PlacePicEntityId);
                    table.ForeignKey(
                        name: "FK_PlacePics_Places_PlaceEntityId",
                        column: x => x.PlaceEntityId,
                        principalTable: "Places",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PlaceReviews",
                columns: table => new
                {
                    PlaceReviewEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReviewRanking = table.Column<float>(type: "real", nullable: false),
                    UserEntityId = table.Column<int>(type: "integer", nullable: false),
                    PlaceEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceReviews", x => x.PlaceReviewEntityId);
                    table.ForeignKey(
                        name: "FK_PlaceReviews_Places_PlaceEntityId",
                        column: x => x.PlaceEntityId,
                        principalTable: "Places",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PlaceReviews_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGuestPlaces",
                columns: table => new
                {
                    PlaceEntityId = table.Column<int>(type: "integer", nullable: false),
                    UserEntityId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGuestPlaces", x => new { x.PlaceEntityId, x.UserEntityId });
                    table.ForeignKey(
                        name: "FK_UserGuestPlaces_Places_PlaceEntityId",
                        column: x => x.PlaceEntityId,
                        principalTable: "Places",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGuestPlaces_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WeekDays",
                columns: table => new
                {
                    WeekEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    PlaceEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekDays", x => x.WeekEntityId);
                    table.ForeignKey(
                        name: "FK_WeekDays_Places_PlaceEntityId",
                        column: x => x.PlaceEntityId,
                        principalTable: "Places",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventPics",
                columns: table => new
                {
                    EventPicEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MongoKey = table.Column<string>(type: "text", nullable: true),
                    EventEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPics", x => x.EventPicEntityId);
                    table.ForeignKey(
                        name: "FK_EventPics_Events_EventEntityId",
                        column: x => x.EventEntityId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EventReviews",
                columns: table => new
                {
                    EventReviewEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReviewRanking = table.Column<float>(type: "real", nullable: false),
                    UserEntityId = table.Column<int>(type: "integer", nullable: false),
                    EventEntityId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventReviews", x => x.EventReviewEntityId);
                    table.ForeignKey(
                        name: "FK_EventReviews_Events_EventEntityId",
                        column: x => x.EventEntityId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventReviews_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EveventCategories",
                columns: table => new
                {
                    EventEntityId = table.Column<int>(type: "integer", nullable: false),
                    CategoryEntityId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EveventCategories", x => new { x.EventEntityId, x.CategoryEntityId });
                    table.ForeignKey(
                        name: "FK_EveventCategories_Categories_CategoryEntityId",
                        column: x => x.CategoryEntityId,
                        principalTable: "Categories",
                        principalColumn: "CategoryEntityId");
                    table.ForeignKey(
                        name: "FK_EveventCategories_Events_EventEntityId",
                        column: x => x.EventEntityId,
                        principalTable: "Events",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserGuestEvents",
                columns: table => new
                {
                    EventEntityId = table.Column<int>(type: "integer", nullable: false),
                    UserEntityId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGuestEvents", x => new { x.EventEntityId, x.UserEntityId });
                    table.ForeignKey(
                        name: "FK_UserGuestEvents_Events_EventEntityId",
                        column: x => x.EventEntityId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGuestEvents_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventPics_EventEntityId",
                table: "EventPics",
                column: "EventEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventReviews_EventEntityId",
                table: "EventReviews",
                column: "EventEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventReviews_UserEntityId",
                table: "EventReviews",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_PlaceEntityId",
                table: "Events",
                column: "PlaceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserEntityId",
                table: "Events",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EveventCategories_CategoryEntityId",
                table: "EveventCategories",
                column: "CategoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceCategories_CategoryEntityId",
                table: "PlaceCategories",
                column: "CategoryEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlacePics_PlaceEntityId",
                table: "PlacePics",
                column: "PlaceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceReviews_PlaceEntityId",
                table: "PlaceReviews",
                column: "PlaceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceReviews_UserEntityId",
                table: "PlaceReviews",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Places_UserEntityId",
                table: "Places",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGuestEvents_UserEntityId",
                table: "UserGuestEvents",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGuestPlaces_UserEntityId",
                table: "UserGuestPlaces",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekDays_PlaceEntityId",
                table: "WeekDays",
                column: "PlaceEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventPics");

            migrationBuilder.DropTable(
                name: "EventReviews");

            migrationBuilder.DropTable(
                name: "EveventCategories");

            migrationBuilder.DropTable(
                name: "PlaceCategories");

            migrationBuilder.DropTable(
                name: "PlacePics");

            migrationBuilder.DropTable(
                name: "PlaceReviews");

            migrationBuilder.DropTable(
                name: "UserGuestEvents");

            migrationBuilder.DropTable(
                name: "UserGuestPlaces");

            migrationBuilder.DropTable(
                name: "WeekDays");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Places");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
