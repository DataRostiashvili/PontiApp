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
            CreateMap<PlaceEntity, PlaceDTO>();
            CreateMap<PlaceDTO, PlaceEntity>()
                       .ForMember(dest => dest.Pictures, opt => opt.MapFrom(src => Encapsulate(src.Categories)));

            CreateMap<IEnumerable<PlaceDTO>, IEnumerable<PlaceEntity>>();
            CreateMap<IEnumerable<PlaceEntity>, IEnumerable<PlaceDTO>>();

        }

        private static ICollection<CategoryEntity> Encapsulate(ICollection<string> rawData)
        {
            List<CategoryEntity> res = new List<CategoryEntity>();

            foreach (var c in rawData)
            {
                CategoryEntity PlaceCat = new()
                {
                    Cetegory = c
                };

                res.Add(PlaceCat);
            }
            return res;
        }
    }
}
