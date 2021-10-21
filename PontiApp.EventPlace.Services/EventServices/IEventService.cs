using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.EventServices
{
    public interface IEventService
    {
        Task AddHostingEvent(EventHostRequestDTO newEventDTO);
        Task AddGusestingEvent(EventGuestRequestDTO currEventGuestDTO);
        Task UpdateHostingEvent(EventHostRequestDTO currEventHostDTO);
        Task UpdateGuestingEvent(EventReviewDTO eventReviewDTO);
        Task DeleteHostingEvent(int hostEventId);
        Task DeleteGuestingEvent(EventGuestRequestDTO currEventGuestDTO);
        Task<EventHostResponseDTO> GetDetailedHostingEvent(int eventId);
        Task<EventGuestResponseDTO> GetDetailedGuestingEvent(EventGuestRequestDTO eventGuest);
        Task<List<EventHostResponseDTO>> GetAllEvent();
        Task<List<EventHostResponseDTO>> GetSearchedEvents(SearchBaseDTO searchBaseDTO);
        Task<List<EventHostResponseDTO>> GetAllHsotingEvent(int userHostId);
        Task<List<EventHostResponseDTO>> GetAllGuestingEvent(int userGuestId);

    }
}
