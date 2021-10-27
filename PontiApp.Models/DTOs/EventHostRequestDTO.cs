using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class EventHostRequestDTO : PontiBaseDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //From front side if this field is null,it must not be passed to json stirng
        public int? PlaceEntityId { get; set; }
        public List<EventCategoryDTO> EventCategories { get; set; }
    }
}
