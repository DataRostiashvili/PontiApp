using PontiApp.Images.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Images.Services
{
    class ImageService : IImageService
    {
        public IImageRepository ImgRepo { get; set; }
        public async Task DeleteImage(string FileID) => await ImgRepo.DeleteImage(FileID);

        public async Task<byte[]> GetImage(string FileID) => await ImgRepo.GetImage(FileID);

        public async Task PostImage(string url) => await ImgRepo.PostImage(url);

        public async Task PostImage(byte[] imgData) => await ImgRepo.PostImage(imgData);
    }
}
