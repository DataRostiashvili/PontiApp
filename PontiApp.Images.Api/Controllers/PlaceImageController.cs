using Microsoft.AspNetCore.Mvc;
using PontiApp.Images.Api.Attributes;
using PontiApp.Images.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontiApp.Images.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ApiKeyAuth]
    public class PlaceImageController : ControllerBase
    {
        private readonly IMongoPlaceService service;
        public PlaceImageController(IMongoPlaceService _service)
        {
            service = _service;
        }
        [HttpGet]
        public async Task<List<byte[]>> GetImage(int PlaceID)
        {
            return await service.GetImage(PlaceID.ToString());
        }
        [HttpPost]
        public async Task PostImage(int PlaceID, List<byte[]> imgData)
        {
            await service.PostImage(PlaceID.ToString(), imgData);
        }
        [HttpPut]
        public async Task UpdateImage(int PlaceID, int[] indices)
        {
            await service.UpdateImage(PlaceID.ToString(), indices);
        }
        [HttpDelete]
        public async Task DeleteImages(int PlaceID)
        {
            await service.DeleteImage(PlaceID.ToString());
        }
    }
}
