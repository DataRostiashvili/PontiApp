using MongoDB.Bson;
using MongoDB.Driver;
using PontiApp.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Images.Repository
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        private readonly IMongoDatabase DB;
        private readonly IMongoCollection<BsonDocument> Coll;
        private readonly MongoClient client;
        public MongoRepository(MongoClient _client)
        {
            client = _client;
            DB = client.GetDatabase("asda");
            Coll = DB.GetCollection<BsonDocument>("");
        }
        public async Task<BsonDocument> GetImage(string schemaID)
        {
            var filter = Builders<BsonDocument>.Filter.Eq($"{typeof(T)}ID", schemaID);
            var file = await Coll.FindAsync(filter);
            return file.ToBsonDocument();
        }
        public async Task PostImage(BsonDocument doc)
        {
            await Coll.InsertOneAsync(doc);
        }
        public async Task UpdateImage(string schemaID,BsonDocument doc)
        {
            var builder = Builders<BsonDocument>.Filter.Eq($"{typeof(T)}ID", schemaID);
            var res = await Coll.ReplaceOneAsync(builder, doc);
        }
        public async Task DeleteImage(string schemaID)
        {
            var builder = Builders<BsonDocument>.Filter.Eq($"{typeof(T)}ID", schemaID);
            await Coll.DeleteOneAsync(builder);
        }

    }
}
