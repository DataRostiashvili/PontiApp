using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class EventCategoryDTO
    {
        public int CategoryEntityId { get; set; }
        public string Category { get; set; }
        public int EventEntityId { get; set; }
    }
}
