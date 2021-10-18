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

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtconfig.Secret)),

                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromMinutes(1)

            },out SecurityToken validatedToken);
            var jwtToken = (JwtSecurityToken) validatedToken;
            var userID = jwtToken.Claims.FirstOrDefault(s => s.Type == "UserID").Value;
            var fullName = jwtToken.Claims.FirstOrDefault(s => s.Type == "UserName").Value;
            var loginResponse = new LoginResponse
            {
                UserID = Convert.ToInt64(userID),
                FullName = fullName
            };
            return (JwtSecurityToken) validatedToken;
            //
        }



        public string GenerateJwt (long userID,string userName)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Role,"Admin"),
                new Claim("UserName",userName),
                new Claim("UserID",userID.ToString())
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtconfig.Secret));
            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _jwtconfig.Issuer,
                _jwtconfig.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);
            var data = new JwtSecurityTokenHandler().WriteToken(token);
            return data;
        }
    }
}
