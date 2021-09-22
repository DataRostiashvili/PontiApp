using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PontiApp.Data.Migrations
{
    public partial class initMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Mail = table.Column<string>(type: "text", nullable: true),
                    TicketBuyUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surename = table.Column<string>(type: "text", nullable: true),
                    Mail = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    AverageRanking = table.Column<float>(type: "real", nullable: false),
                    TotalReviewerCount = table.Column<int>(type: "integer", nullable: false),
                    IsVerifiedUser = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserEntityId);
                });

            migrationBuilder.CreateTable(
                name: "EventPicEntity",
                columns: table => new
                {
                    EventPicEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uri = table.Column<string>(type: "text", nullable: true),
                    EventEntityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPicEntity", x => x.EventPicEntityId);
                    table.ForeignKey(
                        name: "FK_EventPicEntity_Events_EventEntityId",
                        column: x => x.EventEntityId,
                        principalTable: "Events",
                        principalColumn: "EventEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventReviewEntity",
                columns: table => new
                {
                    EventReviewEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReviewRanking = table.Column<float>(type: "real", nullable: false),
                    EventEntityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventReviewEntity", x => x.EventReviewEntityId);
                    table.ForeignKey(
                        name: "FK_EventReviewEntity_Events_EventEntityId",
                        column: x => x.EventEntityId,
                        principalTable: "Events",
                        principalColumn: "EventEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaceEntity",
                columns: table => new
                {
                    PlaceEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Mail = table.Column<string>(type: "text", nullable: true),
                    TicketBuyUrl = table.Column<string>(type: "text", nullable: true),
                    EventRef = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceEntity", x => x.PlaceEntityId);
                    table.ForeignKey(
                        name: "FK_PlaceEntity_Events_EventRef",
                        column: x => x.EventRef,
                        principalTable: "Events",
                        principalColumn: "EventEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePicEntity",
                columns: table => new
                {
                    ProfilePicEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uri = table.Column<string>(type: "text", nullable: true),
                    UserRef = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePicEntity", x => x.ProfilePicEntityId);
                    table.ForeignKey(
                        name: "FK_ProfilePicEntity_Users_UserRef",
                        column: x => x.UserRef,
                        principalTable: "Users",
                        principalColumn: "UserEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlacePicEntity",
                columns: table => new
                {
                    PlacePicEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uri = table.Column<string>(type: "text", nullable: true),
                    PlaceEntityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlacePicEntity", x => x.PlacePicEntityId);
                    table.ForeignKey(
                        name: "FK_PlacePicEntity_PlaceEntity_PlaceEntityId",
                        column: x => x.PlaceEntityId,
                        principalTable: "PlaceEntity",
                        principalColumn: "PlaceEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlaceReviewEntity",
                columns: table => new
                {
                    PlaceReviewEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ReviewRanking = table.Column<float>(type: "real", nullable: false),
                    PlaceEntityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaceReviewEntity", x => x.PlaceReviewEntityId);
                    table.ForeignKey(
                        name: "FK_PlaceReviewEntity_PlaceEntity_PlaceEntityId",
                        column: x => x.PlaceEntityId,
                        principalTable: "PlaceEntity",
                        principalColumn: "PlaceEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserGuestEvents",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PlaceEntityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGuestEvents", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserGuestEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGuestEvents_PlaceEntity_PlaceEntityId",
                        column: x => x.PlaceEntityId,
                        principalTable: "PlaceEntity",
                        principalColumn: "PlaceEntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserGuestEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHostEvents",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    PlaceEntityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHostEvents", x => new { x.EventId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserHostEvents_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHostEvents_PlaceEntity_PlaceEntityId",
                        column: x => x.PlaceEntityId,
                        principalTable: "PlaceEntity",
                        principalColumn: "PlaceEntityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserHostEvents_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserEntityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeekEntity",
                columns: table => new
                {
                    WeekEntityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Start = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    End = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    PlaceEntityId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeekEntity", x => x.WeekEntityId);
                    table.ForeignKey(
                        name: "FK_WeekEntity_PlaceEntity_PlaceEntityId",
                        column: x => x.PlaceEntityId,
                        principalTable: "PlaceEntity",
                        principalColumn: "PlaceEntityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventPicEntity_EventEntityId",
                table: "EventPicEntity",
                column: "EventEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EventReviewEntity_EventEntityId",
                table: "EventReviewEntity",
                column: "EventEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceEntity_EventRef",
                table: "PlaceEntity",
                column: "EventRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlacePicEntity_PlaceEntityId",
                table: "PlacePicEntity",
                column: "PlaceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaceReviewEntity_PlaceEntityId",
                table: "PlaceReviewEntity",
                column: "PlaceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePicEntity_UserRef",
                table: "ProfilePicEntity",
                column: "UserRef",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGuestEvents_PlaceEntityId",
                table: "UserGuestEvents",
                column: "PlaceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserGuestEvents_UserId",
                table: "UserGuestEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHostEvents_PlaceEntityId",
                table: "UserHostEvents",
                column: "PlaceEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHostEvents_UserId",
                table: "UserHostEvents",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_WeekEntity_PlaceEntityId",
                table: "WeekEntity",
                column: "PlaceEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventPicEntity");

            migrationBuilder.DropTable(
                name: "EventReviewEntity");

            migrationBuilder.DropTable(
                name: "PlacePicEntity");

            migrationBuilder.DropTable(
                name: "PlaceReviewEntity");

            migrationBuilder.DropTable(
                name: "ProfilePicEntity");

            migrationBuilder.DropTable(
                name: "UserGuestEvents");

            migrationBuilder.DropTable(
                name: "UserHostEvents");

            migrationBuilder.DropTable(
                name: "WeekEntity");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "PlaceEntity");

            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
