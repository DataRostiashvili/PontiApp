using Microsoft.EntityFrameworkCore;
using PontiApp.Data.DbContexts;
using PontiApp.Exceptions;
using PontiApp.Models.DTOs;
using PontiApp.Models.DTOs.Enums;
using PontiApp.Models.Entities;
using PontiApp.Ponti.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace PontiApp.Ponti.Repository.PontiRepository.EventRepository
{
    public class EventRepository : BaseRepository<EventEntity>
    {
        public EventRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public async Task InsertGuesting(EventGuestRequestDTO currEventGuestDTO)
        {

            EventEntity currEvent = await GetByID(currEventGuestDTO.EventId);
            UserEntity currUser = await _applicationDbContext.Users.SingleAsync(u => u.Id == currEventGuestDTO.UserGuestId);

            UserGuestEvent guestOnEvent = new UserGuestEvent()
            {
                EventEntity = currEvent,
                UserEntity = currUser
            };

            _applicationDbContext.UserGuestEvents.Add(guestOnEvent);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteGuesting(EventGuestRequestDTO currEventGuestDTO)
        {
            EventEntity currEvent = await GetByID(currEventGuestDTO.EventId);
            UserEntity currUser = await _applicationDbContext.Users.SingleAsync(u => u.Id == currEventGuestDTO.UserGuestId);

            UserGuestEvent currBond = await _applicationDbContext.UserGuestEvents.Where(o => o.EventEntityId == currEvent.Id && o.UserEntityId == currUser.Id).FirstAsync();

            _applicationDbContext.UserGuestEvents.Remove(currBond);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<EventEntity>> GetAllGuesting(int userId)
        {
            UserEntity currUser = await _applicationDbContext.Users.SingleAsync(u => u.Id == userId);

            return await _applicationDbContext.UserGuestEvents.Where(ug => ug.UserEntityId == currUser.Id).Select(e => e.EventEntity).ToListAsync();
        }

        public async Task<List<EventEntity>> GetAllHosting(long hostFbId)
        {
            var currUser = await _applicationDbContext.Users.Include(u => u.UserHostEvents).SingleAsync(u => u.FbKey == hostFbId);

            return currUser.UserHostEvents;
        }

        public async Task UpdateGuestingEvent(EventReviewDTO eventReviewDTO)
        {
            EventEntity currEvent = await entities.Include(p => p.Reviews).SingleAsync(p => p.Id == eventReviewDTO.EventEntityId);
            EventReviewEntity currReview = new()
            {
                ReviewRanking = eventReviewDTO.ReviewRanking,
                EventEntity = currEvent,
                EventEntityId = eventReviewDTO.EventEntityId,
                //UserEntityId = eventReviewDTO.UserEntityId,
                //UserEntity = await _applicationDbContext.Users.SingleAsync(u => u.Id == eventReviewDTO.UserEntityId)
            };

            if (currEvent.Reviews.Contains(currReview))
            {
                currEvent.Reviews.Remove(currReview);
            }

            currEvent.Reviews.Add(currReview);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<EventEntity>> GetEventSearchResult(SearchFilter searchBaseDTO)
        {
            //prepare input
            var rawCategories = searchBaseDTO.Categories.Select(cat => cat.Category).ToList();
            var categoryEntities = _applicationDbContext.Categories.Where(cat => rawCategories.Contains(cat.Category))
                .AsEnumerable();


            var searchForEveryTitle = String.IsNullOrWhiteSpace(searchBaseDTO.SearchKeyWord);
            var searchForEveryCategory = searchBaseDTO.Categories.Count < 1;

            var events = await (from @event in _applicationDbContext.Events
                                where searchForEveryTitle ? true : @event.Name.Contains(searchBaseDTO.SearchKeyWord)
                                let searchCategoryIds = categoryEntities.Select(searchCat => searchCat.Id)
                                let testCategories = _applicationDbContext.Events
                                .Select(e => e.EventCategories 
                                        .Where(ct => searchCategoryIds.Contains(ct.CategoryEntityId))).AsEnumerable()
                                where @event.EndTime < GetDeadline(searchBaseDTO.Time)
                                select @event).ToListAsync();

            return events;
        }

        private bool EventHasCategories(IEnumerable<int> eventCategoryIds, IEnumerable<int> searchEventCategoryIds)
        {
            return !searchEventCategoryIds.Except(eventCategoryIds).Any();
        }

        private DateTime GetDeadline(TimeFilterEnum searchedEventTime)
        {
            DateTime deadline;
            switch (searchedEventTime)
            {
                case TimeFilterEnum.today:
                    deadline = DateTime.Today.AddDays(1);
                    break;
                case TimeFilterEnum.tomorrow:
                    deadline = DateTime.Today.AddDays(2);
                    break;
                case TimeFilterEnum.currentWeek:
                    deadline = DateTime.Today.AddDays(7);
                    break;
                case TimeFilterEnum.upcomming:
                    deadline = DateTime.MaxValue;
                    break;
                default:
                    deadline = DateTime.MaxValue;
                    break;
            }
            return deadline;
        }

        public async Task<IEnumerable<EventEntity>> GetAllEvent()
        {
            return await _applicationDbContext.Events.Include(e => e.UserEntity).ToListAsync();
        }
        public async Task<EventEntity> GetDetailedEventAsync(int eventId)
        {
            var query =  _applicationDbContext.Events.Include(e => e.PlaceEntity).Include(e => e.UserEntity).Include(e => e.Reviews).Include(e => e.Pictures);
            return await _applicationDbContext.Events
                .Include(e=>e.PlaceEntity)
                .Include(e => e.UserEntity)
                .Include(e=>e.Reviews)
                .Include(e=>e.Pictures)
                .SingleAsync(e => e.Id == eventId);
        }
    }
}
