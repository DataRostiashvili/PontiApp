﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class PlaceGuestDTO
    {
        public int PlaceQueueId { get; set; }

        public int UserHostQueueId { get; set; }

        public int UserGuestQueueId { get; set; }

        public float ReviewRanking { get; set; }
    }
}
