using PontiApp.Models.Entities.AuthEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.GraphAPICalls
{
    public interface IFbClient
    {
        Task<LoginResponse> GetUser (string userID,string accessToken);
    }
}
