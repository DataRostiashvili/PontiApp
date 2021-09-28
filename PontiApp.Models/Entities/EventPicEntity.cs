namespace PontiApp.Models.Entities
{
    public class EventPicEntity
    {
        public int EventPicEntityId { get; set; }
        public string Uri { get; set; }

        public EventEntity EventEntity { get; set; }   
    }
}
