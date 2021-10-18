using Microsoft.AspNetCore.Mvc;
using PontiApp.Models.DTOs;
using PontiApp.PlacePlace.Services.PlaceServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontiApp.PlacePlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        public PlaceController(IPlaceService placeService)
        {
            _placeService = placeService;
        }

        [HttpPost]
        [Route(nameof(CreatePlace))]
        public async Task<ActionResult> CreatePlace([FromBody] PlaceRequestDTO PlaceDTO)
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
        public async Task<ActionResult> UpdatePlace([FromBody] PlaceRequestDTO hostPlaceDTO)
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
        public async Task<ActionResult<PlaceResponseDTO>> GetPlace(int id)
        {
            try
            {
                
                return Ok(await _placeService.GetSinglePlace(id));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("GetHostingPlaces/{userHostId}")]
        public async Task<ActionResult<IEnumerable<PlaceResponseDTO>>> GetHostingPlaces(int userHostId)
        {
            try
            {
                return Ok(await _placeService.GetAllHsotingPlace(userHostId));
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

        [HttpGet("GuestingPlaces/{userGuestId}")]
        public async Task<ActionResult<IEnumerable<PlaceRequestDTO>>> GetGuestingPlaces(int userGuestId)
        {
            try
            {
                return Ok(await _placeService.GetAllGuestingPlace(userGuestId));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("GetAllPlace")]
        public async Task<ActionResult<IEnumerable<PlaceRequestDTO>>> GetAllPlace()
        {
            try
            {
                return Ok(await _placeService.GetAllPlace());
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
