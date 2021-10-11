using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities.AuthEntities
{
    public class LoginResponse
    {
        public long UserID { get; set; }
        public string FullName { get; set; }
    }
}
