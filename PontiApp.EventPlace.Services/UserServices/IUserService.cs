using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.UserServices
{
    public interface IUserService
    {
        Task Add(UserCreationDTO newUserDTO,string url);
        Task Update(UserDTO currUserDTO);
        Task<UserDTO> Get(int id);
        Task Delete(UserDTO currUserDTO);
        Task<List<UserDTO>> GetAllUser();
        Task<bool> UserExists(int id);
        bool UserExists(long FbKey);
        Task<UserEntity> GetUser(long id);
        void DeleteImage(string guid);
    }
}
