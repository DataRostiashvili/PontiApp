using Microsoft.EntityFrameworkCore;
using PontiApp.Data.DbContexts;
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
            await Insert(currEvent);

            var currUser = await _applicationDbContext.Users
                .Include(u => u.UserHostEvents)
                .SingleAsync(u => u.QueueId == currEvent.HostUser.QueueId);

            var currPlace = await _applicationDbContext.Places
                .Include(p => p.PlaceEvents)
                .SingleAsync(p => p.QueueId == currEvent.PlaceEntity.QueueId);


            currUser.UserHostEvents.Add(currEvent);
            currPlace.PlaceEvents.Add(currEvent);

            await _applicationDbContext.SaveChangesAsync();
        }



        public async Task DeleteHosting(EventEntity currEvent)
        {
            var currUser = await _applicationDbContext.Users
                .Include(u => u.UserHostEvents)
                .SingleAsync(u => u.QueueId == currEvent.HostUser.QueueId);

            currUser.UserHostEvents.Remove(currEvent);

            await Delete(currEvent);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task InsertGuesting(EventEntity currEvent, int guestId)
        {

            var currUser = await _applicationDbContext.Users
                .Include(u => u.UserGuestEvents)
                .SingleAsync(u => u.QueueId == guestId);

            currUser.UserGuestEvents.Add(currEvent);
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

        public async Task<int> NextEventQueueId()
        {
            return await _applicationDbContext.Events.MaxAsync(e => e.QueueId) + 1;
        }
    }
}
