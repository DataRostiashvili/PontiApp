using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.MongoSchema
{
    public class EventSchema:BaseSchema
    {
        public ObjectId _id { get; set; }
        public string EventID { get; set; }
        public List<byte[]> ByteList { get; set; }
    }
}
