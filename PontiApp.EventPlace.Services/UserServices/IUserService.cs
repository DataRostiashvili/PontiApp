using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.UserServices
{
    public interface IUserService
    {
        Task Add(UserDTO newUserDTO);
        Task Update(UserDTO currUserDTO);
        Task<UserDTO> Get(int id);
        Task Delete(UserDTO currUserDTO);

    }
}
