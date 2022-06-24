using PontiApp.Models.DTOs;
using PontiApp.Models.Request;
using PontiApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.WeekDayServices
{
    public interface IWeekDayService
    {
        Task AddWeekDays(List<WeekScheduleRequest> weekDaysDTO);
        Task UpdateWeekDays(List<WeekScheduleRequest> weekDaysDTO);
        Task<List<WeekScheduleResponse>> GetWeekSchedules();
    }
}
