using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PontiApp.Data.DbContexts
{


    public class AplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql("User ID=postgres;Password=mysecretpassword;Host=localhost;Port=5432;Database=postgres;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
