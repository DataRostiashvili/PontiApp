using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public string Category { get; set; }
        public ICollection<EventCategory> EventsCategories { get; set; }

        public ICollection<PlaceCategory> PlaceCategories{ get; set; }

    }
}
