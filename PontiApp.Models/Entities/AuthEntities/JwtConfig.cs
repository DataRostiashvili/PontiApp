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
        public string Secret { get; set; } = "Super secret code";
        public string Issuer { get; set; } = "Issuer";
        public string Audience { get; set; } = "Audience";
    }
}
