using Microsoft.EntityFrameworkCore;
using PontiApp.Data.DbContexts;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Ponti.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Ponti.Repository.PontiRepository
{
    public class EventRepository : BaseRepository<EventEntity>
    {
        public EventRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public async Task InsertHosting(EventEntity currEvent)
        {
            currEvent.UserEntity = await _applicationDbContext.Users
                .SingleAsync(u => u.QueueId == currEvent.UserEntity.QueueId);

            currEvent.PlaceEntity = await _applicationDbContext.Places
                .SingleAsync(p => p.QueueId == currEvent.PlaceEntity.QueueId);

            await Insert(currEvent);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteHosting(EventEntity currEvent)
        {
            await Delete(currEvent);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task InsertGuesting(EventEntity currEvent, int guestId)
        {
            var currUser = await _applicationDbContext.Users
                .SingleAsync(u => u.QueueId == guestId);

            currEvent.UserGuest.Add(currUser);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteGuesting(EventEntity currEvent, int guestId)
        {
            var currUser = await _applicationDbContext.Users
                .Include(u => u.UserGuestEvents)
                .SingleAsync(u => u.QueueId == guestId);

            currUser.UserGuestEvents.Remove(currEvent);

            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<EventEntity>> GetAllGuesting(int userId)
        {
            var currUser = await _applicationDbContext.Users
                .Include(u => u.UserGuestEvents)
                .SingleAsync(u => u.Id == userId);

            return currUser.UserGuestEvents;
        }

        public async Task<IEnumerable<EventEntity>> GetAllHosting(int userId)
        {
            var currUser = await _applicationDbContext.Users
                .Include(u => u.UserGuestEvents)
                .SingleAsync(u => u.Id == userId);

            return currUser.UserHostEvents;
        }

        public async Task UpdateGuestingEvent(EventEntity currEvent, GuestDTO currEventGuestDTO)
        {
            

            EventReviewEntity currReview = new()
            {
                ReviewRanking = currEventGuestDTO.ReviewRanking,
                EventEntity = currEvent,
                UserEntity = await _applicationDbContext.Users.SingleAsync(u => u.QueueId == currEventGuestDTO.UserGuestQueueId)
            };

            if (currEvent.Reviews.Contains(currReview))
            {
                currEvent.Reviews.Remove(currReview);
            }

            currEvent.Reviews.Add(currReview);
        }
    }
}
