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
        public void Configure(EntityTypeBuilder<UserGuestEvent> builder)
        {
            
        }

        public void Configure(EntityTypeBuilder<UserGuestPlace> builder)
        {
            throw new NotImplementedException();
        }
    }
}
