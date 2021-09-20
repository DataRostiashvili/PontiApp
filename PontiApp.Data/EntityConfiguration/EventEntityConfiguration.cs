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
    public class EventEntityConfiguration : IEntityTypeConfiguration<EventEntity>
    {
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.HasOne(e => e.Place)
                    .WithOne(p => p.EventEntity)
                    .HasForeignKey<PlaceEntity>(p => p.EventRef);

            builder.HasMany(e => e.PictureUries)
                    .WithOne(p => p.EventEntity);

            builder.HasMany(e => e.EventReviews)
                    .WithOne(r => r.EventEntity);
        }
    }
}
