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


            builder.HasMany(e => e.Pictures)
                    .WithOne(p => p.EventEntity)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Reviews)
                    .WithOne(r => r.EventEntity)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
