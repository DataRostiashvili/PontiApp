﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities
{
    public class PlaceReviewEntity
    {
        public int PlaceReviewEntityId { get; set; }
        public float ReviewRanking { get; set; }

        public PlaceEntity Place { get; set; }
    }
}