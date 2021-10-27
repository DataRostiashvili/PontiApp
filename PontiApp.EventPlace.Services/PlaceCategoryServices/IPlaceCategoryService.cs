using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.EventPlace.Services.PlaceCategoryServices
{
    public interface IPlaceCategoryService
    {
        Task AddPlaceCategoryBond(List<PlaceCategoryDTO> placeCategoriesUpDTO);
        Task DeletePlaceCategoryBond(List<PlaceCategoryDTO> placeCategoriesDownDTO);
    }
}
