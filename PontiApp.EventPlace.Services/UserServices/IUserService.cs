using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Models.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.UserServices
{
    public interface IUserService
    {
        Task Add(UserCreationDTO newUserDTO);
        Task Delete(int id);
        void DeleteImage(string guid);
        Task<UserDTO> Get(int id);
        Task<List<UserDTO>> GetAllUser();
        Task<UserEntity> GetUser(int id);
        UserCreationDTO GetUser(long id);
        Task Update(UserRequest currUserDTO);
        Task<bool> UserExists(int id);
        bool UserExists(long FbKey);
    }
}