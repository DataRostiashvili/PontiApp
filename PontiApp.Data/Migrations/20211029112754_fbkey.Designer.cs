﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PontiApp.Data.DbContexts;

namespace PontiApp.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211029112754_fbkey")]
    partial class fbkey
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PontiApp.Models.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Cetegory")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.EventEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int?>("PlaceEntityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("TicketBuyUrl")
                        .HasColumnType("text");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlaceEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.EventPicEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("EventEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("EventPicEntityId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("MongoKey")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("EventEntityId");

                    b.ToTable("EventPics");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.EventReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("EventEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("EventReviewEntityId")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<float>("ReviewRanking")
                        .HasColumnType("real");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EventEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("EventReviews");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlaceCategory", b =>
                {
                    b.Property<int>("PlaceEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryEntityId")
                        .HasColumnType("integer");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("PlaceEntityId", "CategoryEntityId");

                    b.HasIndex("CategoryEntityId");

                    b.ToTable("PlaceCategories");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlaceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("TicketBuyUrl")
                        .HasColumnType("text");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserEntityId");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlacePicEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("MongoKey")
                        .HasColumnType("text");

                    b.Property<int>("PlaceEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("PlacePicEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlaceEntityId");

                    b.ToTable("PlacePics");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlaceReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int>("PlaceEntityId")
                        .HasColumnType("integer");

                    b.Property<float>("ReviewRanking")
                        .HasColumnType("real");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PlaceEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("PlaceReviews");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<float>("AverageRanking")
                        .HasColumnType("real");

                    b.Property<long>("FbKey")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsVerifiedUser")
                        .HasColumnType("boolean");

                    b.Property<string>("Mail")
                        .HasColumnType("text");

                    b.Property<string>("MongoKey")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Surename")
                        .HasColumnType("text");

                    b.Property<int>("TotalReviewerCount")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.UserGuestEvent", b =>
                {
                    b.Property<int>("EventEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("EventEntityId", "UserEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("UserGuestEvents");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.UserGuestPlace", b =>
                {
                    b.Property<int>("PlaceEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("UserEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("PlaceEntityId", "UserEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("UserGuestPlaces");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.WeekEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("Day")
                        .HasColumnType("integer");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsWorking")
                        .HasColumnType("boolean");

                    b.Property<int>("PlaceEntityId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PlaceEntityId");

                    b.ToTable("WeekDays");
                });

            modelBuilder.Entity("PontiApp.Models.EventCategory", b =>
                {
                    b.Property<int>("EventEntityId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoryEntityId")
                        .HasColumnType("integer");

                    b.Property<string>("Category")
                        .HasColumnType("text");

                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.HasKey("EventEntityId", "CategoryEntityId");

                    b.HasIndex("CategoryEntityId");

                    b.ToTable("EventCategories");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.EventEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.PlaceEntity", "PlaceEntity")
                        .WithMany("PlaceEvents")
                        .HasForeignKey("PlaceEntityId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("PontiApp.Models.Entities.UserEntity", "UserEntity")
                        .WithMany("UserHostEvents")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlaceEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.EventPicEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.EventEntity", "EventEntity")
                        .WithMany("Pictures")
                        .HasForeignKey("EventEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.EventReviewEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.EventEntity", "EventEntity")
                        .WithMany("Reviews")
                        .HasForeignKey("EventEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PontiApp.Models.Entities.UserEntity", "UserEntity")
                        .WithMany("GuestingEventReviews")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlaceCategory", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.CategoryEntity", "categoryEntity")
                        .WithMany("PlaceCategories")
                        .HasForeignKey("CategoryEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PontiApp.Models.Entities.PlaceEntity", "placeEntity")
                        .WithMany("PlaceCategories")
                        .HasForeignKey("PlaceEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoryEntity");

                    b.Navigation("placeEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlaceEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.UserEntity", "HostUser")
                        .WithMany("UserHostPlaces")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("HostUser");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlacePicEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.PlaceEntity", "PlaceEntity")
                        .WithMany("Pictures")
                        .HasForeignKey("PlaceEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlaceEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlaceReviewEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.PlaceEntity", "PlaceEntity")
                        .WithMany("Reviews")
                        .HasForeignKey("PlaceEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PontiApp.Models.Entities.UserEntity", "UserEntity")
                        .WithMany("GuestingPlaceReviews")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlaceEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.UserGuestEvent", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.EventEntity", "EventEntity")
                        .WithMany("UserGuests")
                        .HasForeignKey("EventEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PontiApp.Models.Entities.UserEntity", "UserEntity")
                        .WithMany("UserGuestEvents")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.UserGuestPlace", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.PlaceEntity", "PlaceEntity")
                        .WithMany("UserGuests")
                        .HasForeignKey("PlaceEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PontiApp.Models.Entities.UserEntity", "UserEntity")
                        .WithMany("UserGuestPlaces")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PlaceEntity");

                    b.Navigation("UserEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.WeekEntity", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.PlaceEntity", "Place")
                        .WithMany("WeekSchedule")
                        .HasForeignKey("PlaceEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Place");
                });

            modelBuilder.Entity("PontiApp.Models.EventCategory", b =>
                {
                    b.HasOne("PontiApp.Models.Entities.CategoryEntity", "categoryEntity")
                        .WithMany("EventsCategories")
                        .HasForeignKey("CategoryEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PontiApp.Models.Entities.EventEntity", "eventEntity")
                        .WithMany("EventCategories")
                        .HasForeignKey("EventEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("categoryEntity");

                    b.Navigation("eventEntity");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.CategoryEntity", b =>
                {
                    b.Navigation("EventsCategories");

                    b.Navigation("PlaceCategories");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.EventEntity", b =>
                {
                    b.Navigation("EventCategories");

                    b.Navigation("Pictures");

                    b.Navigation("Reviews");

                    b.Navigation("UserGuests");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.PlaceEntity", b =>
                {
                    b.Navigation("Pictures");

                    b.Navigation("PlaceCategories");

                    b.Navigation("PlaceEvents");

                    b.Navigation("Reviews");

                    b.Navigation("UserGuests");

                    b.Navigation("WeekSchedule");
                });

            modelBuilder.Entity("PontiApp.Models.Entities.UserEntity", b =>
                {
                    b.Navigation("GuestingEventReviews");

                    b.Navigation("GuestingPlaceReviews");

                    b.Navigation("UserGuestEvents");

                    b.Navigation("UserGuestPlaces");

                    b.Navigation("UserHostEvents");

                    b.Navigation("UserHostPlaces");
                });
#pragma warning restore 612, 618
        }
    }
}
