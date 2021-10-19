using AutoMapper;
using PontiApp.Data.DbContexts;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Ponti.Repository.PontiRepository;
using PontiApp.Ponti.Repository.PontiRepository.EventRepository;
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

        public async Task AddHostingEvent(EventRequestDTO newEventDTO)
        {
            EventEntity newEvent = _mapper.Map<EventEntity>(newEventDTO);
            await _eventRepo.Insert(newEvent);
        }

        //private void AddImagesInfo(ref EventEntity newEvent, EventDTO newEventDTO)
        //{
        //    foreach (var p in newEventDTO.Pictures)
        //    {
        //        EventPicEntity eventPic = new()
        //        {
        //            MongoKey = Guid.NewGuid().ToString()
        //        };

        //        newEvent.Pictures.Add(eventPic);
        //        //awaitable Throw {bytes, guid} with rabbitMQ
        //    }
        //}

        public async Task DeleteHostingEvent(HostDTO currEventHostDTO)
        {
            EventEntity currEvent = await _eventRepo.GetByID(currEventHostDTO.EventId);
            await _eventRepo.DeleteHosting(currEvent);
        }

        public async Task AddGusestingEvent(GuestDTO currEventGuestDTO)
        {
            EventEntity currEvent = await _eventRepo.GetByID(currEventGuestDTO.EventId);
            await _eventRepo.InsertGuesting(currEvent, currEventGuestDTO.UserGuestId);
        }

        public async Task DeleteGuestingEvent(GuestDTO currEventGuestDTO)
        {
            EventEntity currEvent = await _eventRepo.GetByID(currEventGuestDTO.EventId);
            await _eventRepo.DeleteGuesting(currEvent, currEventGuestDTO.UserGuestId);
        }

        public async Task<List<EventResponseDTO>> GetAllEvent()
        {
            List<EventEntity> allEvent = await _eventRepo.GetAll();
            List<EventResponseDTO> allEventDTOs = _mapper.Map<List<EventResponseDTO>>(allEvent);


            return allEventDTOs;
        }

        public async Task<List<EventResponseDTO>> GetAllGuestingEvent(int userGuestId)
        {
            List<EventEntity> guestingEvents = await _eventRepo.GetAllGuesting(userGuestId);
            List<EventResponseDTO> guestingEventDTOs = _mapper.Map<List<EventResponseDTO>>(guestingEvents);

            return guestingEventDTOs;
        }

        public async Task<List<EventResponseDTO>> GetAllHsotingEvent(int userHostId)
        {
            List<EventEntity> hostingEvents = await _eventRepo.GetAllHosting(userHostId);
            List<EventResponseDTO> hostingEventDTOs = _mapper.Map<List<EventResponseDTO>>(hostingEvents);

            return hostingEventDTOs;
        }

        public Task<List<EventResponseDTO>> GetSearchedEvents(SearchBaseDTO searchBaseDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<EventResponseDTO> GetSingleEvent(int eventId)
        {
            EventEntity currEvent = await _eventRepo.GetByID(eventId);
            return _mapper.Map<EventResponseDTO>(currEvent);
        }

        public async Task UpdateGuestingEvent(GuestDTO currEventGuestDTO)
        {
            await _eventRepo.UpdateGuestingEvent(currEventGuestDTO);
        }

        public async Task UpdateHostingEvent(EventRequestDTO currEventDTO)
        {
            EventEntity currEvent = _mapper.Map<EventEntity>(currEventDTO);
            await _eventRepo.Update(currEvent);
        }
    }
}
;