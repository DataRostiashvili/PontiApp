using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PontiApp.Models.Entities.Interfaces;

namespace PontiApp.Models.Entities
{
    public class UserReviewEntity : BaseEntity, IReviewEntity
    {
        public float ReviewRanking { get; set; }
        public int ReviewCount { get; set; }


        public int UserEntityId { get; set; }
        public UserEntity UserEntity { get; set; }
    }
}
