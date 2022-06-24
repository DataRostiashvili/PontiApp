using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Models.Request;
using PontiApp.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontiApp.User.Services
{
    public interface IUserService
    {
        //Task Add(UserCreationDTO newUserDTO);
        Task Delete(long id);
        void DeleteImage(string guid);
        Task<UserResponse> Get(long id);
        Task<List<UserResponse>> GetAllUser();
        Task<UserEntity> GetUser(int id);
        UserCreationDTO GetUser(long fbId);
        Task Update(UserRequest userRequest);
        Task<bool> UserExists(int id);
        bool UserExists(long FbKey);
        Task<(string, UserCreationDTO)> AddUser(long fbkey, string accessToken);
        Task<bool> IsUserHosting(int id);
    }
}