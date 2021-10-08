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
        Task AddHostingEvent(EventDTO newEventDTO);
        Task AddGusestingEvent(EventGuestDTO currEventGuestDTO);
        Task UpdateHostingEvent(HostDTO currEventHostDTO);
        Task UpdateGuestingEvent(EventGuestDTO currEventGuestDRO);
        Task DeleteHostingEvent(HostDTO currEventHostDTO);
        Task DeleteGuestingEvent(EventGuestDTO currEventGuestDTO);
        Task<EventDTO> GetSingleEvent(int eventId);
        Task<IEnumerable<EventDTO>> GetAllEvent();
        Task<IEnumerable<EventDTO>> GetSearchedEvents(SearchBaseDTO searchBaseDTO);
        Task<IEnumerable<EventDTO>> GetAllHsotingEvent(MyPontsFilterDTO HostingDTO);
        Task<IEnumerable<EventDTO>> GetAllGuestingEvent(MyPontsFilterDTO GuestingDTO);

    }
}
