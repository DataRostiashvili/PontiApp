using Microsoft.EntityFrameworkCore;
using PontiApp.Data.DbContexts;
using PontiApp.Models.DTOs;
using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.User.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _ctx;

        public UserRepository (ApplicationDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> CheckIfExists (long id) => await _ctx.Users.FirstOrDefaultAsync(u => u.UserEntityId == id) != null;

        public async Task/*<bool>*/ AddUser (UserEntity user)
        {
            await _ctx.Users.AddAsync(user);
            await _ctx.SaveChangesAsync();
        }
    }
}
