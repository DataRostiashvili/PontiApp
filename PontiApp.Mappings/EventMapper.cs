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

            CreateMap<EventEntity, EventBriefResponse>()
                 .ForMember(response => response.Host, config => config
                                                          .MapFrom(e => new HostResponse
                                                          {
                                                              fbId = e.UserEntity.FbKey,
                                                              Name = e.UserEntity.Name,
                                                              ProfilePictureUri = Helpers.ConvertToPictureUri(e.UserEntity.MongoKey),
                                                              Surename = e.UserEntity.Surename
                                                          }))
                 .ForMember(response => response.EventId, entity => entity.MapFrom(e => e.Id))
                 .ReverseMap();

            CreateMap<EventEntity, EventDetailedResponse>()
                .ForMember(response => response.Host, config => config
                                                         .MapFrom(e => new HostResponse
                                                         {
                                                             fbId = e.UserEntity.FbKey,
                                                             Name = e.UserEntity.Name,
                                                             ProfilePictureUri = Helpers.ConvertToPictureUri(e.UserEntity.MongoKey),
                                                             Surename = e.UserEntity.Surename
                                                         }))
                .ForMember(response => response.EventId, entity => entity.MapFrom(e => e.Id))
                .ForMember(response => response.Review, config => config
                .MapFrom(e => new ReviewResponse
                {
                    AverageReviewRanking = e.Reviews.Average(review => review.ReviewRanking),
                    TotalReviewCount = e.Reviews.Count
                }))
                .ForMember(response => response.Pictures, config => config.MapFrom(entity => new PictureCollectionResponse
                {
                    Pictures = entity.Pictures.Select(pic => Helpers.ConvertToPictureUri(pic.MongoKey))
                }))
                .ForMember(response => response.PlaceId, config=> config.MapFrom(entity => entity.PlaceEntityId))
                .ReverseMap();

        }
    }
}
