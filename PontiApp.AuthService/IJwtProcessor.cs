using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.AuthService
{
    public interface IJwtProcessor
    {
        public string GenerateJwt (long userID,string userName);
        
    }
}
