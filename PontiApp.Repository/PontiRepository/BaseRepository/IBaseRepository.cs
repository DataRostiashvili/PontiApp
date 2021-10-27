using PontiApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontiApp.Ponti.Repository.PontiRepository.BaseRepository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        public Task Delete(T entity);

        public Task<T> GetByID(int Id);

        public Task Insert(T entity);

        public Task Update(T entity);

        public Task<int> CountAll();

        public Task<List<T>> GetAll();

        public Task<int> NextQueueId();

    }
}
