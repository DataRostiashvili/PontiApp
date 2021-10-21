using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.PlacePlace.Services.PlaceServices
{
    public interface IPlaceService
    {
        Task AddHostingPlace(PlaceRequestDTO newPlaceDTO);
        Task AddGusestingPlace(PlaceGuestDTO currPlaceGuestDTO);
        Task UpdateHostingPlace(PlaceRequestDTO currPlaceHostDTO);
        Task UpdateGuestingPlace(PlaceReviewDTO placeReviewDTO);
        Task DeleteHostingPlace(int hostPlaceId);
        Task DeleteGuestingPlace(PlaceGuestDTO currPlaceGuestDTO);
        Task<PlaceResponseDTO> GetSinglePlace(int placeId);
        Task<List<PlaceResponseDTO>> GetAllPlace();
        Task<List<PlaceResponseDTO>> GetSearchedPlaces(SearchBaseDTO searchBaseDTO);
        Task<List<PlaceResponseDTO>> GetAllHsotingPlace(int userHostId);
        Task<List<PlaceResponseDTO>> GetAllGuestingPlace(int userGuestId);
    }
}
