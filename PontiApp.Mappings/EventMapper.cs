using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;

namespace PontiApp.Mappings
{
    public class EventMapper : Profile
    {
        public EventMapper()
        {
            CreateMap<EventEntity, EventDTO>();
            CreateMap<EventDTO, EventEntity>()
                       .ForMember(dest => dest.Pictures, opt => opt.MapFrom(src => Encapsulate(src.Categories)));

            CreateMap<IEnumerable<EventDTO>, IEnumerable<EventEntity>>();
            CreateMap<IEnumerable<EventEntity>, IEnumerable<EventDTO>>();

        }

        private static ICollection<CategoryEntity> Encapsulate(ICollection<string> rawData)
        {
            List<CategoryEntity> res = new List<CategoryEntity>();

            foreach (var p in rawData)
            {
                CategoryEntity eventPic = new()
                {
                   Cetegory = p
                };

                res.Add(eventPic);
            }
            return res;
        }
    }
}
