using Microsoft.AspNetCore.Http;
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
        Task AddHostingPlace(CompositeObj<PlaceHostRequestDTO,IFormFileCollection> newPlaceDTO);
        Task AddGusestingPlace(PlaceGuestRequestDTO currPlaceGuestDTO);
        Task UpdateHostingPlace(PlaceHostRequestDTO currPlaceHostDTO);
        Task UpdateGuestingPlace(PlaceReviewDTO placeReviewDTO);
        Task DeleteHostingPlace(int hostPlaceId);
        Task DeleteGuestingPlace(PlaceGuestRequestDTO currPlaceGuestDTO);
        Task<PlaceDetailedResponse> GetDetailedPlace(int placeId);
        Task<List<PlaceBriefResponse>> GetAllPlace();
        Task<List<PlaceListingResponseDTO>> GetSearchedPlaces(SearchFilter searchBaseDTO);
        Task<List<PlaceBriefResponse>> GetAllHsotingPlace(long userHostfbId);
        Task<List<PlaceListingResponseDTO>> GetAllGuestingPlace(int userGuestId);
        Task RemoveFromHostingImages(int placeId, int[] indices);
        Task AddToHostingImages(int placeId, IFormFileCollection files);
    }
}
