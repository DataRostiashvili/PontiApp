using Microsoft.EntityFrameworkCore;
using PontiApp.Data.DbContexts;
using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Ponti.Repository.PontiRepository
{
    public class PontiRepository<T> : IPontiRepository<T> where T : BaseEntity
    {
        #region property  
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly DbSet<T> entities;
        #endregion

        #region Constructor  
        public PontiRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            entities = _applicationDbContext.Set<T>();
        }
        #endregion


        public async Task Delete(T entity)
        {
            if (entity != null)
            {
                entities.Remove(entity);
                await _applicationDbContext.SaveChangesAsync();
            }
            throw new ArgumentNullException(nameof(entity));

        }

        public async Task<T> GetByID(int Id)
        {
            return await entities.SingleOrDefaultAsync(p => p.QueueId == Id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await entities.ToListAsync();
        }

        public async Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate)
        {
            return await entities.Where(predicate).ToListAsync();
        }

        public async Task Insert(T entity)
        {
            if (entity != null)
            {
                await entities.AddAsync(entity);
                await _applicationDbContext.SaveChangesAsync();
            }
            throw new ArgumentNullException(nameof(entity));

        }

        public async Task Update(T entity)
        {
            if (entity != null)
            {
                entities.Update(entity);
                await _applicationDbContext.SaveChangesAsync();
            }
            throw new ArgumentNullException(nameof(entity)); throw new NotImplementedException();
        }

        public async Task<int> CountAll()
        {
            return await entities.CountAsync();
        }
        public async Task<int> CountWhere(Expression<Func<T, bool>> predicate)
        {
            return await entities.Where(predicate).CountAsync();

        }
    }
}
