using Microsoft.AspNetCore.Mvc;
using PontiApp.Data.DatabaseSeeder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseSeederController :ControllerBase
    {
        private readonly DatabaseSeeder _seeder;
        public DatabaseSeederController(DatabaseSeeder seeder)
        {
            _seeder = seeder;
        }

        [HttpGet]
        public IActionResult SeedDatabase()
        {
            _seeder.SeedDatabase();
            return Ok();
        } 

    }
}
