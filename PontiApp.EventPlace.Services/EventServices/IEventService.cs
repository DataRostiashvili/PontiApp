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
        Task<List<EventListingResponseDTO>> GetAllEvent();
        Task<List<EventListingResponseDTO>> GetSearchedEvents(SearchFilter searchBaseDTO);
        Task<List<EventListingResponseDTO>> GetAllHsotingEvent(int userHostId);
        Task<List<EventListingResponseDTO>> GetAllGuestingEvent(int userGuestId);

    }
}
