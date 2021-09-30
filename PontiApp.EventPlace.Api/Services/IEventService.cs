using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Api.Services
{
    public interface IEventService
    {
        Task AddEvent(EventDTO newEventDTO);
        Task UpdateEvent(EventDTO currEventDTO);
        Task DeleteEvent(EventDTO currEventDTO);
        Task<EventDTO> GetSingleEvent(int QueueId);
        Task<IEnumerable<EventDTO>> GetAllEvent();
        Task<IEnumerable<EventDTO>> GetSearchedEvents(SearchBaseDTO searchBaseDTO);
        Task<IEnumerable<EventDTO>> GetAllHsotingEvent(MyPontsFilterDTO HostingDTO);
        Task<IEnumerable<EventDTO>> GetAllGuestingEvent(MyPontsFilterDTO GuestingDTO);

    }
}
