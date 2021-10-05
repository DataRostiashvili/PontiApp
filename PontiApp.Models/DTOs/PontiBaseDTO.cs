using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Models.DTOs
{
    public class PontiBaseDTO
    {
        public int QueueId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Mail { get; set; }
        public string TicketBuyUrl { get; set; }

        public float ReviewRanking { get; set; }

        public float CurrentRanking { get; set; }


        public ICollection<byte[]> Pictures { get; set; }

    }
}
