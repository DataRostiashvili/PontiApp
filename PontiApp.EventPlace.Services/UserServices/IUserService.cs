using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Models.Request;
using PontiApp.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.UserServices
{
    public interface IUserService
    {
        Task Add(UserCreationDTO newUserDTO);
        Task Delete(long id);
        void DeleteImage(string guid);
        Task<UserDTO> Get(int id);
        Task<List<UserResponse>> GetAllUser();
        Task<UserEntity> GetUser(int id);
        UserCreationDTO GetUser(long fbId);
        Task Update(UserRequest userRequest);
        Task<bool> UserExists(int id);
        bool UserExists(long FbKey);
    }
}