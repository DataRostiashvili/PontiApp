using PontiApp.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Validators.EntityValidators
{
    public class PlaceDTOValidator
    {
        private readonly ApplicationDbContext _context;

        public PlaceDTOValidator(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
