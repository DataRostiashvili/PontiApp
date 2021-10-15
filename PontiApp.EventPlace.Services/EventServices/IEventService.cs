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
        Task AddHostingEvent(EventInsertDTO newEventDTO);
        Task AddGusestingEvent(GuestDTO currEventGuestDTO);
        Task UpdateHostingEvent(HostDTO currEventHostDTO);
        Task UpdateGuestingEvent(GuestDTO currEventGuestDRO);
        Task DeleteHostingEvent(HostDTO currEventHostDTO);
        Task DeleteGuestingEvent(GuestDTO currEventGuestDTO);
        Task<EventDTO> GetSingleEvent(int eventId);
        Task<IEnumerable<EventDTO>> GetAllEvent();
        Task<IEnumerable<EventDTO>> GetSearchedEvents(SearchBaseDTO searchBaseDTO);
        Task<IEnumerable<EventDTO>> GetAllHsotingEvent(int userHostQueueId);
        Task<IEnumerable<EventDTO>> GetAllGuestingEvent(int userGuestQueueId);

    }
}
