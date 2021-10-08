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
        Task AddHostingPlace(PlaceDTO newPlaceDTO);
        Task AddGusestingPlace(GuestDTO currPlaceGuestDTO);
        Task UpdateHostingPlace(HostDTO currPlaceHostDTO);
        Task UpdateGuestingPlace(GuestDTO currPlaceGuestDRO);
        Task DeleteHostingPlace(HostDTO currPlaceHostDTO);
        Task DeleteGuestingPlace(GuestDTO currPlaceGuestDTO);
        Task<PlaceDTO> GetSinglePlace(int PlaceId);
        Task<IEnumerable<PlaceDTO>> GetAllPlace();
        Task<IEnumerable<PlaceDTO>> GetSearchedPlaces(SearchBaseDTO searchBaseDTO);
        Task<IEnumerable<PlaceDTO>> GetAllHsotingPlace(int userHostQueueId);
        Task<IEnumerable<PlaceDTO>> GetAllGuestingPlace(int userGuestQueueId);
    }
}
