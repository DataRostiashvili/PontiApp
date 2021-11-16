using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.EventPlace.Services.WeekDayServices;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Models.Request;
using PontiApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeekDayController : ControllerBase
    {
        private readonly IWeekDayService _weekDayService;

        public WeekDayController(IWeekDayService weekDayService)
        {
            _weekDayService = weekDayService;
        }

        [HttpPost]
        [Route(nameof(AddWeekDay))]
        public async Task<ActionResult> AddWeekDay([FromBody] List<WeekScheduleRequest> weekSchedule)
        {
            try
            {
                await _weekDayService.AddWeekDays(weekSchedule);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [Route(nameof(UpdateWeekDay))]
        public async Task<ActionResult> UpdateWeekDay([FromBody] List<WeekScheduleRequest> weekSchedule)
        {
            try
            {
                await _weekDayService.UpdateWeekDays(weekSchedule);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("GetAllWeekDays")]
        public async Task<ActionResult<IEnumerable<WeekScheduleResponse>>> GetAllWeekDays()
        {
            try
            {
                var weekDays = await _weekDayService.GetWeekSchedules();
                return Ok(weekDays);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
