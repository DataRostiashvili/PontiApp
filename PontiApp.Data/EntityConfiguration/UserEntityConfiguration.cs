using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontiApp.Models.Entities;

namespace PontiApp.Data.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasOne(u => u.PictureUri)
                    .WithOne(p => p.UserEntity)
                    .HasForeignKey<ProfilePicEntity>(p => p.UserRef);
        }
    }
}
