using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class UserUpdateDTO
    {
        public string Name { get; set; }

        public string Surename { get; set; }

        public string Mail { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

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
