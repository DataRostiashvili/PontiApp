using Microsoft.EntityFrameworkCore;

using PontiApp.Models.Entities;
using PontiApp.Data.EntityConfiguration;
using PontiApp.Models;

namespace PontiApp.Data.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<PlaceEntity> Places { get; set; }

        public DbSet<EventReviewEntity> EventReviews { get; set; }
        public DbSet<PlaceReviewEntity> PlaceReviews { get; set; }

        public DbSet<EventPicEntity> EventPics { get; set; }
        public DbSet<PlacePicEntity> PlacePics { get; set; }

        public DbSet<WeekEntity> WeekDays { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }

        public DbSet<UserGuestEvent> UserGuestEvents { get; set; }
        public DbSet<UserGuestPlace> UserGuestPlaces { get; set; }

        public DbSet<EventCategory> EveventCategories { get; set; }
        public DbSet<PlaceCategory> PlaceCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder options)
        {
            options.ApplyConfiguration(new EventEntityConfiguration());
            options.ApplyConfiguration(new UserEntityConfiguration());
            options.ApplyConfiguration(new PlaceEntityConfiguration());
            options.ApplyConfiguration(new UserGuestEventConfiguration());
            options.ApplyConfiguration(new UserGuestPlaceConfiguration());
            options.ApplyConfiguration(new PlaceCategoryConfiguration());
            options.ApplyConfiguration(new EventCategoryConfiguration());
        }

    }
}
