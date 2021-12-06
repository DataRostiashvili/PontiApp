using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontiApp.Models.Entities;

namespace PontiApp.Data.EntityConfiguration
{
    public class EventEntityConfiguration : IEntityTypeConfiguration<EventEntity>
    {
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.HasMany(e => e.Reviews)
                    .WithOne(r => r.EventEntity)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.PlaceEntity)
                    .WithMany(p => p.PlaceEvents)
                    .HasForeignKey(e => e.PlaceEntityId)
                    .OnDelete(DeleteBehavior.SetNull);

            builder.Navigation(x => x.EventCategories).AutoInclude();
            builder.Navigation(x => x.Reviews).AutoInclude();

            builder.Property<bool>("IsDeleted");
            builder.HasQueryFilter(m => !m.IsDeleted);
        }
    }
}
