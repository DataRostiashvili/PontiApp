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
        Task AddGusestingEvent(GuestDTO currEventGuestDTO);
        Task UpdateHostingEvent(EventRequestDTO currEventHostDTO);
        Task UpdateGuestingEvent(GuestDTO currEventGuestDRO);
        Task DeleteHostingEvent(HostDTO currEventHostDTO);
        Task DeleteGuestingEvent(GuestDTO currEventGuestDTO);
        Task<EventRequestDTO> GetSingleEvent(int eventId);
        Task<IEnumerable<EventRequestDTO>> GetAllEvent();
        Task<IEnumerable<EventRequestDTO>> GetSearchedEvents(SearchBaseDTO searchBaseDTO);
        Task<IEnumerable<EventRequestDTO>> GetAllHsotingEvent(int userHostQueueId);
        Task<IEnumerable<EventRequestDTO>> GetAllGuestingEvent(int userGuestQueueId);

    }
}
