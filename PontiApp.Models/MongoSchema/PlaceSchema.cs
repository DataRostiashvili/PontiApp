using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.MongoSchema
{
    public class PlaceSchema:BaseSchema
    {
        public ObjectId _id { get; set; }
        public string PlaceID { get; set; }
        public List<byte[]> ByteList { get; set; }
    }
}
