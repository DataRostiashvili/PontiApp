using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Response
{
    public  class PlaceListingResponse
    {

        public string Name { get; set; }

        public string Address { get; set; }

        public UserListingResponse UserEntity { get; set; }
        public List<WeekScheduleResponse> WeekSchedules { get; set; }
        public int AverageRanking { get; set; }

    }
}
