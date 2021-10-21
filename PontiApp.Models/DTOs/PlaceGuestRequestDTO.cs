using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class PlaceGuestRequestDTO
    {
        public int PlaceId { get; set; }

        public int UserGuestId { get; set; }
    }
}
