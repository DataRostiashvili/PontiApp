using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.EventPlace.Services.WeekDayServices;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
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
        public async Task<ActionResult> AddWeekDay([FromBody] List<WeekScheduleDTO> weekDayDTOs)
        {
            try
            {
                await _weekDayService.AddWeekDays(weekDayDTOs);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [Route(nameof(UpdateWeekDay))]
        public async Task<ActionResult> UpdateWeekDay([FromBody] List<WeekScheduleDTO> weekDayDTOs)
        {
            try
            {
                await _weekDayService.UpdateWeekDays(weekDayDTOs);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("GetAllWeekDays")]
        public async Task<ActionResult<IEnumerable<WeekScheduleDTO>>> GetAllWeekDays()
        {
            try
            {
                List<WeekScheduleDTO> weekDays = await _weekDayService.GetWeekSchedules();
                return Ok(weekDays);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
