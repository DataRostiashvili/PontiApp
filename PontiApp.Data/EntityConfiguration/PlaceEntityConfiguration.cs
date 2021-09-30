using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Data.EntityConfiguration
{
    public class PlaceEntityConfiguration : IEntityTypeConfiguration<PlaceEntity>
    { 

        public void Configure(EntityTypeBuilder<PlaceEntity> builder)
        {
            builder.HasMany(pl => pl.WeekSchedule)
                    .WithOne(w => w.Place)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pl => pl.Pictures)
                    .WithOne(pic => pic.PlaceEntity)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pl => pl.PlaceEvents)
                    .WithOne(ev => ev.PlaceEntity)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(pl => pl.Reviews)
                    .WithOne(r => r.PlaceEntity)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
