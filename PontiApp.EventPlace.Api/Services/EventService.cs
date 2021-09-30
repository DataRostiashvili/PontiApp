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
        

        public EventService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _eventValidator = new EventDTOValidator(context);
            
            

        }

        public async Task AddEvent(EventDTO newEventDTO)
        {
            throw new NotImplementedException();

            //RabbitMQ I generate List<Keys> and pass to ImagesService List of keys and list bytes (Mayby dictionary)
        }

        public async Task DeleteEvent(EventDTO currEventDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EventDTO>> GetAllEvent()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EventDTO>> GetAllGuestingEvent(MyPontsFilterDTO GuestingDTO)
        {
            throw new NotImplementedException();
            
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
            throw new NotImplementedException();

        }

        public async Task UpdateEvent(EventDTO currEventDTO)
        {
            throw new NotImplementedException();
        }
    }
}
