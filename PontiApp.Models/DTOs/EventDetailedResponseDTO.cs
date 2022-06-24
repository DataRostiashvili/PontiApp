using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class EventDetailedResponseDTO : PontiBaseDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string PicturesId { get; set; }
        public PlaceEntity PlaceEntity { get; set; }
        public int PlaceEntityIds { get; set; }
        public UserEntity UserEntity { get; set; }
        public List<EventReviewEntity> Reviews { get; set; }
        public List<UserGuestEvent> UserGuests { get; set; }
        public List<EventCategory> EventCategories { get; set; }
    }
}
