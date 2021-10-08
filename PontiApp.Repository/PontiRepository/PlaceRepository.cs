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
    public class PlaceRepository : BaseRepository<PlaceEntity>
    {
        public PlaceRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }
        public async Task InsertHosting(PlaceEntity currPlace)
        {
            var currUser = await _applicationDbContext.Users
                .Include(u => u.UserHostPlaces)
                .SingleAsync(u => u.QueueId == currPlace.HostUser.QueueId);

            await Insert(currPlace);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteHosting(PlaceEntity currPlace)
        {
            await Delete(currPlace);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task InsertGuesting(PlaceEntity currPlace, int guestId)
        {
            var currUser = await _applicationDbContext.Users
                .Include(u => u.UserHostPlaces)
                .SingleAsync(u => u.QueueId == guestId);

            currUser.UserGuestPlaces.Add(currPlace);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteGuesting(PlaceEntity currPlace, int guestId)
        {
            var currUser = await _applicationDbContext.Users
               .Include(u => u.UserGuestPlaces)
               .SingleAsync(u => u.QueueId == guestId);

            currUser.UserGuestPlaces.Remove(currPlace);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<PlaceEntity>> GetAllGuesting(int userId)
        {
            var currUser = await _applicationDbContext.Users
                .Include(u => u.UserGuestPlaces)
                .SingleAsync(u => u.Id == userId);

            return currUser.UserGuestPlaces;
        }

        public async Task<IEnumerable<PlaceEntity>> GetAllHosting(int userId)
        {
            var currUser = await _applicationDbContext.Users
                .Include(u => u.UserGuestEvents)
                .SingleAsync(u => u.Id == userId);

            return currUser.UserHostPlaces;
        }

        public async Task UpdateGuestingPlace(PlaceEntity currPlace, PlaceGuestDTO currPlaceGuestDTO)
        {
            PlaceReviewEntity currReview = new()
            {
                ReviewRanking = currPlaceGuestDTO.ReviewRanking,
                PlaceEntity = currPlace,
                UserEntity = await _applicationDbContext.Users.SingleAsync(u => u.QueueId == currPlaceGuestDTO.UserGuestQueueId)
            };

            if (currPlace.Reviews.Contains(currReview))
            {
                currPlace.Reviews.Remove(currReview);
            }

            currPlace.Reviews.Add(currReview);
        }
    }
}
