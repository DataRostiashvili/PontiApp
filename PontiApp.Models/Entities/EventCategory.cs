using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models
{
    public class EventCategory
    {
        public int EventEntityId { get; set; }
        
        public EventEntity eventEntity { get; set; }

        public int CategoryEntityId { get; set; }

        public CategoryEntity categoryEntity { get; set; }

        public bool IsActive { get; set; }
    }
}
