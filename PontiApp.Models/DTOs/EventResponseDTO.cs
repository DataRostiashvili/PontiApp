using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class EventResponseDTO : PontiBaseDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public List<EventCategoryDTO> EventCategories { get; set; }

        public int PlaceEntityId { get; set; }

        public int GuestCount { get; set; }

        public int ReviewCount { get; set; }
    }
}
