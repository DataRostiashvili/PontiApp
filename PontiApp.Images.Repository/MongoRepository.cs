using MongoDB.Bson;
using MongoDB.Driver;
using PontiApp.Models.MongoSchema;
using System.Threading.Tasks;

namespace PontiApp.Images.Repository
{
    public class MongoRepository : IMongoRepository
    {
        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<BsonDocument> _coll;
        private readonly MongoClient _client;

        public MongoRepository(MongoClient client)
        {
            this._client = client;
            _db = this._client.GetDatabase("PontiAppDB");
            _coll = _db.GetCollection<BsonDocument>("PicRepo");
        }
        public async Task<BsonDocument> GetImage(string guid)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("Guid", guid);
            var file = await _coll.FindAsync(filter).Result.FirstAsync();
            return file.ToBsonDocument();
        }
        public async Task PostImage(BsonDocument doc)
        {
            await _coll.InsertOneAsync(doc);
        }
        public async Task UpdateImage(string guid, BsonDocument doc)
        {
            var builder = Builders<BsonDocument>.Filter.Eq("Guid", guid);
            var res = await _coll.ReplaceOneAsync(builder, doc);
        }
        public async Task DeleteImage(string guid)
        {
            var builder = Builders<BsonDocument>.Filter.Eq("Guid", guid);
            await _coll.DeleteOneAsync(builder);
        }
    }
}
