using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.EventEvent.Services.EventCategoryServices;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontiApp.EventEvent.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCategoryController : ControllerBase
    {
        private readonly IEventCategoryService _eventCategoryService;

        public EventCategoryController(IEventCategoryService eventCategoryService)
        {
            _eventCategoryService = eventCategoryService;
        }

        [HttpPost]
        [Route(nameof(AddEventCategory))]
        public async Task<ActionResult> AddEventCategory([FromBody] List<EventCategoryDTO> EventCategoryDTOsUp)
        {
            try
            {
                await _eventCategoryService.AddEventCategoryBond(EventCategoryDTOsUp);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route(nameof(DeleteEventCategory))]
        public async Task<ActionResult> DeleteEventCategory([FromBody] List<EventCategoryDTO> EventCategoryDTOsDown)
        {
            try
            {
                await _eventCategoryService.DeleteEventCategoryBond(EventCategoryDTOsDown);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
