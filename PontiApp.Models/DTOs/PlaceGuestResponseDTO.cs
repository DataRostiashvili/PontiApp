using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class PlaceGuestResponseDTO : PontiBaseDTO
    {
        public List<WeekScheduleDTO> WeekSchedules { get; set; }
        public PlaceReviewDTO PlaceReview { get; set; }
        public List<PlaceCategoryDTO> PlaceCategories { get; set; }
    }
}
