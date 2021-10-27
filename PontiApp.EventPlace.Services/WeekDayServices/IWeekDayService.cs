using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.WeekDayServices
{
    public interface IWeekDayService
    {
        Task AddWeekDays(List<WeekScheduleDTO> weekDaysDTO);
        Task UpdateWeekDays(List<WeekScheduleDTO> weekDaysDTO);
        Task<List<WeekScheduleDTO>> GetWeekSchedules();
    }
}
