using AutoMapper;
using PontiApp.Data.DbContexts;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Ponti.Repository.PontiRepository;
using PontiApp.Validators.EntityValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Api.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;
        private readonly EventDTOValidator _eventValidator;
        private readonly IMapper _mapper;
        private readonly IPontiRepository<EventEntity> _repo;

        public EventService(ApplicationDbContext context, IMapper mapper, IPontiRepository<EventEntity> repo)
        {
            _context = context;
            _mapper = mapper;
            _eventValidator = new EventDTOValidator(context);
            _repo = repo;

        }

        public async Task AddEvent(EventDTO newEventDTO)
        {
            if(!_eventValidator.Exists(newEventDTO))
            {
                EventEntity newEvent = _mapper.Map<EventEntity>(newEventDTO);
                await _repo.Insert(newEvent);            
            }

            //RabbitMQ for images
        }

        public async Task DeleteEvent(EventDTO currEventDTO)
        {
            if (!_eventValidator.Exists(currEventDTO))
            {
                EventEntity currEvent = _mapper.Map<EventEntity>(currEventDTO);
                await _repo.Delete(currEvent);
            }
        }

        public async Task<IEnumerable<EventDTO>> GetAllEvent()
        {
            IEnumerable<EventEntity> rawEventsData = await _repo.GetAll();
            List<EventDTO> allEventDTO = _mapper.Map<List<EventDTO>>(rawEventsData);

            return allEventDTO;
        }

        public Task<IEnumerable<EventDTO>> GetAllGuestingEvent()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventDTO>> GetAllHsotingEvent()
        {
            throw new NotImplementedException();
        }

        public async Task<EventDTO> GetSingleEvent(EventDTO currEventDTO)
        {
            EventEntity currEvent = await _repo.GetByID(currEventDTO.QueueId);
            return _mapper.Map<EventDTO>(currEvent);
            
        }

        public async Task UpdateEvent(EventDTO currEventDTO)
        {
            EventEntity currEvent = _mapper.Map<EventEntity>(currEventDTO);
            await _repo.Update(currEvent);
        }
    }
}
