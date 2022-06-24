using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PontiApp.Models.DTOs;

namespace PontiApp.Models.Request
{
    public class PlaceRequest
    {
        public long FbId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string TicketBuyUrl { get; set; }



        public List<WeekScheduleRequest> WeekSchedule { get; set; }

        public List<CategoryRequest> PlaceCategories { get; set; }
    }
}
