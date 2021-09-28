namespace PontiApp.Models.Entities
{
    public class PlacePicEntity
    {
        public int PlacePicEntityId { get; set; }
        public string Uri { get; set; }

        public PlaceEntity PlaceEntity { get; set; }
    }
}
