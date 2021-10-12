using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities
{
    public class UserGuestPlace
    {
        public int PlaceEntityId { get; set; }
        public PlaceEntity PlaceEntity { get; set; }
        public int UserEntityId { get; set; }
        public UserEntity UserEntity { get; set; }

        public bool IsActive { get; set; }
    }
}
