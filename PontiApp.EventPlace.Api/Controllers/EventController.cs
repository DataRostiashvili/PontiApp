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
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        [Route(nameof(CreateEvent))]
        public async Task<ActionResult> CreateEvent([FromBody] EventDTO eventDTO)
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
        public async Task<ActionResult> UpdateEvent([FromBody] HostDTO hostEventDTO)
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
        public async Task<ActionResult> DeleteEvent([FromBody] HostDTO hostEventDTO)
        {
            try
            {
                await _eventService.DeleteHostingEvent(hostEventDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDTO>> GetEvent(int id)
        {
            try
            {
                await _eventService.GetSingleEvent(id);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        [Route(nameof(GetHostingEvents))]
        public async Task<ActionResult<IEnumerable<EventDTO>>> GetHostingEvents(int userHostQueueId)
        {
            try
            {
                return Ok(await _eventService.GetAllHsotingEvent(userHostQueueId));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [Route(nameof(AddInGuestingEvents))]
        public async Task<ActionResult> AddInGuestingEvents([FromBody] GuestDTO guestEventDTO)
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
        public async Task<ActionResult> UpdateInGuestingEvents([FromBody] GuestDTO guestEventDTO)
        {
            try
            {
                await _eventService.UpdateGuestingEvent(guestEventDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [Route(nameof(RemoveFromGuestingEvents))]
        public async Task<ActionResult> RemoveFromGuestingEvents([FromBody] GuestDTO guestEventDTO)
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

        [HttpGet("{id}")]
        [Route(nameof(GetGuestingEvents))]
        public async Task<ActionResult<IEnumerable<EventDTO>>> GetGuestingEvents(int userGuestQueueId)
        {
            try
            {
                return Ok(await _eventService.GetAllGuestingEvent(userGuestQueueId));
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
