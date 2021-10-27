using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class PlaceListingResponseDTO
    {
        public int Id { get; set; }
        public List<WeekScheduleDTO> WeekSchedules { get; set; }
        public int AverageRanking { get; set; }
    }
}
