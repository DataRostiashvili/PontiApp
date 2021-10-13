using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontiApp.Models.Entities;

namespace PontiApp.Data.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasMany(u => u.UserHostEvents)
                    .WithOne(e => e.UserEntity)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(u => u.UserHostPlaces)
                    .WithOne(p => p.HostUser)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
