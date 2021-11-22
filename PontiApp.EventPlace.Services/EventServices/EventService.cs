using AutoMapper;
using PontiApp.Data.DbContexts;
using PontiApp.EventEvent.Services.EventCategoryServices;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Models.Response;
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
        private readonly IEventCategoryService _eventCategoryService;

        public EventService(IMapper mapper, EventDTOValidator validator, EventRepository eventRepo, IEventCategoryService eventCategoryService)
        {
            _mapper = mapper;
            _validator = validator;
            _eventRepo = eventRepo;
            _eventCategoryService = eventCategoryService;
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

        public async Task<List<EventBriefResponse>> GetAllEvent()
        {
            var allEvent = await _eventRepo.GetAllEvent();
            var allEventDTOs = _mapper.Map<List<EventBriefResponse>>(allEvent);

            return allEventDTOs;
        }

        public async Task<List<EventListingResponseDTO>> GetAllGuestingEvent(int userGuestId)
        {
            List<EventEntity> guestingEvents = await _eventRepo.GetAllGuesting(userGuestId);
            List<EventListingResponseDTO> guestingEventDTOs = _mapper.Map<List<EventListingResponseDTO>>(guestingEvents);

            return guestingEventDTOs;
        }

        public async Task<List<EventBriefResponse>> GetAllHsotingEvent(long hostFbId)
        {
            var hostingEvents = await _eventRepo.GetAllHosting(hostFbId);
            var hostingEventDTOs = _mapper.Map<List<EventBriefResponse>>(hostingEvents);

            return hostingEventDTOs;
        }

        public async Task<List<EventListingResponseDTO>> GetSearchedEvents(SearchFilter searchBaseDTO)
        {
            var searchResult = await _eventRepo.GetEventSearchResult(searchBaseDTO);
            var searchResultDto = _mapper.Map<List<EventListingResponseDTO>>(searchResult);
            return searchResultDto;
        }

        public async Task<EventHostResponseDTO> GetDetailedHostingEvent(int eventId)
        {
            EventEntity currEvent = await _eventRepo.GetByID(eventId);
            return _mapper.Map<EventHostResponseDTO>(currEvent);
        }
        public async Task<EventDetailedResponse> GetDetailedEvent(int eventId)
        {
            var @event = await _eventRepo.GetByID(eventId);
            return _mapper.Map<EventDetailedResponse>(@event);
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