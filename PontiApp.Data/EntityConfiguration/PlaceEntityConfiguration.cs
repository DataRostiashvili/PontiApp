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
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(pl => pl.Pictures)
                    .WithOne(pic => pic.PlaceEntity)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(pl => pl.PlaceEvents)
                    .WithOne(ev => ev.PlaceEntity)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(pl => pl.Reviews)
                    .WithOne(r => r.PlaceEntity)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.Navigation(x => x.PlaceCategories).AutoInclude();
            builder.Navigation(x => x.WeekSchedule).AutoInclude();
            builder.Navigation(x => x.Reviews).AutoInclude();

        }
    }
}
