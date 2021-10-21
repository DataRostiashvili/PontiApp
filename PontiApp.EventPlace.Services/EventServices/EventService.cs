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

        public async Task AddHostingEvent(EventHostRequestDTO newEventDTO)
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

        public async Task DeleteHostingEvent(int hostEventId)
        {
            EventEntity currEvent = await _eventRepo.GetByID(hostEventId);
            await _eventRepo.Delete(currEvent);
        }

        public async Task AddGusestingEvent(EventGuestRequestDTO currEventGuestDTO)
        { 
            await _eventRepo.InsertGuesting(currEventGuestDTO);
        }

        public async Task DeleteGuestingEvent(EventGuestRequestDTO currEventGuestDTO)
        {
            await _eventRepo.DeleteGuesting(currEventGuestDTO);
        }

        public async Task<List<EventHostResponseDTO>> GetAllEvent()
        {
            List<EventEntity> allEvent = await _eventRepo.GetAll();
            List<EventHostResponseDTO> allEventDTOs = _mapper.Map<List<EventHostResponseDTO>>(allEvent);


            return allEventDTOs;
        }

        public async Task<List<EventHostResponseDTO>> GetAllGuestingEvent(int userGuestId)
        {
            List<EventEntity> guestingEvents = await _eventRepo.GetAllGuesting(userGuestId);
            List<EventHostResponseDTO> guestingEventDTOs = _mapper.Map<List<EventHostResponseDTO>>(guestingEvents);

            return guestingEventDTOs;
        }

        public async Task<List<EventHostResponseDTO>> GetAllHsotingEvent(int userHostId)
        {
            List<EventEntity> hostingEvents = await _eventRepo.GetAllHosting(userHostId);
            List<EventHostResponseDTO> hostingEventDTOs = _mapper.Map<List<EventHostResponseDTO>>(hostingEvents);

            return hostingEventDTOs;
        }

        public Task<List<EventHostResponseDTO>> GetSearchedEvents(SearchBaseDTO searchBaseDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<EventHostResponseDTO> GetDetailedHostingEvent(int eventId)
        {
            EventEntity currEvent = await _eventRepo.GetByID(eventId);
            return _mapper.Map<EventHostResponseDTO>(currEvent);
        }

        public async Task<EventGuestResponseDTO> GetDetailedGuestingEvent(EventGuestRequestDTO eventGuest)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateGuestingEvent(EventReviewDTO eventReviewDTO)
        {
            await _eventRepo.UpdateGuestingEvent(eventReviewDTO);
        }

        public async Task UpdateHostingEvent(EventHostRequestDTO currEventDTO)
        {
            EventEntity currEvent = _mapper.Map<EventEntity>(currEventDTO);
            await _eventRepo.Update(currEvent);
        }
    }
}
;