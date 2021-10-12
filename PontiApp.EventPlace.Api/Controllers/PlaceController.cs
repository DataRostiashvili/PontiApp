using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.Models.DTOs;
using PontiApp.PlacePlace.Services.PlaceServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontiApp.PlacePlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly PlaceService _placeService;

        public PlaceController(PlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpPost]
        [Route(nameof(CreatePlace))]
        public async Task<ActionResult> CreatePlace([FromBody] PlaceDTO PlaceDTO)
        {
            try
            {
                await _placeService.AddHostingPlace(PlaceDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [Route(nameof(UpdatePlace))]
        public async Task<ActionResult> UpdatePlace([FromBody] HostDTO hostPlaceDTO)
        {
            try
            {
                await _placeService.UpdateHostingPlace(hostPlaceDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route(nameof(DeletePlace))]
        public async Task<ActionResult> DeletePlace([FromBody] HostDTO hostPlaceDTO)
        {
            try
            {
                await _placeService.DeleteHostingPlace(hostPlaceDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("GetPlace/{id}")]
        public async Task<ActionResult<PlaceDTO>> GetPlace(int id)
        {
            try
            {
                await _placeService.GetSinglePlace(id);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("GetHostingPlaces/{id}")]
        public async Task<ActionResult<IEnumerable<PlaceDTO>>> GetHostingPlaces(int id)
        {
            try
            {
                return Ok(await _placeService.GetAllHsotingPlace(id));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [Route(nameof(AddInGuestingPlaces))]
        public async Task<ActionResult> AddInGuestingPlaces([FromBody] GuestDTO guestPlaceDTO)
        {
            try
            {
                await _placeService.AddGusestingPlace(guestPlaceDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [Route(nameof(UpdateInGuestingPlaces))]
        public async Task<ActionResult> UpdateInGuestingPlaces([FromBody] GuestDTO guestPlaceDTO)
        {
            try
            {
                await _placeService.UpdateGuestingPlace(guestPlaceDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [Route(nameof(RemoveFromGuestingPlaces))]
        public async Task<ActionResult> RemoveFromGuestingPlaces([FromBody] GuestDTO guestPlaceDTO)
        {
            try
            {
                await _placeService.DeleteGuestingPlace(guestPlaceDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("GuestingPlaces/{id}")]
        public async Task<ActionResult<IEnumerable<PlaceDTO>>> GetGuestingPlaces(int userGuestQueueId)
        {
            try
            {
                return Ok(await _placeService.GetAllGuestingPlace(userGuestQueueId));
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
