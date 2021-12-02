using Newtonsoft.Json;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities.AuthEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.GraphAPICalls
{
    public class FbClient : IFbClient
    {
        private readonly IHttpClientFactory _clientFactory;
        public FbClient(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        public async Task<UserCreationDTO> GetUser(string accessToken, long userID = 2008810342610546)
        {
            var client = _clientFactory.CreateClient("Facebook");
            var requestUrl = $"https://graph.facebook.com/v12.0/me?fields=id,first_name,last_name,email&access_token={accessToken}";
            var json = await client.GetStringAsync(requestUrl);
            var parsedUser = JsonConvert.DeserializeObject<UserParseModel>(json);
            var pictureUrl = $"https://graph.facebook.com/{userID}/picture?type=large&access_token={accessToken}";
            File.WriteAllText("./PicLog.txt", pictureUrl);
            var user = new UserCreationDTO()
            {
                Name = parsedUser.FirstName,
                Surename = parsedUser.LastName,
                Mail = parsedUser.Email,
                FbKey = userID,
                PictureUrl = pictureUrl
            };
            return user;
        }
    }
}
