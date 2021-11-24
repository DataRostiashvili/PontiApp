using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Response
{
    public class EventDetailedResponse
    {
        public int EventId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public HostResponse Host { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }


        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string TicketBuyUrl { get; set; }


        public int? PlaceId { get; set; }

        public IEnumerable<string> Pictures { get; set; }
        public ReviewResponse Review { get; set; }

        public List<CategoryResponse> Categories { get; set; }
    }
}
