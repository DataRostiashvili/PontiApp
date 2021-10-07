using Microsoft.EntityFrameworkCore;

using PontiApp.Models.Entities;
using PontiApp.Data.EntityConfiguration;

namespace PontiApp.Data.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<EventEntity> Events { get; set; }
        public DbSet<PlaceEntity> Places { get; set; }

        public DbSet<EventReviewEntity> EventReviews { get; set; }
        public DbSet<PlaceReviewEntity> PlaceReviews { get; set; }

        public DbSet<EventPicEntity> EventPics { get; set; }
        public DbSet<PlacePicEntity> PlacePics { get; set; }

        public DbSet<WeekEntity> WeekDays { get; set; }

        public DbSet<CategoryEntity> Categories { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(@"User ID=postgres;Password=mysecretpassword;Host=localhost;Port=5432;Database=myDataBase;");
            //builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB,Database=PontiAppDB");
        }

        protected override void OnModelCreating(ModelBuilder options)
        {
            options.ApplyConfiguration(new EventEntityConfiguration());
            options.ApplyConfiguration(new UserEntityConfiguration());
            options.ApplyConfiguration(new PlaceEntityConfiguration());
        }
    }
}
