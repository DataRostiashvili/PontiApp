using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.Images.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PontiApp.Images.Api.Attributes;

namespace PontiApp.Images.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKeyAuth]
    public class EventImageController : ControllerBase
    {
        private readonly IMongoEventService service;
        public EventImageController(IMongoEventService _service)
        {
            service = _service;
        }
        [HttpGet]
        public async Task<List<byte[]>> GetImage(int EventID)
        {
            return await service.GetImage(EventID.ToString());
        }
        [HttpPost]
        public async Task PostImage(int EventID,List<byte[]> imgData)
        {
            await service.PostImage(EventID.ToString(), imgData);
        }
        [HttpPut]
        public async Task UpdateImage(int EventID, int[] indices) 
        {
            await service.UpdateImage(EventID.ToString(), indices);
        }
        [HttpDelete]
        public async Task DeleteImages(int EventID)
        {
            await service.DeleteImage(EventID.ToString());
        }
    }
}
