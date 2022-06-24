using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PontiApp.Models.Entities;

namespace PontiApp.Data.EntityConfiguration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {


        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder
            .Property(cat => cat.Id)
            .ValueGeneratedOnAdd();

            builder.Property(e => e.Id).
                HasIdentityOptions(startValue: 200);

        }
    }
}
