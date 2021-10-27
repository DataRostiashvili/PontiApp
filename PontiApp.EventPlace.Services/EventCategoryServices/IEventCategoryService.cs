using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.EventEvent.Services.EventCategoryServices
{
    public interface IEventCategoryService
    {
        Task AddEventCategoryBond(List<EventCategoryDTO> eventCategoriesUpDTO);
        Task DeleteEventCategoryBond(List<EventCategoryDTO> eventCategoriesDownDTO);
    }
}
