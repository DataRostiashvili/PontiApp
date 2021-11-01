using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PontiApp.Data.DbContexts
{
    public class BloggingContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            
                var defaultConnectionString =  "User ID=postgres;Password=mysecretpassword;Host=localhost;Port=5432;Database=postgres;";
            
            optionsBuilder.UseNpgsql(defaultConnectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}