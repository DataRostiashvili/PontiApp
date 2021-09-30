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
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasMany(u => u.UserHostEvents)
                    .WithOne(e => e.HostUser)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.UserHostPlaces)
                    .WithOne(p => p.HostUser)
                    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
