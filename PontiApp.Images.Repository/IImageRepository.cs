using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Images.Repository
{
    public interface IImageRepository
    {
        Task<byte[]> GetImage(string ObjID);
        Task PostImage(byte[] imgData);
        Task PostImage(string Uri);
        //Task PostImage(IFormFile file);
        Task DeleteImage(string ObjID);
    }
}
