using System.Collections.Generic;

namespace PontiApp.Models.Entities
{
    public class UserEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Surename { get; set; }

        public string Mail { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public float AverageRanking { get; set; }

        public int TotalReviewerCount { get; set; }

        public bool IsVerifiedUser { get; set; }
        public string MongoKey { get; set; }

        public bool IsActive { get; set; }

        //One to Many
        public List<EventEntity> UserHostEvents { get; set; }
        public List<PlaceEntity> UserHostPlaces { get; set; }
        public List<PlaceReviewEntity> GuestingPlaceReviews { get; set; }
        public List<EventReviewEntity> GuestingEventReviews { get; set; }

        //Many to many
        public List<UserGuestEvent> UserGuestEvents { get; set; }
        public List<UserGuestPlace> UserGuestPlaces { get; set; }
        


    }
}
