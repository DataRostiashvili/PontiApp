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
    public class UserGuestPlaceConfiguration : IEntityTypeConfiguration<UserGuestPlace>
    {
        

        public void Configure(EntityTypeBuilder<UserGuestPlace> builder)
        {
            builder.HasKey(o => new { o.PlaceEntityId, o.UserEntityId });

            builder.HasOne(o => o.UserEntity)
                    .WithMany(u => u.UserGuestPlaces)
                    .HasForeignKey(o => o.UserEntityId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(o => o.PlaceEntity)
                    .WithMany(e => e.UserGuests)
                    .HasForeignKey(o => o.PlaceEntityId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Property<bool>("IsDeleted");
            builder.HasQueryFilter(m => EF.Property<bool>(m, "IsDeleted") == false);
        }
    }
}
