namespace PontiApp.Models.Entities
{
    public class ProfilePicEntity
    {
        public int ProfilePicEntityId { get; set; }
        public string Uri { get; set; }

        public int UserRef { get; set; }
        public UserEntity UserEntity { get; set; }
     }
}
