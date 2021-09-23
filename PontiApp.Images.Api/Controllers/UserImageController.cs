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
    public class UserImageController : ControllerBase
    {
        private readonly IMongoUserService service;
        public UserImageController(IMongoUserService _service)
        {
            service = _service;
        }
        [HttpGet]
        public async Task<List<byte[]>> GetImage(int UserID)
        {
            return await service.GetImage(UserID.ToString());
        }
        [HttpPost]
        public async Task PostImage(int UserID, List<byte[]> imgData)
        {
            await service.PostImage(UserID.ToString(), imgData);
        }
        [HttpPut]
        public async Task UpdateImage(int UserID, int[] indices)
        {
            await service.UpdateImage(UserID.ToString(), indices);
        }
        [HttpDelete]
        public async Task DeleteImages(int UserID)
        {
            await service.DeleteImage(UserID.ToString());
        }
    }
}
