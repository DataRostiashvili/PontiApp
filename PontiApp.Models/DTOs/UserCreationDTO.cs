using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class UserCreationDTO
    {
        public string Name{ get; set; }
        public string Surename { get; set; }
        public string Mail { get; set; }
        public string MongoKey { get; set; }
        public string PictureUrl { get; set; }
        public long FbKey { get; set; }
    }
}
