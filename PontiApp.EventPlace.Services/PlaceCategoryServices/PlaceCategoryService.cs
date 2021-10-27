using AutoMapper;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Ponti.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.PlaceCategoryServices
{
    public class PlaceCategoryService : IPlaceCategoryService
    {
        private readonly BaseRepository<PlaceCategory> _placeCategoryRepository;
        private readonly IMapper _mapper;

        public PlaceCategoryService(BaseRepository<PlaceCategory> placeCategoryRepository, IMapper mapper)
        {
            _placeCategoryRepository = placeCategoryRepository;
            _mapper = mapper;
        }

        public async Task AddPlaceCategoryBond(List<PlaceCategoryDTO> placeCategoriesUpDTO)
        {
            List<PlaceCategory> placeCategoriesUp = _mapper.Map<List<PlaceCategory>>(placeCategoriesUpDTO);
            await _placeCategoryRepository.InsertRange(placeCategoriesUp);
        }

        public async Task DeletePlaceCategoryBond(List<PlaceCategoryDTO> placeCategoriesDownDTO)
        {
            List<PlaceCategory> placeCategoriesDown = _mapper.Map<List<PlaceCategory>>(placeCategoriesDownDTO);
            await _placeCategoryRepository.DeleteRange(placeCategoriesDown);
        }
    }
}
