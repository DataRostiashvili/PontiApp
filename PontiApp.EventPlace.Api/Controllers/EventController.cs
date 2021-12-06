using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.EventPlace.Services.EventServices;
using PontiApp.Models.DTOs;
using PontiApp.Models.DTOs.Enums;
using PontiApp.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using PontiApp.Models.Response;

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
        public async Task<ActionResult> CreateEvent([FromForm]CompositeObj<EventHostRequestDTO> eventDTO)
        {
            await _eventService.AddHostingEvent(eventDTO);
            return Ok();
        }

        [HttpPut]
        [Route(nameof(UpdateEvent))]
        
        public async Task<ActionResult> UpdateEvent([FromBody] EventHostRequestDTO hostEventDTO)
        {

            await _eventService.UpdateHostingEvent(hostEventDTO);
            return Ok();

        }

        [HttpDelete]
        [Route(nameof(DeleteEvent))]
        public async Task<ActionResult> DeleteEvent(int hostEventId)
        {

            await _eventService.DeleteHostingEvent(hostEventId);
            return Ok();

        }

        //[HttpGet("GetDetailedHostingEvent/{id}")]
        //public async Task<ActionResult<EventHostResponseDTO>> GetDetailedHostingEvent(int id)
        //{

        //    return Ok(await _eventService.GetDetailedHostingEvent(id));

        //}
        [HttpGet]
        [Route("GetDetailedEvent/{id}")]
        
        public async Task<ActionResult<EventDetailedResponse>> GetDetailedEvent(int id)
        {

            return Ok(await _eventService.GetDetailedEvent(id));

        }

        //[HttpGet("GetGuestingEvent/{eventId}/{guestId}")]
        //public async Task<ActionResult<EventGuestResponseDTO>> GetGuestingEvent(int eventId, int guestId)
        //{

        //    EventGuestRequestDTO guestRequestDTO = new EventGuestRequestDTO()
        //    {
        //        EventId = eventId,
        //        UserGuestId = guestId
        //    };
        //    return Ok(await _eventService.GetDetailedGuestingEvent(guestRequestDTO));

        //}

        [HttpGet(nameof(GetHostingEvents))]
        public async Task<ActionResult<IEnumerable<EventBriefResponse>>> GetHostingEvents(long hostFbId)
        {

            return Ok(await _eventService.GetAllHsotingEvent(hostFbId));

        }

        [HttpPost]
        [Route(nameof(AddInGuestingEvents))]
        public async Task<ActionResult> AddInGuestingEvents([FromBody] EventGuestRequestDTO guestEventDTO)
        {

            await _eventService.AddGusestingEvent(guestEventDTO);
            return Ok();

        }

        [HttpPut]
        [Route(nameof(UpdateInGuestingEvents))]
        public async Task<ActionResult> UpdateInGuestingEvents([FromBody] EventReviewDTO eventReviewDTO)
        {

            await _eventService.UpdateGuestingEvent(eventReviewDTO);
            return Ok();

        }

        [HttpPut]
        [Route(nameof(RemoveFromGuestingEvents))]
        public async Task<ActionResult> RemoveFromGuestingEvents([FromBody] EventGuestRequestDTO guestEventDTO)
        {

            await _eventService.DeleteGuestingEvent(guestEventDTO);
            return Ok();

        }

        [HttpGet("GetGuestingEvents/{userGuestId}")]
        public async Task<ActionResult<IEnumerable<EventListingResponseDTO>>> GetGuestingEvents(int userGuestId)
        {

            return Ok(await _eventService.GetAllGuestingEvent(userGuestId));

        }

        [HttpGet("GetAllEvent")]
        
        public async Task<ActionResult<IEnumerable<EventBriefResponse>>> GetAllEvent()
        {

            return Ok(await _eventService.GetAllEvent());

        }

        [HttpPost("SearchEvent")]
        
        public async Task<IActionResult> SearchEvent(PontiTypeEnum PontiType, List<CategoryRequest> Categories, TimeFilterEnum Time, string SearchKeyWord)
        {
            if (PontiType != PontiTypeEnum.Event)
            {
                return BadRequest();
            }

            var searchDto = new SearchFilter
            {
                PontiType = PontiType,
                Time = Time,
                SearchKeyWord = SearchKeyWord
            };

            searchDto.Categories = new();
            foreach (var cat in Categories)
            {
                searchDto.Categories.Add(cat);
            }


            var searchResult = await _eventService.GetSearchedEvents(searchDto);

            return Ok(searchResult);
        }

        //add photos

        //remove photos

        //update photos
    }
}
