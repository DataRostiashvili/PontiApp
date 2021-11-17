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
            CreateMap<PlaceEntity, PlaceHostingResponse>()
                .ForMember(response => response.TodayWeekSchedule,
                entity => entity.MapFrom(ent => ent.WeekSchedule
                .Where(day => (DayOfWeek)day.Day == DateTime.Now.DayOfWeek))).ReverseMap(); 
        }
    }
}
