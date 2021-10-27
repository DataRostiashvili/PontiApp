using Microsoft.AspNetCore.Mvc;
using PontiApp.Models.DTOs;
using PontiApp.Models.DTOs.Enums;
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
        public async Task<ActionResult> CreatePlace([FromBody] PlaceHostRequestDTO PlaceDTO)
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
        public async Task<ActionResult> UpdatePlace([FromBody] PlaceHostRequestDTO hostPlaceDTO)
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
        public async Task<ActionResult> DeletePlace(int hostPlaceId)
        {
            try
            {
                await _placeService.DeleteHostingPlace(hostPlaceId);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //Should be separated
        [HttpGet("GetDetailedHostingPlace/{id}")]
        public async Task<ActionResult<PlaceHostResponseDTO>> GetDetailedHostingPlace(int id)
        {
            try
            {
                
                return Ok(await _placeService.GetDetailedHostingPlace(id));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("GetGuestingPlace/{place}/{guestId}")]
        public async Task<ActionResult<PlaceGuestResponseDTO>> GetGuestingPlace(int placeId, int guestId)
        {
            try
            {
                PlaceGuestRequestDTO guestRequestDTO = new PlaceGuestRequestDTO()
                {
                    PlaceId = placeId,
                    UserGuestId = guestId
                };

                return Ok(await _placeService.GetDetailedGuestingPlace(guestRequestDTO));
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("GetHostingPlaces/{userHostId}")]
        public async Task<ActionResult<IEnumerable<PlaceListingResponseDTO>>> GetHostingPlaces(int userHostId)
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

        [HttpPost]
        [Route(nameof(AddInGuestingPlaces))]
        public async Task<ActionResult> AddInGuestingPlaces([FromBody] PlaceGuestRequestDTO guestPlaceDTO)
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
        public async Task<ActionResult> UpdateInGuestingPlaces([FromBody] PlaceReviewDTO placeReviewDTO)
        {
            try
            {
                await _placeService.UpdateGuestingPlace(placeReviewDTO);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPut]
        [Route(nameof(RemoveFromGuestingPlaces))]
        public async Task<ActionResult> RemoveFromGuestingPlaces([FromBody] PlaceGuestRequestDTO guestPlaceDTO)
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
        public async Task<ActionResult<IEnumerable<PlaceListingResponseDTO>>> GetGuestingPlaces(int userGuestId)
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
        public async Task<ActionResult<IEnumerable<PlaceListingResponseDTO>>> GetAllPlace()
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

        [HttpGet("SearchPlace")]
        public async Task<IActionResult> SearchPlace(SearchBaseDTO searchDto)
        {
            if (searchDto.PontiType != PontiTypeEnum.Place)
            {
                return BadRequest();
            }
            var searchResult = await _placeService.GetSearchedPlaces(searchDto);

            return Ok(searchResult);
        }
    }
}
