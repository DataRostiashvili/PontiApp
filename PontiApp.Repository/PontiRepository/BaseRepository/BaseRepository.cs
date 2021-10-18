using Microsoft.EntityFrameworkCore;
using PontiApp.Data.DbContexts;
using PontiApp.Models.Entities;
using PontiApp.Ponti.Repository.PontiRepository.BaseRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Ponti.Repository.BaseRepository
{
    public class BaseRepository<T> where T : BaseEntity
    {
        
        protected readonly ApplicationDbContext _applicationDbContext;
        protected readonly DbSet<T> entities;

         
        public BaseRepository(ApplicationDbContext applicationDbContext)
        { 
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
        }
        

        public async Task Delete(T entity)
        {
            entities.Remove(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task DeleteRange(List<T> entityList)
        {
            entities.RemoveRange(entityList);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<T> GetByID(int Id)
        {
            return await entities.Where(e => e.Id == Id).FirstOrDefaultAsync();
        }

        public async Task Insert(T entity)
        {
            await entities.AddAsync(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task InsertRange(List<T> entityList)
        {
            await entities.AddRangeAsync(entityList);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            entities.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task UpdateRange(List<T> entityList)
        {
            entities.UpdateRange(entityList);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task<int> CountAll()
        {
            return await entities.CountAsync();
        }
        
        public async Task<List<T>> GetAll()
        {
            return await entities.ToListAsync();
        }
    }
}
