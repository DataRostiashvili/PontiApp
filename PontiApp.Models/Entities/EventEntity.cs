using System;
using System.Collections.Generic;

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

        public bool IsActive { get; set; }

        //One to many references

        public PlaceEntity PlaceEntity { get; set; }
        public int PlaceEntityId { get; set; }

        public UserEntity UserEntity { get; set; }
        public int UserEntityId { get; set; }
        public ICollection<EventPicEntity> Pictures { get; set; }
        public ICollection<EventReviewEntity> Reviews { get; set; }

        //Many to many
        public ICollection<UserGuestEvent> UserGuests { get; set; }
        public ICollection<EventCategory> EventCategories { get; set; }

    }
}
