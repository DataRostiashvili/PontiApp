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
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Distributed;
using PontiApp.Images.Cache;
using System;
using PontiApp.Images.Cache.Caching_service;

namespace PontiApp.Images.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[ApiKeyAuth]
    public class ImageController : ControllerBase
    {

        //[FromHeader(Name = "ApiKey")] public string ApiKey { get; set; }
        
        //private readonly ICachingService _cachingService;
        private readonly IMongoService _service;

        public ImageController(IMongoService service,ICachingService cachingService)
        {
            _service = service;
            //_cachingService = cachingService;
        }

        [HttpGet]
        [Route("[action]")]
        [Route("get-profile-picture")]

        public async Task<ActionResult> Get(string guid)
        {
            var cacheKey = "Get_Profile_Pic";
            var image = await _service.GetImage(guid);
            return File(image[0], "image/jpeg");
        }

        [HttpGet]
        [Route("{guid}/{id}")]
        public async Task<IActionResult> Get(string guid, int id)
        {
            var cacheKey = "GET_IMAGE_BY_INDEX";
            var image = await _service.GetImage(guid);
            return File(image[id], "image/jpeg");
        }

    }
}
