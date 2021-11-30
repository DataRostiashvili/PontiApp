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
#if  DOCKER_COMPOSE
             var imagesApiUrl = "https://localhost:5030/api/Image/get-profile-picture?guid={0}";
#elif DOCKER_COMPOSE_MINIMAL
          var imagesApiUrl = "https://localhost:44389/api/Image/get-profile-picture?guid={0}";
#endif


            CreateMap<UserEntity, UserResponse>()
                .ForMember(response => response.fbId, entity => entity
                .MapFrom(u => u.FbKey))
                .ForMember(response => response.ProfilePictureUri, entity=> entity.MapFrom(ent => string.Format(imagesApiUrl, ent.MongoKey)))
                .ReverseMap();
        }
    }
}
