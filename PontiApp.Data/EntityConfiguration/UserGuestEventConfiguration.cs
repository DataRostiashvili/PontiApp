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
    public class UserGuestEventConfiguration : IEntityTypeConfiguration<UserGuestEvent>
    {
        public void Configure(EntityTypeBuilder<UserGuestEvent> builder)
        {
            builder.HasKey(o => new { o.EventEntityId, o.UserEntityId });

            builder.HasOne(o => o.UserEntity)
                    .WithMany(u => u.UserGuestEvents)
                    .HasForeignKey(o => o.UserEntityId);

            builder.HasOne(o => o.EventEntity)
                    .WithMany(e => e.UserGuest)
                    .HasForeignKey(o => o.EventEntityId);
        }
    }
}
