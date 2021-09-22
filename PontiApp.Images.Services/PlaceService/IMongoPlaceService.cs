using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Images.Services
{
    public interface IMongoPlaceService
    {
        Task<List<byte[]>> GetImage(string schemaID);
        Task PostImage(string schemaID, List<byte[]> imgData);
        Task UpdateImage(string schemaID, int[] indices);
        Task DeleteImage(string schemaID);
    }
}
