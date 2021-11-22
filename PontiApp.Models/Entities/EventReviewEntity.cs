using PontiApp.Models.Entities.Interfaces;

namespace PontiApp.Models.Entities
{
    public class EventReviewEntity : BaseEntity , IReviewEntity
    {
        public float ReviewRanking { get; set; }
        public int ReviewCount { get; set; }


        public int EventEntityId { get; set; }
        public EventEntity EventEntity { get; set; }
    }
}
