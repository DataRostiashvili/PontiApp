using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class PlaceHostResponseDTO : PontiBaseDTO
    {
        public List<WeekScheduleDTO> WeekSchedule { get; set; }

        public List<PlaceCategoryDTO> PlaceCategories { get; set; }

        public int GuestCount { get; set; }

        public int ReviewCount { get; set; }

        public int AverageRanking { get; set; }
    }
}
