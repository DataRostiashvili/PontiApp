using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        private readonly IPontiRepository<EventEntity> _eventRepository;
        private readonly IPontiRepository<UserEntity> _userRepository;

        public EventService(ApplicationDbContext context, IMapper mapper, IPontiRepository<EventEntity> eventRepository)
        {
            _context = context;
            _mapper = mapper;
            _eventValidator = new EventDTOValidator(context);
            _eventRepository = eventRepository;
            

        }

        public async Task AddEvent(EventDTO newEventDTO)
        {
            if(!_eventValidator.Exists(newEventDTO))
            {
                EventEntity newEvent = _mapper.Map<EventEntity>(newEventDTO);

                UserEntity user = await _context.Users.Where(u => u.QueueId == newEvent.QueueId).FirstOrDefaultAsync();

                newEvent.UserHostEvents.Add(new UserHostEventEntity
                {
                    Event = newEvent,
                    User = user

                });
                await _context.SaveChangesAsync();

                await _eventRepository.Insert(newEvent);            
            }

            //RabbitMQ I generate List<Keys> and pass to ImagesService List of keys and list bytes (Mayby dictionary)
        }

        public async Task DeleteEvent(EventDTO currEventDTO)
        {
            if (!_eventValidator.Exists(currEventDTO))
            {
                EventEntity currEvent = _mapper.Map<EventEntity>(currEventDTO);
                await _eventRepository.Delete(currEvent);
            }

            //Rabbit MQ to delete images
        }

        public async Task<IEnumerable<EventDTO>> GetAllEvent()
        {
            IEnumerable<EventEntity> rawEventsData = await _eventRepository.GetAll();
            List<EventDTO> allEventDTO = _mapper.Map<List<EventDTO>>(rawEventsData);

            return allEventDTO;
        }

        public async Task<IEnumerable<EventDTO>> GetAllGuestingEvent(MyPontsFilterDTO GuestingDTO)
        {
            UserEntity currUser = await _userRepository.GetByID(GuestingDTO.QueueId);
            return currUser.UserGuestEvents.ToList();
            
        }

        public Task<IEnumerable<EventDTO>> GetAllHsotingEvent(MyPontsFilterDTO HostingDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EventDTO>> GetSearchedEvents(SearchBaseDTO searchBaseDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<EventDTO> GetSingleEvent(int QueueId)
        {
            EventEntity currEvent = await _eventRepository.GetByID(QueueId);
            return _mapper.Map<EventDTO>(currEvent);
            
        }

        public async Task UpdateEvent(EventDTO currEventDTO)
        {
            EventEntity currEvent = _mapper.Map<EventEntity>(currEventDTO);
            await _eventRepository.Update(currEvent);
        }
    }
}
