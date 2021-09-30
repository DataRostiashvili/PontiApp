using PontiApp.Data.DbContexts;
using PontiApp.Models.Entities;
using PontiApp.Ponti.Repository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Ponti.Repository.PontiRepository
{
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository(ApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {

        }

        public override Task InsertGuesting(UserEntity entity)
        {
            throw new NotImplementedException();
        }

        public override Task InsertHosting(UserEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
