using AutoMapper;
using PontiApp.Data.DbContexts;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Ponti.Repository.PontiRepository;
using PontiApp.Validators.EntityValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.EventServices
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly EventDTOValidator _validator;
        private readonly EventRepository _eventRepo;

        public EventService(IMapper mapper, EventDTOValidator validator, EventRepository eventRepo)
        {
            _mapper = mapper;
            _validator = validator;
            _eventRepo = eventRepo;
        }

        public async Task AddHostingEvent(EventDTO newEventDTO)
        {
            EventEntity newEvent = _mapper.Map<EventEntity>(newEventDTO);
            await _eventRepo.InsertHosting(newEvent);

            
        }

        public async Task DeleteHostingEvent(EventDTO currEventDTO)
        {
            EventEntity currEvent = _mapper.Map<EventEntity>(currEventDTO);
            await _eventRepo.DeleteHosting(currEvent);
        }

        public async  Task<IEnumerable<EventDTO>> GetAllEvent()
        {
            IEnumerable<EventEntity> allEvent = await _eventRepo.GetAll();
            IEnumerable<EventDTO> allEventDTOs = _mapper.Map<IEnumerable<EventDTO>>(allEvent);
            
            return allEventDTOs;     
        }

        public async Task<IEnumerable<EventDTO>> GetAllGuestingEvent(MyPontsFilterDTO GuestingDTO)
        {
            IEnumerable<EventEntity> guestingEvents = await _eventRepo.GetAllGuesting(GuestingDTO.UserId);
            IEnumerable<EventDTO> guestingEventDTOs = _mapper.Map<IEnumerable<EventDTO>>(guestingEvents);

            return guestingEventDTOs;
        }

        public async Task<IEnumerable<EventDTO>> GetAllHsotingEvent(MyPontsFilterDTO HostingDTO)
        {
            IEnumerable<EventEntity> hostingEvents = await _eventRepo.GetAllHosting(HostingDTO.UserId);
            IEnumerable<EventDTO> hostingEventDTOs = _mapper.Map<IEnumerable<EventDTO>>(hostingEvents);

            return hostingEventDTOs;
        }

        public Task<IEnumerable<EventDTO>> GetSearchedEvents(SearchBaseDTO searchBaseDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<EventDTO> GetSingleEvent(int eventId)
        {
            EventEntity currEvent = await _eventRepo.GetByID(eventId);
            return _mapper.Map<EventDTO>(currEvent);
        }

        public async Task UpdateHostingEvent(EventDTO currEventDTO)
        {
            EventEntity currEvent = _mapper.Map<EventEntity>(currEventDTO);
            await _eventRepo.Update(currEvent);
        }
    }
}
