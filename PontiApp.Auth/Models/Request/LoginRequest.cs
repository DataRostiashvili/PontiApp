using System.Security.Principal;

namespace PontiApp.Auth.Models.Request
{
    public class LoginRequest
    {
        public string UserId { get; set; }
        public string FacebookAccessToken { get; set; }
    }
}