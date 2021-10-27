using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class PlaceCategoryDTO : IdDTO
    {
        public int CategoryEntityId { get; set; }
        public string Category { get; set; }
        public int PlaceEntityId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
