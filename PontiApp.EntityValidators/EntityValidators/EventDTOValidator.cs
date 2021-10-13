using Microsoft.EntityFrameworkCore;
using PontiApp.Data.DbContexts;
using PontiApp.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Validators.EntityValidators
{
    public class EventDTOValidator
    {
        private readonly ApplicationDbContext _context;

        public EventDTOValidator(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Exists(EventDTO eventDTO) {
            if (eventDTO != null && _context.Users.Any(u => u.Id == eventDTO.Id))
            {
                return _context.Events.Any(ev => ev.Id == eventDTO.Id);
            }

            return false;
        }
        

        
    }
}
