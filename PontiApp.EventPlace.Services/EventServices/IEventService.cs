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
        Task AddHostingEvent(EventRequestDTO newEventDTO);
        Task AddGusestingEvent(EventGuestDTO currEventGuestDTO);
        Task UpdateHostingEvent(EventRequestDTO currEventHostDTO);
        Task UpdateGuestingEvent(EventReviewDTO eventReviewDTO);
        Task DeleteHostingEvent(int hostEventId);
        Task DeleteGuestingEvent(EventGuestDTO currEventGuestDTO);
        Task<EventResponseDTO> GetSingleEvent(int eventId);
        Task<List<EventResponseDTO>> GetAllEvent();
        Task<List<EventResponseDTO>> GetSearchedEvents(SearchBaseDTO searchBaseDTO);
        Task<List<EventResponseDTO>> GetAllHsotingEvent(int userHostId);
        Task<List<EventResponseDTO>> GetAllGuestingEvent(int userGuestId);

    }
}
