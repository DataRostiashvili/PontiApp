using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PontiApp.Models.Entities.AuthEntities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.AuthService
{
    public class JwtProcessor : IJwtProcessor
    {
        private readonly IConfiguration _config;
        private readonly JwtConfig _jwtconfig;
        public JwtProcessor (IConfiguration config,JwtConfig jwtConfig)
        {
            _config = config;
            _jwtconfig = jwtConfig;
        }

        public JwtSecurityToken ValidateJwt (string token)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(token,new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = _jwtconfig.Issuer,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtconfig.Secret)),
                ValidAudience = _jwtconfig.Audience,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(1)

            },out SecurityToken validatedToken) ;
            var jwtToken = (JwtSecurityToken) validatedToken;
            var userID = jwtToken.Claims.FirstOrDefault(s => s.Type == "UserID").Value;
            var fullName = jwtToken.Claims.FirstOrDefault(s => s.Type == "UserName").Value;
            var loginResponse = new LoginResponse
            {
                UserID = Convert.ToInt64(userID),
                FullName = fullName
            };
            return (JwtSecurityToken)validatedToken;
            //
        }



        public string GenerateJwt (long userID,string userName)
        {
            var handler = new JwtSecurityTokenHandler();

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtconfig.Secret));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            ClaimsIdentity claims = new ClaimsIdentity(new[]
            {
                new Claim("UserID",userID.ToString()),
                new Claim("UserName",userName),
            });
            var token = handler.CreateJwtSecurityToken(
                _jwtconfig.Issuer,
                _jwtconfig.Audience,
                new ClaimsIdentity(claims),
                DateTime.Now,
                DateTime.Now.AddMinutes(15),
                DateTime.Now,
                credentials);
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
            return tokenString;
        }
    }
}
