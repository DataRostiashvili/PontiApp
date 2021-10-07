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
                       .ForMember(dest => dest.Pictures, opt => opt.MapFrom(src => Encapsulate(src.Categories)))
                       .ForMember(dest => dest.PlaceEntity.QueueId, opt => opt.MapFrom(src => src.PlaceQueueId));

            CreateMap<IEnumerable<EventDTO>, IEnumerable<EventEntity>>();
            CreateMap<IEnumerable<EventEntity>, IEnumerable<EventDTO>>();

        }

        private static ICollection<CategoryEntity> Encapsulate(ICollection<string> rawData)
        {
            List<CategoryEntity> res = new List<CategoryEntity>();

            foreach (var c in rawData)
            {
                CategoryEntity eventCat = new()
                {
                    Cetegory = c
                };

                res.Add(eventCat);
            }
            return res;
        }
    }
}
