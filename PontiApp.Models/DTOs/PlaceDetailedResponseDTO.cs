using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class PlaceDetailedResponseDTO:PontiBaseDTO
    {
        public string PicturesId { get; set; }
        public UserDTO HostUser { get; set; }
        public ICollection<EventEntity> PlaceEvents { get; set; }
        public List<WeekEntity> WeekSchedule { get; set; }
        public ICollection<PlaceReviewEntity> Reviews { get; set; }
        public ICollection<UserGuestPlace> UserGuests { get; set; }
        public List<PlaceCategory> PlaceCategories { get; set; }


    }
}
