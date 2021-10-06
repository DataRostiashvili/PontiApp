namespace PontiApp.Models.Entities
{
    public class PlacePicEntity
    {
        public int PlacePicEntityId { get; set; }
        public string MongoKey { get; set; }

        public int PlaceEntityId { get; set; }
        public PlaceEntity PlaceEntity { get; set; }
    }
}
