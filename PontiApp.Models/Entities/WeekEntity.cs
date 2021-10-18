using System;
using PontiApp.Models.Entities.Enums;

namespace PontiApp.Models.Entities
{
    public class WeekEntity : BaseEntity
    {
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Daytype Day { get; set; }

        public bool IsWorking { get; set; }

        public int PlaceEntityId { get; set; }
        public PlaceEntity Place { get; set; }

    }
}
