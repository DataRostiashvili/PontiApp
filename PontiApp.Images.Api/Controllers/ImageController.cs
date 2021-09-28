using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using PontiApp.Images.Api.Attributes;
using PontiApp.Images.Api.Utils;
using PontiApp.Images.Services.Generic_Services;
using PontiApp.Models.MongoSchema;

namespace PontiApp.Images.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKeyAuth]
    public class ImageController : ControllerBase
    {
        
        [FromHeader(Name = "ApiKey")] public string ApiKey { get; set; }
        
        private readonly IMongoService _service;
        public ImageController(IMongoService service)
        {
            this._service = service;
        }

        [HttpGet]
        public async Task<List<byte[]>> Get(string guid)
        {
            JsonObj obj = new JsonObj
            {
                ByteList = await _service.GetImage(guid)
            };
            return obj.ByteList;
        }
        
        [HttpPost]
        public async Task Post(string guid,[FromBody]JsonObj lst)
        {
            await _service.PostImage(guid, lst.ByteList);
        }

        [Route("Remove")]
        [HttpPut]
        public async Task Update(string guid, int[] indices) 
        {
            await _service.UpdateImage(guid, indices);
        }

        [Route("Add")]
        [HttpPut]
        public async Task Update(string guid, List<byte[]> imgData)
        {
            await _service.UpdateImage(guid, imgData);
        }
        
        [HttpDelete]
        public async Task Delete(string guid)
        {
            await _service.DeleteImage(guid);
        }
    }
}
