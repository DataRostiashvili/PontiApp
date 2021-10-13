using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class GuestDTO
    {
        public int EventId { get; set; }

        public int PlaceId { get; set; }

        public int UserHostId { get; set; }

        public int UserGuestId { get; set; }

        public float ReviewRanking { get; set; }

    }
}
