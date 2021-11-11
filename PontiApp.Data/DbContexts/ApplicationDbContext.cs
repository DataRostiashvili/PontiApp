using Microsoft.EntityFrameworkCore;

using PontiApp.Models.Entities;
using PontiApp.Data.EntityConfiguration;
using PontiApp.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;

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

        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<PlaceCategory> PlaceCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder options)
        {
            options.ApplyConfiguration(new CategoryEntityConfiguration());
            options.ApplyConfiguration(new EventEntityConfiguration());
            options.ApplyConfiguration(new UserEntityConfiguration());
            options.ApplyConfiguration(new PlaceEntityConfiguration());
            options.ApplyConfiguration(new UserGuestEventConfiguration());
            options.ApplyConfiguration(new UserGuestPlaceConfiguration());
            options.ApplyConfiguration(new PlaceCategoryConfiguration());
            options.ApplyConfiguration(new EventCategoryConfiguration());
        }

        public override int SaveChanges()
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }


    }
}
