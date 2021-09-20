using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PontiApp.Models.Entities.Enums;

namespace PontiApp.Models.Entities
{
    public class WeekEntity
    {

        public int WeekId { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Daytype Day { get; set; }

        public PlaceEntity Place { get; set; }

    }
}
