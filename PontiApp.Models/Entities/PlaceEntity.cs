using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities
{
    public class PlaceEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string TicketBuyUrl { get; set; }

        public UserEntity HostUser { get; set; }

        public ICollection<EventEntity> PlaceEvents { get; set; }
        public ICollection<WeekEntity> WeekSchedule { get; set; }
        public ICollection<PlacePicEntity> Pictures { get; set; }
        public ICollection<PlaceReviewEntity> Reviews { get; set; }

        public ICollection<UserEntity> UserGuest { get; set; }

    }
}
