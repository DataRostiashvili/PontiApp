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

        public async Task AddHostingEvent(EventInsertDTO newEventDTO)
        {
            EventEntity newEvent = _mapper.Map<EventEntity>(newEventDTO);

            //newEvent.UserEntity.Id = await _eventRepo.NextId();
            //AddImagesInfo(ref newEvent, newEventDTO); //should be await

            await _eventRepo.InsertHosting(newEvent);
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

        public async Task<IEnumerable<EventDTO>> GetAllEvent()
        {
            IEnumerable<EventEntity> allEvent = await _eventRepo.GetAll();
            IEnumerable<EventDTO> allEventDTOs = _mapper.Map<IEnumerable<EventDTO>>(allEvent);


            return allEventDTOs;
        }

        public async Task<IEnumerable<EventDTO>> GetAllGuestingEvent(int userGuestId)
        {
            IEnumerable<EventEntity> guestingEvents = await _eventRepo.GetAllGuesting(userGuestId);
            IEnumerable<EventDTO> guestingEventDTOs = _mapper.Map<IEnumerable<EventDTO>>(guestingEvents);

            return guestingEventDTOs;
        }

        public async Task<IEnumerable<EventDTO>> GetAllHsotingEvent(int userHostId)
        {
            IEnumerable<EventEntity> hostingEvents = await _eventRepo.GetAllHosting(userHostId);
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

        public async Task UpdateGuestingEvent(GuestDTO currEventGuestDTO)
        {
            EventEntity currEvent = await _eventRepo.GetByID(currEventGuestDTO.EventId);
            await _eventRepo.UpdateGuestingEvent(currEvent, currEventGuestDTO);
        }

        public async Task UpdateHostingEvent(HostDTO currEventDTO)
        {
            EventEntity currEvent = await _eventRepo.GetByID(currEventDTO.UserHostId);
            await _eventRepo.Update(currEvent);
        }
    }
}
;