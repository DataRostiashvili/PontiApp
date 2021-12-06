using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontiApp.Models.Entities;

namespace PontiApp.Data.EntityConfiguration
{
    public class PlaceEntityConfiguration : IEntityTypeConfiguration<PlaceEntity>
    {

        public void Configure(EntityTypeBuilder<PlaceEntity> builder)
        {
            builder.HasMany(pl => pl.WeekSchedule)
                    .WithOne(w => w.Place)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pl => pl.Reviews)
                    .WithOne(r => r.PlaceEntity)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.PlaceCategories).AutoInclude();
            builder.Navigation(x => x.WeekSchedule).AutoInclude();
            builder.Navigation(x => x.Reviews).AutoInclude();

            builder.Property<bool>("IsDeleted");
            builder.HasQueryFilter(m=>m.IsDeleted);

        }
    }
}
