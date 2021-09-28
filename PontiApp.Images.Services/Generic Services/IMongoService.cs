using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontiApp.Images.Services.Generic_Services
{
    public interface IMongoService
    {
        Task<List<byte[]>> GetImage(string guid);
        Task PostImage(string guid, List<byte[]> imgData);
        Task UpdateImage(string guid, int[] indices);
        Task UpdateImage(string guid, List<byte[]> imgData);
        Task DeleteImage(string guid);
    }
}
