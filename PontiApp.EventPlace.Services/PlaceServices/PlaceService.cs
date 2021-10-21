using AutoMapper;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.PlacePlace.Services.PlaceServices;
using PontiApp.Ponti.Repository.PontiRepository;
using PontiApp.Validators.EntityValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.PlacePlace.Services.PlaceServices
{
    public class PlaceService : IPlaceService
    {

        private readonly IMapper _mapper;
        private readonly PlaceDTOValidator _validator;
        private readonly PlaceRepository _placeRepo;

        public PlaceService(IMapper mapper, PlaceDTOValidator validator, PlaceRepository placeRepo)
        {
            _mapper = mapper;
            _validator = validator;
            _placeRepo = placeRepo;
        }

        public async Task AddGusestingPlace(PlaceGuestRequestDTO currPlaceGuestDTO)
        {
            await _placeRepo.InsertGuesting(currPlaceGuestDTO);
        }

        public async Task AddHostingPlace(PlaceHostRequestDTO newPlaceDTO)
        {
            PlaceEntity newPlace = _mapper.Map<PlaceEntity>(newPlaceDTO);
            await _placeRepo.Insert(newPlace);
        }

        //private void AddImagesInfo(ref PlaceEntity newPlace, PlaceDTO newPlaceDTO)
        //{
        //    foreach (var p in newPlaceDTO.Pictures)
        //    {
        //        PlacePicEntity PlacePic = new()
        //        {
        //            MongoKey = Guid.NewGuid().ToString()
        //        };

        //        newPlace.Pictures.Add(PlacePic);
        //        //awaitable Throw {bytes, guid} with rabbitMQ
        //    }
        //}

        public async Task DeleteGuestingPlace(PlaceGuestRequestDTO currPlaceGuestDTO)
        {
            await _placeRepo.DeleteGuesting(currPlaceGuestDTO);
        }

        public async Task DeleteHostingPlace(int hostPlaceId)
        {
            PlaceEntity currPlace = await _placeRepo.GetByID(hostPlaceId);
            await _placeRepo.Delete(currPlace);
        }

        public async Task<List<PlaceHostResponseDTO>> GetAllGuestingPlace(int userGuestId)
        {
            List<PlaceEntity> guestingPlaces = await _placeRepo.GetAllGuesting(userGuestId);
            List<PlaceHostResponseDTO> guestingPlaceDTOs = _mapper.Map<List<PlaceHostResponseDTO>>(guestingPlaces);

            return guestingPlaceDTOs;
        }

        public async Task<List<PlaceHostResponseDTO>> GetAllHsotingPlace(int userHostId)
        {
            List<PlaceEntity> hostingPlaces = await _placeRepo.GetAllHosting(userHostId);
            List<PlaceHostResponseDTO> hostingPlaceDTOs = _mapper.Map<List<PlaceHostResponseDTO>>(hostingPlaces);

            return hostingPlaceDTOs;
        }

        public async Task<List<PlaceHostResponseDTO>> GetAllPlace()
        {
            List<PlaceEntity> allPlace = await _placeRepo.GetAll();
            List<PlaceHostResponseDTO> allPlaceDTOs = _mapper.Map<List<PlaceHostResponseDTO>>(allPlace);

            return allPlaceDTOs;
        }

        public Task<List<PlaceHostResponseDTO>> GetSearchedPlaces(SearchBaseDTO searchBaseDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<PlaceHostResponseDTO> GetDetailedHostingPlace(int placeId)
        {
            PlaceEntity currPlace = await _placeRepo.GetByID(placeId);
            return _mapper.Map<PlaceHostResponseDTO>(currPlace);
        }

        
        public async Task<PlaceGuestResponseDTO> GetDetailedGuestingPlace(PlaceGuestRequestDTO placeGuest)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateGuestingPlace(PlaceReviewDTO placeReviewDTO)
        {
            await _placeRepo.UpdateGuestingPlace(placeReviewDTO);
        }

        public async Task UpdateHostingPlace(PlaceHostRequestDTO currPlaceDTO)
        {
            PlaceEntity currPlace =  _mapper.Map<PlaceEntity>(currPlaceDTO);
            await _placeRepo.Update(currPlace);
        }
    }
}
