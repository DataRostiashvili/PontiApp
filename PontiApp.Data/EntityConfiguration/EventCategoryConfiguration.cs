using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Data.EntityConfiguration
{
    public class EventCategoryConfiguration : IEntityTypeConfiguration<EventCategory>
    {
        public void Configure(EntityTypeBuilder<EventCategory> builder)
        {
            builder.HasKey(o => new { o.EventEntityId, o.CategoryEntityId });

            builder.HasOne(o => o.eventEntity)
                    .WithMany(e => e.EventCategories)
                    .HasForeignKey(o => o.EventEntityId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(o => o.categoryEntity)
                    .WithMany(c => c.EventsCategories)
                    .HasForeignKey(o => o.CategoryEntityId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
