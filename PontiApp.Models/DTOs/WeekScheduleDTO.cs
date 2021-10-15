using PontiApp.Models.Entities;
using PontiApp.Models.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class WeekScheduleDTO
    {
        public int WeekEntityId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Daytype Day { get; set; }

        public int PlaceEntityId { get; set; }
    }
}
