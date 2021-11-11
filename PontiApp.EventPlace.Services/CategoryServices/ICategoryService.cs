using PontiApp.Models.DTOs;
using PontiApp.Models.Request;
using PontiApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task Add(CategoryRequest newCategoryDTO);
        Task Delete(CategoryRequest currCategoryDTO);
        Task<List<CategoryResponse>> GetAll();

    }
}
