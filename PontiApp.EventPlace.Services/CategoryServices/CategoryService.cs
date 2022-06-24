using AutoMapper;
using PontiApp.Exceptions;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using PontiApp.Models.Request;
using PontiApp.Models.Response;
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
        public async Task Add(CategoryRequest newCategory)
        {
             var newCategoryEntity = _mapper.Map<CategoryEntity>(newCategory);
            await _categoryRepository.Insert(newCategoryEntity);
        }

        public async Task Delete(CategoryRequest category)
        {
            var entity = GetEntity(category);
            if (entity == null)
                throw new DoesNotExistsException();
            await _categoryRepository.Delete(entity);
        }

      

        public async Task<List<CategoryResponse>> GetAll()
        {
            var allCategory = await _categoryRepository.GetAll();

            if (allCategory.Count == 0 || allCategory == null)
                throw new DoesNotExistsException();

            var allCategoryDTOs = _mapper.Map<List<CategoryEntity>, List<CategoryResponse>>(allCategory);

            return allCategoryDTOs;
        }


        #region private methods

        private CategoryEntity GetEntity(CategoryRequest category)
        {
            return _categoryRepository.GetByPredicate(cat => cat.Category == category.Category).FirstOrDefault();
        }

        #endregion  
    }
}
