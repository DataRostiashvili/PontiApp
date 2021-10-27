using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class PlaceHostRequestDTO : PontiBaseDTO
    {
        public List<WeekScheduleDTO> WeekSchedule { get; set; }

        public List<PlaceCategoryDTO> PlaceCategories { get; set; }
    }
}
