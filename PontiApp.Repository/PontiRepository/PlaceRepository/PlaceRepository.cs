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
            if (currPlace == null)
                throw new DoesNotExistsException("Such Place Does Not Exists!");
            UserEntity currUser = await _applicationDbContext.Users.SingleAsync(u => u.Id == currPlaceGuestDTO.UserGuestId);
            if (currUser == null)
                throw new DoesNotExistsException("Such User Does Not Exists!");

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
            var allGuests = await _applicationDbContext.UserGuestPlaces.Where(ug => ug.UserEntityId == currUser.Id).Select(e => e.PlaceEntity).ToListAsync();

            return allGuests;
        }

        public async Task<List<PlaceEntity>> GetAllHosting(int userId)
        {
            var currUser = await _applicationDbContext.Users.Include(u => u.UserHostPlaces).SingleAsync(u => u.Id == userId);

            return currUser.UserHostPlaces;
        }

        public async Task UpdateGuestingPlace(PlaceReviewDTO placeReviewDTO)
        {
            PlaceEntity currPlace = await entities.Include(p => p.Reviews).SingleAsync(p => p.Id == placeReviewDTO.PlaceEntityId);
            if (currPlace == null)
                throw new DoesNotExistsException();

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

        public async Task<List<PlaceEntity>> GetPlaceSearchResult(SearchFilter searchBaseDTO)
        {
            //prepare input
            var rawCategories = searchBaseDTO.Categories.Select(cat=> cat.Category).ToList();
            var categoryEntities = _applicationDbContext.Categories.Where(cat => rawCategories.Contains(cat.Category))
                .AsEnumerable();

            var searchForEveryTitle = String.IsNullOrWhiteSpace(searchBaseDTO.SearchKeyWord);
            var searchForEveryCategory = searchBaseDTO.Categories.Count < 1;

            var places = (await (from place in _applicationDbContext.Places
                                 where searchForEveryTitle ? true : place.Name.Contains(searchBaseDTO.SearchKeyWord)
                                 let searchCategoryIds = categoryEntities.Select(searchCat => searchCat.Id)
                                 let testCategories= _applicationDbContext.Places
                                 .Select(s=>s.PlaceCategories
                                    .Where(pc=>searchCategoryIds.Contains(pc.CategoryEntityId))).AsEnumerable()                                
                                 select place).ToListAsync()).Where(place => IsWorkingInTimeRange(place.WeekSchedule, searchBaseDTO.Time));

            if (places.Count() == 0 || places == null)
                throw new DoesNotExistsException();

            return places.ToList();
        }

        //private bool PlaceHasCategories(IEnumerable<int> placeCategoryIds, IEnumerable<int> searchPlaceCategoryIds)
        //{
        //    return !searchPlaceCategoryIds.Except(placeCategoryIds).Any();
        //}

        private bool IsWorkingInTimeRange(List<WeekEntity> weekScheduleList, TimeFilterEnum searchedPlaceTime)
        {
            var currentDate = DateTime.Now;
            //var searchedDate = GetWorkingDays(searchedPlaceTime);

            //if (searchedDate == DateTime.MaxValue)
            //    searchedDate = DateTime.Today.AddDays(7);

            if (searchedPlaceTime == TimeFilterEnum.today)
                return weekScheduleList[(int)currentDate.DayOfWeek].IsWorking;
            else if(searchedPlaceTime == TimeFilterEnum.tomorrow)
                return weekScheduleList[(int)currentDate.AddDays(1).DayOfWeek].IsWorking;
            else
            {
                var searchedDate = DateTime.Today.AddDays(7);
                while (currentDate < searchedDate)
                {
                    if (!weekScheduleList[(int)currentDate.DayOfWeek].IsWorking)
                    {
                        return false;
                    }
                    currentDate = currentDate.AddDays(1);
                }
            }

            return true;
        }

        //private DateTime GetWorkingDays(TimeFilterEnum searchedPlaceTime)
        //{
        //    DateTime workingDays;
        //    switch (searchedPlaceTime)
        //    {
        //        case TimeFilterEnum.today:
        //            workingDays = DateTime.Today;
        //            break;
        //        case TimeFilterEnum.tomorrow:
        //            workingDays = DateTime.Today.AddDays(1);
        //            break;
        //        case TimeFilterEnum.currentWeek:
        //            workingDays = DateTime.Today.AddDays(7);
        //            break;
        //        case TimeFilterEnum.upcomming:
        //            workingDays = DateTime.MaxValue;
        //            break;
        //        default:
        //            workingDays = DateTime.MaxValue;
        //            break;
        //    }
        //    return workingDays;
        //}
    }
}
