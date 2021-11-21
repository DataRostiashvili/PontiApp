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
    public class PlaceMapper : Profile
    {
        public PlaceMapper()
        {
            CreateMap<PlaceHostRequestDTO, PlaceEntity>();
            CreateMap<PlaceEntity, PlaceHostResponseDTO>();
            CreateMap<PlaceEntity, PlaceGuestResponseDTO>();
            CreateMap<PlaceEntity, PlaceListingResponseDTO>();

            CreateMap<PlaceRequest, PlaceEntity>().ReverseMap();
            CreateMap<PlaceEntity, PlaceBriefResponse>()
                .ForMember(response => response.TodayWeekSchedule,
                entity => entity.MapFrom(ent => ent.WeekSchedule
                .Where(day => (int)day.Day == (int)DateTime.Now.DayOfWeek).First()))
                .ForMember(response => response.Host, entity => entity
                .MapFrom(e => new HostResponse
                {
                    fbId = e.HostUser.FbKey,
                    Name = e.HostUser.Name,
                    ProfilePictureUri = Helpers.ConvertToPictureUri(e.HostUser.MongoKey),
                    Surename = e.HostUser.Surename
                }))
            .ReverseMap(); 
        }
    }
}
