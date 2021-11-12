using AutoMapper;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Models.Request;
using PontiApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Mappings
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserEntity, UserCreationDTO>().ReverseMap();
            CreateMap<UserEntity, UserDTO>().ReverseMap();
            CreateMap<UserEntity, UserUpdateDTO>().ReverseMap();
            CreateMap<UserEntity, UserListingDTO>().ReverseMap();

            CreateMap<UserEntity, UserRequest>().ReverseMap();
            CreateMap<UserEntity, UserResponse>().ReverseMap();
        }
    }
}
