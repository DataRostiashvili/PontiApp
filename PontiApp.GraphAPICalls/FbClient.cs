using Newtonsoft.Json;
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
        public async Task<LoginResponse> GetUser (long userID,string accessToken)
        {
            var client = _clientFactory.CreateClient("Facebook");
            var requestUrl = $"https://graph.facebook.com/v12.0/me?fields=id%2Cname&access_token={accessToken}";
            var json = await client.GetStringAsync(requestUrl);
            var data = JsonConvert.DeserializeObject<Dictionary<string,string>>(json);
            var id = data["id"];
            var name = data["name"];
            var pictureUrl = $"https://graph.facebook.com/{id}/picture?width=500&access_token={accessToken}";

            return new LoginResponse
            {
                UserID = Convert.ToInt64(id),
                FullName = name,
            };
        }
    }
}
