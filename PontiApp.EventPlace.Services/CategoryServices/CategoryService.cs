using AutoMapper;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Ponti.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly BaseRepository<CategoryEntity> _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(IMapper mapper, BaseRepository<CategoryEntity> categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public async Task Add(CategoryDTO newCategoryDTO)
        {
            CategoryEntity newCategory = _mapper.Map<CategoryEntity>(newCategoryDTO);
            await _categoryRepository.Insert(newCategory);

            var newCategoryEntity = _mapper.Map<CategoryEntity>(newCategory);
            await _categoryRepository.Insert(new CategoryEntity { Category = newCategory.Category });
        }

        public async Task Delete(CategoryDTO currCategoryDTO)
        {
            CategoryEntity currCategory = _mapper.Map<CategoryEntity>(currCategoryDTO);
            await _categoryRepository.Delete(currCategory);
        }

        public async Task<List<CategoryDTO>> GetAll()
        {
            List<CategoryEntity> allCategory = await _categoryRepository.GetAll();
            List<CategoryDTO> allCategoryDTOs = _mapper.Map<List<CategoryEntity>, List<CategoryDTO>>(allCategory);

            return allCategoryDTOs;
        }
    }
}
