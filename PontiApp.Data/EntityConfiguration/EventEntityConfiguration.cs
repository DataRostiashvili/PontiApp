using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontiApp.Models.Entities;

namespace PontiApp.Data.EntityConfiguration
{
    public class EventEntityConfiguration : IEntityTypeConfiguration<EventEntity>
    {
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.HasMany(e => e.Pictures)
                    .WithOne(p => p.EventEntity)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(e => e.Reviews)
                    .WithOne(r => r.EventEntity)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
