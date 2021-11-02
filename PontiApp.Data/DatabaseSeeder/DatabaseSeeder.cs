using PontiApp.Data.DbContexts;
using System.Linq;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace PontiApp.Data.DatabaseSeeder
{
    public class DatabaseSeeder
    {
        private readonly ApplicationDbContext _appDbContext;
        public DatabaseSeeder(ApplicationDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void SeedDatabase()
        {
            FillUsersTable();
            FillPlacesTable();
            FillEventsTable();
        }

        private void FillUsersTable()
        {
            if (!_appDbContext.Users.Any())
            {
                var userSqlData = File.ReadAllText(@"..\PontiApp.Data\DatabaseSeeder\InsertUsers.sql");
                _appDbContext.Database.ExecuteSqlRaw(userSqlData);
            }
        }

        private void FillPlacesTable()
        {
            if (!_appDbContext.Places.Any())
            {
                var placesSqlData = File.ReadAllText(@"..\PontiApp.Data\DatabaseSeeder\InsertPlaces.sql");
                _appDbContext.Database.ExecuteSqlRaw(placesSqlData);
            }
        }

        private void FillEventsTable()
        {
            if (!_appDbContext.Events.Any())
            {
                var eventsSqlData = File.ReadAllText(@"..\PontiApp.Data\DatabaseSeeder\InsertEvents.sql");
                _appDbContext.Database.ExecuteSqlRaw(eventsSqlData);
            }
        }
    }
}