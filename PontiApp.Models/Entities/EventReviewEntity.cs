namespace PontiApp.Models.Entities
{
    public class EventReviewEntity
    {
        public int EventReviewEntityId { get; set; }
        public float ReviewRanking { get; set; }

        public EventEntity EventEntity { get; set; }
    }
}
