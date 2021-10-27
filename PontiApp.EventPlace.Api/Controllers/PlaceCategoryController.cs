using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PontiApp.EventPlace.Services.PlaceCategoryServices;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceCategoryController : ControllerBase
    {
        private readonly IPlaceCategoryService _placeCategoryService;

        public PlaceCategoryController(IPlaceCategoryService placeCategoryService)
        {
            _placeCategoryService = placeCategoryService;
        }

        [HttpPost]
        [Route(nameof(AddPlaceCategory))]
        public async Task<ActionResult> AddPlaceCategory([FromBody] List<PlaceCategoryDTO> placeCategoryDTOsUp)
        {
            try
            {
                await _placeCategoryService.AddPlaceCategoryBond(placeCategoryDTOsUp);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpDelete]
        [Route(nameof(DeletePlaceCategory))]
        public async Task<ActionResult> DeletePlaceCategory([FromBody] List<PlaceCategoryDTO> placeCategoryDTOsDown)
        {
            try
            {
                await _placeCategoryService.DeletePlaceCategoryBond(placeCategoryDTOsDown);
                return Ok();
            }
            catch (Exception e)
            {
                throw;
            }
        }


    }
}
