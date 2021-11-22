using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PontiApp.Models;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Models.Response;

namespace PontiApp.Mappings
{
    public class EventMapper : Profile
    {
        public EventMapper()
        {
            CreateMap<EventHostRequestDTO, EventEntity>();
            CreateMap<EventEntity, EventHostResponseDTO>();
            CreateMap<EventEntity, EventGuestResponseDTO>();
            CreateMap<EventEntity, EventListingResponseDTO>();

            //CreateMap<EventEntity, EventHostingResponse>()
            //    .ForMember(response => response.Host, entity => entity
            //                                              .MapFrom(e => new HostResponse
            //                                              {
            //                                                  fbId = e.UserEntity.FbKey,
            //                                                  Name = e.UserEntity.Name,
            //                                                  ProfilePictureUri = Helpers.ConvertToPictureUri(e.UserEntity.MongoKey),
            //                                                  Surename = e.UserEntity.Surename
            //                                              })).ReverseMap();


            CreateMap<EventEntity, EventBriefResponse>()
                 .ForMember(response => response.Host, entity => entity
                                                          .MapFrom(e => new HostResponse
                                                          {
                                                              fbId = e.UserEntity.FbKey,
                                                              Name = e.UserEntity.Name,
                                                              ProfilePictureUri = Helpers.ConvertToPictureUri(e.UserEntity.MongoKey),
                                                              Surename = e.UserEntity.Surename
                                                          })).ReverseMap();



        }
    }
}
