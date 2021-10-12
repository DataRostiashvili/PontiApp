using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities
{
    public class CategoryEntity
    {
        public int CategoryEntityId { get; set; }

        public string Cetegory { get; set; }

        public bool IsActive { get; set; }

        public ICollection<EventCategory> EventsCategories { get; set; }

        public ICollection<PlaceCategory> PlaceCategories{ get; set; }

    }
}
