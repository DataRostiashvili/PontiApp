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
        Task AddGusestingPlace(GuestDTO currPlaceGuestDTO);
        Task UpdateHostingPlace(PlaceRequestDTO currPlaceHostDTO);
        Task UpdateGuestingPlace(GuestDTO currPlaceGuestDRO);
        Task DeleteHostingPlace(HostDTO currPlaceHostDTO);
        Task DeleteGuestingPlace(GuestDTO currPlaceGuestDTO);
        Task<PlaceResponseDTO> GetSinglePlace(int PlaceId);
        Task<List<PlaceResponseDTO>> GetAllPlace();
        Task<List<PlaceResponseDTO>> GetSearchedPlaces(SearchBaseDTO searchBaseDTO);
        Task<List<PlaceResponseDTO>> GetAllHsotingPlace(int userHostQueueId);
        Task<List<PlaceResponseDTO>> GetAllGuestingPlace(int userGuestQueueId);
    }
}
