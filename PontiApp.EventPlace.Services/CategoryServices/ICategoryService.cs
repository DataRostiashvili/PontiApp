using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task Add(CategoryDTO newCategoryDTO);
        Task Delete(CategoryDTO currCategoryDTO);
        Task<List<CategoryDTO>> GetAll();

    }
}
