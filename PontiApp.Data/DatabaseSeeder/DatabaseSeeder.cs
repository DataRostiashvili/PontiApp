using System;
using PontiApp.Data.DbContexts;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
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

        public async Task SeedDatabase()
        {

            await _appDbContext.Database.MigrateAsync();

            FillUsersTable();
            FillPlacesTable();
            FillEventsTable();
            FillCategoriesTable();
            FillPlaceCategoriesTable();
            FillEventCategoriesTable();
            FillWeekScheduleTable();
            await FillImages();
        }

        private async Task FillImages()
        {
            var mongoSeeder = new MongoSeeder();
            mongoSeeder.Seed();
            mongoSeeder.SeedEventImages();
            mongoSeeder.SeedPlaceImages();
        }
        public async Task DeleteData()
        {
           await _appDbContext.Database.ExecuteSqlRawAsync("DROP SCHEMA public CASCADE; CREATE SCHEMA public");

        }
        private void FillUsersTable()
        {
            
            if (!_appDbContext.Users.Any())
            {
                var rand = new Random();
                var userSqlData = String.Join("",File.ReadAllText(@"../PontiApp.Data/DatabaseSeeder/InsertUsers.sql")
                    .Split('\n').Select(s => s.Replace("2008810342610546", rand.Next(1, int.MaxValue).ToString())).ToArray());
                    

                _appDbContext.Database.ExecuteSqlRaw(userSqlData);
            }
        }

        private void FillPlacesTable()
        {
            if (!_appDbContext.Places.Any())
            {
                var placesSqlData = File.ReadAllText(@"../PontiApp.Data/DatabaseSeeder/InsertPlaces.sql");
                _appDbContext.Database.ExecuteSqlRaw(placesSqlData);
            }
        }

        private void FillEventsTable()
        {
            if (!_appDbContext.Events.Any())
            {
                var eventsSqlData = File.ReadAllText(@"../PontiApp.Data/DatabaseSeeder/InsertEvents.sql");
                _appDbContext.Database.ExecuteSqlRaw(eventsSqlData);
            }
        }

        private void FillCategoriesTable()
        {
            if (!_appDbContext.Categories.Any())
            {
                var categoriesSqlData = File.ReadAllText(@"../PontiApp.Data/DatabaseSeeder/InsertCategories.sql");
                _appDbContext.Database.ExecuteSqlRaw(categoriesSqlData);
            }
        }

        private void FillPlaceCategoriesTable()
        {
            if (!_appDbContext.PlaceCategories.Any())
            {
                var placeCategoriesSqlData = File.ReadAllText(@"../PontiApp.Data/DatabaseSeeder/InsertPlaceCategories.sql");
                _appDbContext.Database.ExecuteSqlRaw(placeCategoriesSqlData);
            }
        }

        private void FillEventCategoriesTable()
        {
            if (!_appDbContext.EventCategories.Any())
            {
                var eventCategoriesSqlData = File.ReadAllText(@"../PontiApp.Data/DatabaseSeeder/InsertEventCategories.sql");
                _appDbContext.Database.ExecuteSqlRaw(eventCategoriesSqlData);
            }
        }

        private void FillWeekScheduleTable()
        {
            if (!_appDbContext.WeekDays.Any())
            {
                var eventCategoriesSqlData = File.ReadAllText(@"../PontiApp.Data/DatabaseSeeder/InsertWeekSchedules.sql");
                _appDbContext.Database.ExecuteSqlRaw(eventCategoriesSqlData);
            }
        }

    }
}