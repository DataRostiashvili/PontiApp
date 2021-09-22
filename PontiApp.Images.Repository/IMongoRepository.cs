using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Images.Repository
{
    public interface IMongoRepository<T>
    {
        Task<BsonDocument> GetImage(string schemaID);
        Task PostImage(BsonDocument doc);
        Task UpdateImage(string schemaID, BsonDocument doc);
        Task DeleteImage(string schemaID);
    }
}
