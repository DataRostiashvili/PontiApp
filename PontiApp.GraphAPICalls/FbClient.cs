using Newtonsoft.Json;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities.AuthEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.GraphAPICalls
{
    public class FbClient : IFbClient
    {
        private readonly IHttpClientFactory _clientFactory;
        public FbClient (IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<UserCreationDTO> GetUser (long userID,string accessToken)
        {
            var client = _clientFactory.CreateClient("Facebook");
            var requestUrl = @$"https://graph.facebook.com/v12.0/me?fields=id,first_name,last_name,email,hometown&access_token={accessToken}";
            var json = await client.GetStringAsync(requestUrl);
            var data = JsonConvert.DeserializeObject<User>(json);
            var pictureUrl = @$"https://graph.facebook.com/{userID}/picture?type=large&access_token={accessToken}";
            var user = new UserCreationDTO
            {
                First_Name = data.first_name,
                Last_Name = data.last_name,
                Email = data.email,
                HomeTown = data.hometown.name,
                PictureUrl=pictureUrl
            };
            return user;
        }
    }
}
