using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities
{
    public class PlacePicEntity
    {
        public int PlacePicEntityId { get; set; }
        public string Uri { get; set; }

        PlaceEntity PlaceEntity { get; set; }
    }
}
