using AutoMapper;
using PontiApp.Models;
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
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<EventCategoryDTO, EventCategory>().ReverseMap();

            CreateMap<PlaceCategoryDTO, PlaceCategory>().ReverseMap();

            CreateMap<CategoryDTO, CategoryEntity>().ReverseMap();

            CreateMap<CategoryRequest, CategoryEntity>().ReverseMap();

            CreateMap<CategoryResponse, CategoryEntity>().ReverseMap();
        }
    }
}
