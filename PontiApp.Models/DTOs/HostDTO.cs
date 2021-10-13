using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class HostDTO
    {
        public int EventId { get; set; }

        public int PlaceId { get; set; }

        public int UserHostId { get; set; }

        public int AverageRanking { get; set; }
    }
}
