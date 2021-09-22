using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json;
using PontiApp.Images.Repository;
using PontiApp.Models.MongoSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Images.Services.EventService
{
    public class MongoUserService:IMongoUserService
    {
        private readonly IMongoRepository<UserSchema> repo;
        public MongoUserService(IMongoRepository<UserSchema> _repo)
        {
            repo = _repo;
        }

        public async Task DeleteImage(string schemaID)
        {
            await repo.DeleteImage(schemaID);
        }

        public async Task<List<byte[]>> GetImage(string schemaID)
        {
            var doc = await repo.GetImage(schemaID);
            var obj = BsonSerializer.Deserialize<UserSchema>(doc);
            return obj.ByteList;
        }
        
        public async Task PostImage(string schemaID,List<byte[]> list)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("UserSchemaID", schemaID);
            dict.Add("ByteList", list);
            BsonDocument bdoc = new BsonDocument(dict);
            await repo.PostImage(bdoc);
        }
        public async Task UpdateImage(string schemaID, int[] indices)
        {
            var doc = await repo.GetImage(schemaID);
            var obj = BsonSerializer.Deserialize<UserSchema>(doc);
            var list = obj.ByteList;
            foreach (var i in indices)
            {
                list.RemoveAt(i);
            }
            var dict = new Dictionary<string, Object>();
            dict.Add("UserSchemaID", schemaID);
            dict.Add("ByteList", list);
            await repo.UpdateImage(schemaID, new BsonDocument(dict));
        }
    }
}
