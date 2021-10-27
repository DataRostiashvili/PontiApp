using AutoMapper;
using PontiApp.Models;
using PontiApp.Models.DTOs;
using PontiApp.Ponti.Repository.BaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PontiApp.EventEvent.Services.EventCategoryServices
{
    public class EventCategoryService : IEventCategoryService
    {
        private readonly BaseRepository<EventCategory> _eventCategoryRepository;
        private readonly IMapper _mapper;

        public EventCategoryService(BaseRepository<EventCategory> eventCategoryRepository, IMapper mapper)
        {
            _eventCategoryRepository = eventCategoryRepository;
            _mapper = mapper;
        }

        public async Task AddEventCategoryBond(List<EventCategoryDTO> EventCategoriesUpDTO)
        {
            List<EventCategory> EventCategoriesUp = _mapper.Map<List<EventCategory>>(EventCategoriesUpDTO);
            await _eventCategoryRepository.InsertRange(EventCategoriesUp);
        }

        public async Task DeleteEventCategoryBond(List<EventCategoryDTO> EventCategoriesDownDTO)
        {
            List<EventCategory> EventCategoriesDown = _mapper.Map<List<EventCategory>>(EventCategoriesDownDTO);
            await _eventCategoryRepository.DeleteRange(EventCategoriesDown);
        }
    }
}
