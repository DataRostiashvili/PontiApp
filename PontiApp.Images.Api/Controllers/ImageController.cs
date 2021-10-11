using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PontiApp.Images.Api.Attributes;
using PontiApp.Images.Api.Utils;
using PontiApp.Images.Services.Generic_Services;
using PontiApp.Models.MongoSchema;
using Microsoft.AspNetCore.Http;
using System.IO;
using PontiApp.MessageSender;
using PontiApp.Images.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;

namespace PontiApp.Images.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKeyAuth]
    public class ImageController : ControllerBase
    {

        [FromHeader(Name = "ApiKey")] public string ApiKey { get; set; }

        private readonly IMongoService _service;

        public ImageController (IMongoService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<byte[]> Get (string guid)
        {
            var images = await _service.GetImage(guid);
            return images[0];
        }

        [HttpGet]
        [Route("{guid}/{id}")]
        public async Task<IActionResult> Get (string guid,int id)
        {
            var images = await _service.GetImage(guid);
            var img = images[id];
            var mStream = new MemoryStream(img);
            return File(img,"image/jpg");
        }
    }
}
