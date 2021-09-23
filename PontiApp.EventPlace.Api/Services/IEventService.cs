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
        Task<EventDTO> GetSingleEvent(EventDTO currEventDTO);
        Task<IEnumerable<EventDTO>> GetAllEvent();
        Task<IEnumerable<EventDTO>> GetAllHsotingEvent();
        Task<IEnumerable<EventDTO>> GetAllGuestingEvent();

    }
}
