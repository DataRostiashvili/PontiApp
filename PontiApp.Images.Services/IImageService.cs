using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Images.Services
{
    public interface IImageService
    {
        Task<byte[]> GetImage(string FileID);
        Task DeleteImage(string FileID);
        Task PostImage(string url);
        Task PostImage(byte[] imgData);
    }
}
