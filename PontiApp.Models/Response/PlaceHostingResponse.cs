using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Response
{
   
        public class PlaceHostingResponse
        {
            public string Name { get; set; }

            public string Address { get; set; }
            public HostResponse Host { get; set; }

            public WeekScheduleResponse TodayWeekSchedule { get; set; }
        }
    
}
