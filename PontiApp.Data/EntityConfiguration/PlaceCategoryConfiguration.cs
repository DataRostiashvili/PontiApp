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
    public class PlaceCategoryConfiguration : IEntityTypeConfiguration<PlaceCategory>
    {
        public void Configure(EntityTypeBuilder<PlaceCategory> builder)
        {
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.placeEntity)
                    .WithMany(p => p.PlaceCategories)
                    .HasForeignKey(o => o.PlaceEntityId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.categoryEntity)
                    .WithMany(c => c.PlaceCategories)
                    .HasForeignKey(o => o.CategoryEntityId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
