namespace PontiApp.Models.Entities
{
    public class PlaceReviewEntity : BaseEntity
    {
        public float ReviewRanking { get; set; }

        public int UserEntityId { get; set; }
        public int PlaceEntityId { get; set; }
        public UserEntity UserEntity { get; set; }
        public PlaceEntity PlaceEntity { get; set; }
    }
}
