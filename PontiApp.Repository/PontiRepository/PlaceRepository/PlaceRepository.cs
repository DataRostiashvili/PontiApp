using Microsoft.EntityFrameworkCore;
using PontiApp.Data.DbContexts;
using PontiApp.Models.DTOs;
using PontiApp.Models.DTOs.Enums;
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
        
        public async Task InsertGuesting(PlaceGuestRequestDTO currPlaceGuestDTO)
        {
            PlaceEntity currPlace = await GetByID(currPlaceGuestDTO.PlaceId);
            UserEntity currUser = await _applicationDbContext.Users.SingleAsync(u => u.Id == currPlaceGuestDTO.UserGuestId);

            UserGuestPlace guestOnPlace = new UserGuestPlace()
            {
                PlaceEntity = currPlace,
                UserEntity = currUser
            };

            _applicationDbContext.UserGuestPlaces.Add(guestOnPlace);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteGuesting(PlaceGuestRequestDTO currPlaceGuestDTO)
        {
            PlaceEntity currPlace = await GetByID(currPlaceGuestDTO.PlaceId);
            UserEntity currUser = await _applicationDbContext.Users.SingleAsync(u => u.Id == currPlace.UserEntityId);

            UserGuestPlace currBond = await _applicationDbContext.UserGuestPlaces.Where(o => o.PlaceEntityId == currPlace.Id && o.UserEntityId == currUser.Id).FirstAsync();
            
            _applicationDbContext.UserGuestPlaces.Remove(currBond);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<PlaceEntity>> GetAllGuesting(int userId)
        {
            UserEntity currUser = await _applicationDbContext.Users.SingleAsync(u => u.Id == userId);

            return await _applicationDbContext.UserGuestPlaces.Where(ug => ug.UserEntityId == currUser.Id).Select(e => e.PlaceEntity).ToListAsync();
        }

        public async Task<List<PlaceEntity>> GetAllHosting(int userId)
        {
            var currUser = await _applicationDbContext.Users.Include(u => u.UserHostPlaces).SingleAsync(u => u.Id == userId);

            return currUser.UserHostPlaces;
        }

        public async Task UpdateGuestingPlace(PlaceReviewDTO placeReviewDTO)
        {
            PlaceEntity currPlace = await entities.Include(p => p.Reviews).SingleAsync(p => p.Id == placeReviewDTO.PlaceEntityId);
            PlaceReviewEntity currReview = new()
            {
                ReviewRanking = placeReviewDTO.ReviewRanking,
                PlaceEntity = currPlace,
                PlaceEntityId = placeReviewDTO.PlaceEntityId,
                UserEntityId = placeReviewDTO.UserEntityId,
                UserEntity = await _applicationDbContext.Users.SingleAsync(u => u.Id == placeReviewDTO.UserEntityId)
            };

            if (currPlace.Reviews.Contains(currReview))
            {
                currPlace.Reviews.Remove(currReview);
            }

            currPlace.Reviews.Add(currReview);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<List<PlaceListingResponseDTO>> GetPlaceSearchResult(SearchBaseDTO searchBaseDTO)
        {
            var searchForEveryTitle = String.IsNullOrWhiteSpace(searchBaseDTO.SearchKeyWord);
            var searchForEveryCategory = searchBaseDTO.Categories.Count < 1;


            var places = (await (from place in _applicationDbContext.Places
                                where searchForEveryTitle ? true : place.Name.Contains(searchBaseDTO.SearchKeyWord)
                                where searchForEveryCategory ? true : PlaceHasCategories(place.PlaceCategories.Select(category => category.Id), searchBaseDTO.Categories.Select(category => category.Id)) 
                                select place).ToListAsync()).Where(place => IsWorkingInTimeRange(place.WeekSchedule, searchBaseDTO.Time));

            return new List<PlaceListingResponseDTO>();
        }

        private bool PlaceHasCategories(IEnumerable<int> placeCategoryIds, IEnumerable<int> searchPlaceCategoryIds)
        {
            return !searchPlaceCategoryIds.Except(placeCategoryIds).Any();
        }

        private bool IsWorkingInTimeRange(List<WeekEntity> weekScheduleList, TimeFilterEnum searchedPlaceTime)
        {
            var currentDate = DateTime.Now;
            var searchedDate = GetWorkingDays(searchedPlaceTime);

            if (searchedDate == DateTime.MaxValue)
                searchedDate = DateTime.Today.AddDays(7);

            while (currentDate < searchedDate)
            {
                if (!weekScheduleList[(int)currentDate.DayOfWeek].IsWorking)
                {
                    return false;
                }
                currentDate = currentDate.AddDays(1);
            }

            return true;
        }

        private DateTime GetWorkingDays(TimeFilterEnum searchedPlaceTime)
        {
            DateTime workingDays;
            switch (searchedPlaceTime)
            {
                case TimeFilterEnum.today:
                    workingDays = DateTime.Today;
                    break;
                case TimeFilterEnum.tomorrow:
                    workingDays = DateTime.Today.AddDays(1);
                    break;
                case TimeFilterEnum.currentWeek:
                    workingDays = DateTime.Today.AddDays(7);
                    break;
                case TimeFilterEnum.upcomming:
                    workingDays = DateTime.MaxValue;
                    break;
                default:
                    workingDays = DateTime.MaxValue;
                    break;
            }
            return workingDays;
        }
    }
}
