using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities
{
    public class PlaceCategory : BaseEntity
    {
        public int PlaceEntityId { get; set; }

        public PlaceEntity placeEntity { get; set; }

        public int CategoryEntityId { get; set; }

        public CategoryEntity categoryEntity { get; set; }

        public string Category { get; set; }

        public bool IsActive { get; set; }
    }
}
