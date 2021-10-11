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

        public ICollection<EventEntity> Events { get; set; }

        public ICollection<PlaceEntity> Places { get; set; }

    }
}
