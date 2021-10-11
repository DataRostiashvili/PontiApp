namespace PontiApp.Models.Entities
{
    public class UserGuestEventEntity
    {
        public int EventId { get; set; }

        public EventEntity Event { get; set; }

        public int UserId { get; set; }

        public UserEntity User { get; set; }

    }
}
