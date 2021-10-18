using AutoMapper;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
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
            CreateMap<PlaceRequestDTO, PlaceEntity>().ReverseMap();
            CreateMap<PlaceResponseDTO, PlaceEntity>().ReverseMap();
        }
    }
}
