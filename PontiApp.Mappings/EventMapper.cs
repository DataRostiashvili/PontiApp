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
            CreateMap<EventDTO, EventEntity>();
            CreateMap<IEnumerable<EventDTO>, IEnumerable<EventEntity>>();
            CreateMap<IEnumerable<EventEntity>, IEnumerable<EventDTO>>();

        }
    }
}
