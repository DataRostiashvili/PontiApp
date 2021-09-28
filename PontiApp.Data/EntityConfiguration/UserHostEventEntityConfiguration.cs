using Microsoft.EntityFrameworkCore;
using PontiApp.Models.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PontiApp.Data.EntityConfiguration
{
    public class UserHostEventEntityConfiguration : IEntityTypeConfiguration<UserHostEventEntity>
    {
        public void Configure(EntityTypeBuilder<UserHostEventEntity> builder)
        {
            builder.HasKey(ue => new { ue.EventId, ue.UserId });

            builder.HasOne(ue => ue.User)
                .WithMany(user => user.UserHostEvents)
                .HasForeignKey(ue => ue.UserId);

            builder.HasOne(ue => ue.Event)
                .WithMany(e => e.UserHostEvents)
                .HasForeignKey(ue => ue.EventId);
        }
    }
}
