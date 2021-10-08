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

        public async Task AddGusestingPlace(GuestDTO currPlaceGuestDTO)
        {
            PlaceEntity currPlace = await _placeRepo.GetByID(currPlaceGuestDTO.PlaceQueueId);
            await _placeRepo.InsertGuesting(currPlace, currPlaceGuestDTO.UserGuestQueueId);
        }

        public async Task AddHostingPlace(PlaceDTO newPlaceDTO)
        {
            PlaceEntity newPlace = _mapper.Map<PlaceEntity>(newPlaceDTO);

            newPlace.HostUser.QueueId = await _placeRepo.NextQueueId();
            
            AddImagesInfo(ref newPlace, newPlaceDTO); //should be await

            await _placeRepo.InsertHosting(newPlace);
        }

        private void AddImagesInfo(ref PlaceEntity newPlace, PlaceDTO newPlaceDTO)
        {
            foreach (var p in newPlaceDTO.Pictures)
            {
                PlacePicEntity PlacePic = new()
                {
                    MongoKey = Guid.NewGuid().ToString()
                };

                newPlace.Pictures.Add(PlacePic);
                //awaitable Throw {bytes, guid} with rabbitMQ
            }
        }

        public async Task DeleteGuestingPlace(GuestDTO currPlaceGuestDTO)
        {
            PlaceEntity currPlace = await _placeRepo.GetByID(currPlaceGuestDTO.PlaceQueueId);
            await _placeRepo.DeleteGuesting(currPlace, currPlaceGuestDTO.UserGuestQueueId);
        }

        public async Task DeleteHostingPlace(HostDTO currPlaceHostDTO)
        {
            PlaceEntity currPlace = await _placeRepo.GetByID(currPlaceHostDTO.PlaceQueueId);
            await _placeRepo.DeleteHosting(currPlace);
        }

        public async Task<IEnumerable<PlaceDTO>> GetAllGuestingPlace(int userGuestQueueId)
        {
            IEnumerable<PlaceEntity> guestingPlaces = await _placeRepo.GetAllGuesting(userGuestQueueId);
            IEnumerable<PlaceDTO> guestingPlaceDTOs = _mapper.Map<IEnumerable<PlaceDTO>>(guestingPlaces);

            return guestingPlaceDTOs;
        }

        public async Task<IEnumerable<PlaceDTO>> GetAllHsotingPlace(int userHostQueueId)
        {
            IEnumerable<PlaceEntity> hostingPlaces = await _placeRepo.GetAllHosting(userHostQueueId);
            IEnumerable<PlaceDTO> hostingPlaceDTOs = _mapper.Map<IEnumerable<PlaceDTO>>(hostingPlaces);

            return hostingPlaceDTOs;
        }

        public async Task<IEnumerable<PlaceDTO>> GetAllPlace()
        {
            IEnumerable<PlaceEntity> allPlace = await _placeRepo.GetAll();
            IEnumerable<PlaceDTO> allPlaceDTOs = _mapper.Map<IEnumerable<PlaceDTO>>(allPlace);

            return allPlaceDTOs;
        }

        public Task<IEnumerable<PlaceDTO>> GetSearchedPlaces(SearchBaseDTO searchBaseDTO)
        {
            throw new NotImplementedException();
        }

        public async Task<PlaceDTO> GetSinglePlace(int PlaceId)
        {
            PlaceEntity currPlace = await _placeRepo.GetByID(PlaceId);
            return _mapper.Map<PlaceDTO>(currPlace);
        }

        public async Task UpdateGuestingPlace(GuestDTO currPlaceGuestDTO)
        {
            PlaceEntity currPlace = await _placeRepo.GetByID(currPlaceGuestDTO.PlaceQueueId);
            await _placeRepo.UpdateGuestingPlace(currPlace, currPlaceGuestDTO);
        }

        public async Task UpdateHostingPlace(HostDTO currPlaceDTO)
        {
            PlaceEntity currPlace = await _placeRepo.GetByID(currPlaceDTO.UserHostQueueId);
            await _placeRepo.Update(currPlace);
        }
    }
}
