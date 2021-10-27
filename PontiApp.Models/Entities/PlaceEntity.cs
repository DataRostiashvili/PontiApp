using System.Collections.Generic;

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
        public int UserEntityId { get; set; }

        public ICollection<EventEntity> PlaceEvents { get; set; }
        public List<WeekEntity> WeekSchedule { get; set; }
        public List<PlacePicEntity> Pictures { get; set; }
        public ICollection<PlaceReviewEntity> Reviews { get; set; }

        public ICollection<UserGuestPlace> UserGuests { get; set; }
        public List<PlaceCategory> PlaceCategories { get; set; }

    }
}
