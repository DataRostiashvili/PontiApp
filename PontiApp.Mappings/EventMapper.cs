using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using PontiApp.Models;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;

namespace PontiApp.Mappings
{
    public class EventMapper : Profile
    {
        public EventMapper()
        {
            CreateMap<EventDTO, EventEntity>().ReverseMap();
            CreateMap<EventInsertDTO, EventEntity>().ReverseMap();
            //.ForMember(dest => dest.EventCategories, opt => opt.MapFrom(src => EncapsulateDTOToEntity(src.Categories, src.Id)));

            //CreateMap<EventEntity, EventDTO>()
            //.ForMember(dest => dest.Categories, opt => opt.MapFrom(src => EncapsulateEntityToDTO(src.EventCategories)));

        }

        private static List<EventCategory> EncapsulateDTOToEntity(ICollection<int> rawData, int Id)
        {
            List<EventCategory> res = new List<EventCategory>();

            foreach (var c in rawData)
            {
                EventCategory eventCat = new()
                {
                    CategoryEntityId = c,
                    EventEntityId = Id
                };

                res.Add(eventCat);
            }
            return res;
        }

        private static List<int> EncapsulateEntityToDTO(List<EventCategory> rawData)
        {
            List<int> res = new List<int>();

            foreach (var c in rawData)
            {
                res.Add(c.CategoryEntityId);
            }
            return res;
        }
    }
}
