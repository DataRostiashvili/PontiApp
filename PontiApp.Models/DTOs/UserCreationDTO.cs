using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class UserCreationDTO
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string HomeTown { get; set; }
        public string PictureUrl { get; set; }
        public long FbKey { get; set; }
    }
}
