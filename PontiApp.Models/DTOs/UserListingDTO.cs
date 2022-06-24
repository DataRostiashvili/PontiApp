using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class UserListingDTO : IdDTO
    {
        public string Name { get; set; }
        public string Surename { get; set; }
    }
}
