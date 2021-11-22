using PontiApp.Models.DTOs;
using PontiApp.Models.Request;
using PontiApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.PlacePlace.Services.PlaceServices
{
    public interface IPlaceService
    {
        Task AddHostingPlace(PlaceRequest newPlaceDTO);
        Task AddGusestingPlace(PlaceGuestRequestDTO currPlaceGuestDTO);
        Task UpdateHostingPlace(PlaceHostRequestDTO currPlaceHostDTO);
        Task UpdateGuestingPlace(PlaceReviewDTO placeReviewDTO);
        Task DeleteHostingPlace(int hostPlaceId);
        Task DeleteGuestingPlace(PlaceGuestRequestDTO currPlaceGuestDTO);
        Task<PlaceHostResponseDTO> GetDetailedHostingPlace(int placeId);
        Task<PlaceGuestResponseDTO> GetDetailedGuestingPlace(PlaceGuestRequestDTO placeGuest);
        Task<List<PlaceBriefResponse>> GetAllPlace();
        Task<List<PlaceListingResponseDTO>> GetSearchedPlaces(SearchFilter searchBaseDTO);
        Task<List<PlaceBriefResponse>> GetAllHsotingPlace(long userHostfbId);
        Task<List<PlaceListingResponseDTO>> GetAllGuestingPlace(int userGuestId);
    }
}
