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
        Task AddGusestingEvent(EventDTO currEventDTO);
        Task UpdateHostingEvent(EventDTO currEventDTO);
        Task UpdateGuestingEvent(EventDTO currEventDRO);
        Task DeleteHostingEvent(EventDTO currEventDTO);
        Task DeleteGuestingEvent(EventDTO currEventDTO);
        Task<EventDTO> GetSingleEvent(int eventId);
        Task<IEnumerable<EventDTO>> GetAllEvent();
        Task<IEnumerable<EventDTO>> GetSearchedEvents(SearchBaseDTO searchBaseDTO);
        Task<IEnumerable<EventDTO>> GetAllHsotingEvent(MyPontsFilterDTO HostingDTO);
        Task<IEnumerable<EventDTO>> GetAllGuestingEvent(MyPontsFilterDTO GuestingDTO);
    }
}
