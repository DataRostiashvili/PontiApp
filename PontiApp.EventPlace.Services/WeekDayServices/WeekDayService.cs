using AutoMapper;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Models.Request;
using PontiApp.Models.Response;
using PontiApp.Ponti.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.WeekDayServices
{
    public class WeekDayService : IWeekDayService
    {
        private readonly BaseRepository<WeekEntity> _weekDayRepository;
        private readonly IMapper _mapper;

        public WeekDayService(BaseRepository<WeekEntity> weekDayRepository, IMapper mapper)
        {
            _weekDayRepository = weekDayRepository;
            _mapper = mapper;
        }
        public async Task AddWeekDays(List<WeekScheduleRequest> weekSchedule)
        {
            var weekDays = _mapper.Map<List<WeekEntity>>(weekSchedule);
            await _weekDayRepository.InsertRange(weekDays);
        }

        public async Task UpdateWeekDays(List<WeekScheduleRequest> weekSchedule)
        {
            var weekDays = _mapper.Map<List<WeekEntity>>(weekSchedule);
            await _weekDayRepository.UpdateRange(weekDays);
        }

        public async Task<List<WeekScheduleResponse>> GetWeekSchedules()
        {
            var weekDays = await _weekDayRepository.GetAll();
            return _mapper.Map<List<WeekScheduleResponse>>(weekDays);
        }
    }
}
