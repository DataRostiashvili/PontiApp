using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities.AuthEntities
{
    public class JwtConfig
    {
        public string Secret { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
