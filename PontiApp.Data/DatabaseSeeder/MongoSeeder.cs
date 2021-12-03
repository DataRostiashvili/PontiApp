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
            var strList = GetMongoKeys("./users.json", "MongoKey");
            List<MongoDoc> docs = new List<MongoDoc>();
            var client = new MongoClient("mongodb://localhost:27017");
            var dir = Directory.GetFiles("./Images");
            var DB = client.GetDatabase("PontiAppDB");
            var Coll = DB.GetCollection<BsonDocument>("PicRepo");
            DB.DropCollection("PicRepo");
            for (int i = 1; i <= 100; i++)
            {
                var list = new List<byte[]>();
                dir = dir.Where(x => x.Contains(".jpg") || x.Contains(".jfif") || x.Contains(".png")).ToArray();
                var imgData = File.ReadAllBytes(dir[i % 24]);
                var dict = new Dictionary<string, object>();
                list.Add(imgData);
                dict.Add("Guid", strList[i]);
                dict.Add("BytesList", list);
                var bdoc = new BsonDocument(dict);
                Coll.InsertOne(bdoc);
            }
        }


        public static List<string> GetMongoKeys(string Path, string Key)
        {
            var fileText = File.ReadAllText(Path);
            var dict = JsonSerializer.Deserialize<List<Dictionary<string, object>>>(fileText);
            var keys = dict.Select(x => x[Key]).Select(x => x.ToString()).ToList();
            return keys;
        }


        public void SeedEventImages()
        {
            var strList = GetMongoKeys("./events.json", "PicturesId");
            var rand = new Random();
            List<MongoDoc> docs = new List<MongoDoc>();
            var client = new MongoClient("mongodb://localhost:27017");
            var dir = Directory.GetFiles("./Images");
            var DB = client.GetDatabase("PontiAppDB");
            var Coll = DB.GetCollection<BsonDocument>("PicRepo");
            
            for (int i = 1; i <= 100; i++)
            {
                var list = new List<byte[]>();
                dir = dir.Where(x => x.Contains(".jpg") || x.Contains(".jfif") || x.Contains(".png")).ToArray();
                var imgData = File.ReadAllBytes(dir[i % 24]);
                var dict = new Dictionary<string, object>();
                for (int j = 0; j < rand.Next(1, 10); j++)
                {
                    list.Add(imgData);
                }
                dict.Add("Guid", strList[i]);
                dict.Add("BytesList", list);
                var bdoc = new BsonDocument(dict);
                Coll.InsertOne(bdoc);
            }
        }

        public void SeedPlaceImages()
        {
            var strList = GetMongoKeys("./places.json", "PicturesId");
            var rand = new Random();
            List<MongoDoc> docs = new List<MongoDoc>();
            var client = new MongoClient("mongodb://localhost:27017");
            var dir = Directory.GetFiles("./Images");
            var DB = client.GetDatabase("PontiAppDB");
            var Coll = DB.GetCollection<BsonDocument>("PicRepo");
            DB.DropCollection("PicRepo");
            for (int i = 1; i < 100; i++)
            {
                var list = new List<byte[]>();
                dir = dir.Where(x => x.Contains(".jpg") || x.Contains(".jfif") || x.Contains(".png")).ToArray();
                var imgData = File.ReadAllBytes(dir[i % 24]);
                var dict = new Dictionary<string, object>();
                for (int j = 0; j < rand.Next(1, 10); j++)
                {
                    list.Add(imgData);
                }
                dict.Add("Guid", strList[i]);
                dict.Add("BytesList", list);
                var bdoc = new BsonDocument(dict);
                Coll.InsertOne(bdoc);
            }
        }
    }

}
