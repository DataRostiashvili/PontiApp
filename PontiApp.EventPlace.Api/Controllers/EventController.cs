using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.EventPlace.Services.EventServices;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        [Route(nameof(CreateEvent))]
        public async Task<ActionResult> CreateEvent([FromBody] EventRequestDTO eventDTO)
        {
            try
            {
                await _eventService.AddHostingEvent(eventDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [Route(nameof(UpdateEvent))]
        public async Task<ActionResult> UpdateEvent([FromBody] EventRequestDTO hostEventDTO)
        {
            try
            {
                await _eventService.UpdateHostingEvent(hostEventDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route(nameof(DeleteEvent))]
        public async Task<ActionResult> DeleteEvent(int hostEventId)
        {
            try
            {
                await _eventService.DeleteHostingEvent(hostEventId);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("GetEvent/{id}")]
        public async Task<ActionResult<EventResponseDTO>> GetEvent(int id)
        {
            try
            {
                return Ok(await _eventService.GetSingleEvent(id));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("GetHostingEvents/{userHostId}")]
        public async Task<ActionResult<IEnumerable<EventResponseDTO>>> GetHostingEvents(int userHostId)
        {
            try
            {
                return Ok(await _eventService.GetAllHsotingEvent(userHostId));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost]
        [Route(nameof(AddInGuestingEvents))]
        public async Task<ActionResult> AddInGuestingEvents([FromBody] EventGuestDTO guestEventDTO)
        {
            try
            {
                await _eventService.AddGusestingEvent(guestEventDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [Route(nameof(UpdateInGuestingEvents))]
        public async Task<ActionResult> UpdateInGuestingEvents([FromBody] EventReviewDTO eventReviewDTO)
        {
            try
            {
                await _eventService.UpdateGuestingEvent(eventReviewDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [Route(nameof(RemoveFromGuestingEvents))]
        public async Task<ActionResult> RemoveFromGuestingEvents([FromBody] EventGuestDTO guestEventDTO)
        {
            try
            {
                await _eventService.DeleteGuestingEvent(guestEventDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("GetGuestingEvents/{userGuestId}")]
        public async Task<ActionResult<IEnumerable<EventResponseDTO>>> GetGuestingEvents(int userGuestId)
        {
            try
            {
                return Ok(await _eventService.GetAllGuestingEvent(userGuestId));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("GetAllEvent")]
        public async Task<ActionResult<IEnumerable<EventResponseDTO>>> GetAllEvent()
        {
            try
            {
                return Ok(await _eventService.GetAllEvent());
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
