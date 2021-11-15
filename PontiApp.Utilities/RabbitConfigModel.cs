using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Utilities
{
    [JsonObject("RabbitMQ")]
    public class RabbitMQ
    {
        [JsonProperty("HostName")]
        public string HostName { get; set; }

        [JsonProperty("UserName")]
        public string UserName { get; set; }

        [JsonProperty("PassWord")]
        public string PassWord { get; set; }

        [JsonProperty("VirtualHost")]
        public string VirtualHost { get; set; }

        [JsonProperty("Port")]
        public int Port { get; set; }
    }
}
