using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class UserCreationDTO
    {
        public long UserID { get; set; }
        public string UserName { get; set; }
        public string UserProfileURL { get; set; }
    }
}
