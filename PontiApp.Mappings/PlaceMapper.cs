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
            CreateMap<PlaceDTO, PlaceEntity>().ReverseMap();
                //.ForMember(dest => dest.PlaceCategories, opt => opt.MapFrom(src => EncapsulateDTOToEntity(src.Categories, src.Id)));

            //CreateMap<PlaceEntity, PlaceDTO>()
            //    .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => EncapsulateEntityToDTO(src.PlaceCategories)));

        }

        private static List<PlaceCategory> EncapsulateDTOToEntity(ICollection<int> rawData, int Id)
        {
            List<PlaceCategory> res = new List<PlaceCategory>();

            foreach (var c in rawData)
            {
                PlaceCategory PlaceCat = new()
                {
                    CategoryEntityId = c,
                    PlaceEntityId = Id
                };

                res.Add(PlaceCat);
            }
            return res;
        }

        private static List<int> EncapsulateEntityToDTO(List<PlaceCategory> rawData)
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
