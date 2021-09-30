using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities
{

    public class EventEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string TicketBuyUrl { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        //One to many references

        public PlaceEntity PlaceEntity { get; set; }
        public UserEntity HostUser { get; set; }

        public ICollection<EventPicEntity> Pictures { get; set; }
        public ICollection<EventReviewEntity> Reviews { get; set; }

        //Many to many
        public ICollection<UserEntity> UserGuest { get; set; }

    }
}
