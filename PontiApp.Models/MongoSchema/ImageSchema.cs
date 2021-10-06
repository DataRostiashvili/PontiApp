using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace PontiApp.Models.MongoSchema
{
    public class ImageSchema
    {
        //Mongodb automatically creates this property,using the same name for mapping
        public ObjectId _id { get; set; }
        public string Guid { get; set; }
        public List<byte[]> BytesList { get; set; }
    }
}
