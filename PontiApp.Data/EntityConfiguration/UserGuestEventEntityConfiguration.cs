using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PontiApp.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PontiApp.Data.EntityConfiguration
{
    public class UserGuestEventEntityConfiguration : IEntityTypeConfiguration<UserGuestEventEntity>
    {
        public void Configure(EntityTypeBuilder<UserGuestEventEntity> builder)
        {
            builder.HasKey(ue => new { ue.EventId, ue.UserId });

            builder
                .HasOne(ue => ue.User)
                .WithMany(user => user.UserGuestEvents)
                .HasForeignKey(ue => ue.UserId);

            builder.HasOne(ue => ue.Event)
                .WithMany(e => e.UserGuestEvents)
                .HasForeignKey(ue => ue.EventId);
        }

       
    }
}
