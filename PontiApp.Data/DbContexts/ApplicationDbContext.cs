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



        public DbSet<PictureUriEntity> p { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB");
        }

        protected override void OnModelCreating(ModelBuilder options)
        {
            options.ApplyConfiguration(new UserHostEventEntityConfiguration());
            options.ApplyConfiguration(new UserGuestEventEntityConfiguration());


        }
    }
}
