using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int QueueId { get; set; }
    }
}
