using MongoDB.Bson;
using System.Threading.Tasks;

namespace PontiApp.Images.Repository
{
    public interface IMongoRepository
    {
        Task<BsonDocument> GetImage(string guid);
        Task PostImage(BsonDocument doc);
        Task UpdateImage(string guid, BsonDocument doc);
        Task DeleteImage(string guid);
    }
}
