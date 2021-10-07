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

        public async Task AddGusestingPlace(PlaceGuestDTO currPlaceGuestDTO)
        {
            PlaceEntity currPlace = await _placeRepo.GetByID(currPlaceGuestDTO.PlaceQueueId);
            await _placeRepo.InsertGuesting(currPlace, currPlaceGuestDTO.UserHostQueueId);
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

        public async Task DeleteGuestingPlace(PlaceGuestDTO currPlaceGuestDTO)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteHostingPlace(HostDTO currPlaceHostDTO)
        {
            PlaceEntity currEvent = await _placeRepo.GetByID(currPlaceHostDTO.UserHostQueueId);
            await _placeRepo.DeleteHosting(currEvent);
        }

        public Task<IEnumerable<PlaceDTO>> GetAllGuestingPlace(MyPontsFilterDTO GuestingDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlaceDTO>> GetAllHsotingPlace(MyPontsFilterDTO HostingDTO)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlaceDTO>> GetAllPlace()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<PlaceDTO>> GetSearchedPlaces(SearchBaseDTO searchBaseDTO)
        {
            throw new NotImplementedException();
        }

        public Task<PlaceDTO> GetSinglePlace(int PlaceId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGuestingPlace(PlaceGuestDTO currPlaceGuestDRO)
        {
            throw new NotImplementedException();
        }

        public Task UpdateHostingPlace(HostDTO currPlaceHostDTO)
        {
            throw new NotImplementedException();
        }
    }
}
