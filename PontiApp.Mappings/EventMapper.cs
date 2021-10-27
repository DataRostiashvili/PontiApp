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
            CreateMap<EventHostRequestDTO, EventEntity>();
            CreateMap<EventEntity, EventHostResponseDTO>();
            CreateMap<EventEntity, EventGuestResponseDTO>();
            CreateMap<EventEntity, EventListingResponseDTO>();
        }
    }
}
