using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PontiApp.EventPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventPlaceTestController : ControllerBase
    {
        // GET: api/<EventPlaceTestController>
        [HttpGet]
        public String Get()
        {
            String success = "Successfully reached EventPlaceTestController";
            return success;
        }

        // GET api/<EventPlaceTestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EventPlaceTestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EventPlaceTestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EventPlaceTestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
