using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities
{
    public class UserGuestEvent
    {
        public int EventEntityId { get; set; }
        public EventEntity EventEntity { get; set; }
        public int UserEntityId { get; set; }
        public UserEntity UserEntity { get; set; }
    }
}
