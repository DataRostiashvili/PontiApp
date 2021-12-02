using Microsoft.AspNetCore.Mvc;
using PontiApp.Models.DTOs;
using PontiApp.Models.Request;
using PontiApp.Models.DTOs.Enums;
using PontiApp.PlacePlace.Services.PlaceServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PontiApp.Models.Response;

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
        public async Task<ActionResult> CreatePlace([FromBody] PlaceRequest placeRequest)
        {

            await _placeService.AddHostingPlace(placeRequest);
            return Ok();

        }

        [HttpPut]
        [Route(nameof(UpdatePlace))]
        public async Task<ActionResult> UpdatePlace([FromBody] PlaceHostRequestDTO hostPlaceDTO)
        {

            await _placeService.UpdateHostingPlace(hostPlaceDTO);
            return Ok();

        }

        [HttpDelete]
        [Route(nameof(DeletePlace))]
        public async Task<ActionResult> DeletePlace(int hostPlaceId)
        {

            await _placeService.DeleteHostingPlace(hostPlaceId);
            return Ok();

        }

        //Should be separated
        [HttpGet("GetDetailedPlace/{id}")]
        public async Task<ActionResult<PlaceHostResponseDTO>> GetDetailedPlace(int id)
        {

            return Ok(await _placeService.GetDetailedPlace(id));

        }

        

        [HttpGet("GetHostingPlaces")]
        public async Task<ActionResult<IEnumerable<PlaceBriefResponse>>> GetHostingPlaces(long hostFbId)
        {

            return Ok(await _placeService.GetAllHsotingPlace(hostFbId));

        }

        [HttpPost]
        [Route(nameof(AddInGuestingPlaces))]
        public async Task<ActionResult> AddInGuestingPlaces([FromBody] PlaceGuestRequestDTO guestPlaceDTO)
        {

            await _placeService.AddGusestingPlace(guestPlaceDTO);
            return Ok();

        }

        [HttpPut]
        [Route(nameof(UpdateInGuestingPlaces))]
        public async Task<ActionResult> UpdateInGuestingPlaces([FromBody] PlaceReviewDTO placeReviewDTO)
        {

            await _placeService.UpdateGuestingPlace(placeReviewDTO);
            return Ok();

        }

        [HttpPut]
        [Route(nameof(RemoveFromGuestingPlaces))]
        public async Task<ActionResult> RemoveFromGuestingPlaces([FromBody] PlaceGuestRequestDTO guestPlaceDTO)
        {

            await _placeService.DeleteGuestingPlace(guestPlaceDTO);
            return Ok();

        }

        [HttpGet("GuestingPlaces/{userGuestId}")]
        public async Task<ActionResult<IEnumerable<PlaceListingResponseDTO>>> GetGuestingPlaces(int userGuestId)
        {

            return Ok(await _placeService.GetAllGuestingPlace(userGuestId));

        }

        [HttpGet("GetAllPlace")]
        public async Task<ActionResult<IEnumerable<PlaceBriefResponse>>> GetAllPlace()
        {

            return Ok(await _placeService.GetAllPlace());


        }

        [HttpPost("SearchPlace")]
        public async Task<IActionResult> SearchPlace(PontiTypeEnum PontiType, List<CategoryRequest> Categories, TimeFilterEnum Time, string SearchKeyWord)
        {
            if (PontiType != PontiTypeEnum.Place)
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

            var searchResult = await _placeService.GetSearchedPlaces(searchDto);

            return Ok(searchResult);
        }
    }
}
