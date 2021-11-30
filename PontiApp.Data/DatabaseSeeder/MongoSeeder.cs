using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace PontiApp.Data.DatabaseSeeder
{
    public class MongoSeeder
    {
        class MongoDoc
        {
            public ObjectId _id { get; set; }
            public string Guid { get; set; }
            public List<byte[]> BytesList { get; set; }
        }

        public void Seed()
        {
            List<MongoDoc> docs = new List<MongoDoc>();
            var client = new MongoClient("mongodb://localhost:27017");
            var imgData = File.ReadAllBytes(@"C:\Users\USER\source\repos\MongoSeeder\doge.jpg");
            for (int i = 0; i < 100; i++)
            {
                var document = new MongoDoc()
                {
                    _id = ObjectId.GenerateNewId(DateTime.Now),
                    Guid = $"Dog{i}",
                    BytesList = new List<byte[]>(),
                };
                document.BytesList.Add(imgData);
                docs.Add(document);

            }
            var jsonData = JsonSerializer.Serialize(docs);
            var DB = client.GetDatabase("PontiAppDB");
            var Coll = DB.GetCollection<BsonDocument>("PicRepo");
            var docList = BsonSerializer.Deserialize<List<BsonDocument>>(jsonData);
            DB.DropCollection("PicRepo");
            Coll.InsertMany(docList);

        }
    }
}
