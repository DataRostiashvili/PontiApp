namespace PontiApp.Models.Entities
{
    public class PlaceReviewEntity
    {
        public int PlaceReviewEntityId { get; set; }
        public float ReviewRanking { get; set; }

        public PlaceEntity PlaceEntity { get; set; }
    }
}
