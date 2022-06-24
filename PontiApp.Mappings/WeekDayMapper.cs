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
    public class WeekDayMapper : Profile
    {
        public WeekDayMapper()
        {
            CreateMap<WeekScheduleDTO, WeekEntity>().ReverseMap();

            CreateMap<WeekScheduleRequest, WeekEntity>().ReverseMap();

            CreateMap<WeekScheduleResponse, WeekEntity>().ReverseMap();
        }
    }
}
