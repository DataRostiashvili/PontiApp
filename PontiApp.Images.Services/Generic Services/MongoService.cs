using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using PontiApp.Images.Repository;
using PontiApp.Models.MongoSchema;

namespace PontiApp.Images.Services.Generic_Services
{
    public class MongoService:IMongoService 
    {
        private readonly IMongoRepository _repo;
        public MongoService(IMongoRepository repo)
        {
            this._repo = repo;
        }

        public async Task UpdateImage(string guid, List<byte[]> imgData)
        {
            var doc = await _repo.GetImage(guid);
            var schema = BsonSerializer.Deserialize<ImageSchema>(doc);
            var list = schema.BytesList;
            list.AddRange(imgData);
            var dict = new Dictionary<string, object>
            {
                {"Guid", guid},
                {"BytesList", list}
            };
            await _repo.UpdateImage(guid, new BsonDocument(dict));
        }

        public async Task DeleteImage(string guid)
        {
            await _repo.DeleteImage(guid);
        }

        public async Task<List<byte[]>> GetImage(string guid)
        {
            var doc = await _repo.GetImage(guid);
            var bytes = BsonSerializer.Deserialize<ImageSchema>(doc);
            return bytes.BytesList;
        }
        public async Task PostImage(string guid, List<byte[]> list)
        {
            var dict = new Dictionary<string, object>
            {
                {"Guid", guid},
                {"BytesList", list}

            };
            var doc = new BsonDocument(dict);
            await _repo.PostImage(doc);
        }
        public async Task UpdateImage(string guid, int[] indices)
        {
            var doc = await _repo.GetImage(guid);
            var schema = BsonSerializer.Deserialize<ImageSchema>(doc);
            var list = schema.BytesList;
            foreach (var i in indices)
            {
                list.RemoveAt(i);
            }
            var dict = new Dictionary<string, object>
            {
                {"Guid", guid},
                {"BytesList", list}
            };
            await _repo.UpdateImage(guid, new BsonDocument(dict));
        }
    }
}
