using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities
{
    public class PlaceEntity
    {
        public int PlaceId { get; set; }


        public string Name { get; set; }
        public string Description { get; set; }



        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }


        public string TicketBuyUrl { get; set; }

        public ICollection<WeekEntity> WeekSchedule { get; set; } // 7 

        public int WeekScheduleId { get; set; }


        public PictureUriEntity PictureUri { get; set; }
        public int PictureUriId { get; set; }


        public ICollection<EventReviewEntity> EventReviews { get; set; }


        public ICollection<UserGuestEventEntity> UserGuestEvents { get; set; }
        public ICollection<UserHostEventEntity> UserHostEvents { get; set; }

    }
}
