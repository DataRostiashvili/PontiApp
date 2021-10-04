using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities
{
    public class EventPicEntity
    {
        public int EventPicEntityId { get; set; }
        public string MongoKey { get; set; }

        public int EventEntityId { get; set; }
        public EventEntity EventEntity { get; set; }   
    }
}
