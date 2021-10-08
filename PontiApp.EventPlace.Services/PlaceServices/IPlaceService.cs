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
        Task AddGusestingPlace(PlaceGuestDTO currPlaceGuestDTO);
        Task UpdateHostingPlace(HostDTO currPlaceHostDTO);
        Task UpdateGuestingPlace(PlaceGuestDTO currPlaceGuestDRO);
        Task DeleteHostingPlace(HostDTO currPlaceHostDTO);
        Task DeleteGuestingPlace(PlaceGuestDTO currPlaceGuestDTO);
        Task<PlaceDTO> GetSinglePlace(int PlaceId);
        Task<IEnumerable<PlaceDTO>> GetAllPlace();
        Task<IEnumerable<PlaceDTO>> GetSearchedPlaces(SearchBaseDTO searchBaseDTO);
        Task<IEnumerable<PlaceDTO>> GetAllHsotingPlace(HostDTO HostingDTO);
        Task<IEnumerable<PlaceDTO>> GetAllGuestingPlace(GuestDTO GuestingDTO);
    }
}
