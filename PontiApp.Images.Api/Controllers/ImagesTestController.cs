using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PontiApp.Images.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesTestController : ControllerBase
    {
        // GET: api/<ImagesTestController>
        [HttpGet]
        public String Get()
        {
            String success = "Successfully reached ImageTestController";
            return success;
        }

        // GET api/<ImagesTestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ImagesTestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ImagesTestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ImagesTestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
