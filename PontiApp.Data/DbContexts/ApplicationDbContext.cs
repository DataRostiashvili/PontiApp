using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using PontiApp.Models.Entities;
using PontiApp.Data.EntityConfiguration;

namespace PontiApp.Data.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<EventEntity> Events { get; set; }

        public DbSet<UserGuestEventEntity> UserGuestEvents { get; set; }

        public DbSet<UserHostEventEntity> UserHostEvents { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseNpgsql(@"User ID=postgres;Password=mysecretpassword;Host=localhost;Port=5432;Database=myDataBase;");
            //builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB,Database=PontiAppDB");
        }

        protected override void OnModelCreating(ModelBuilder options)
        {
            options.ApplyConfiguration(new UserHostEventEntityConfiguration());
            options.ApplyConfiguration(new UserGuestEventEntityConfiguration());
            options.ApplyConfiguration(new EventEntityConfiguration());
            options.ApplyConfiguration(new UserEntityConfiguration());
            options.ApplyConfiguration(new PlaceEntityConfiguration());
        }
    }
}
