using PontiApp.Models.Entities;
using System.Threading.Tasks;

namespace PontiApp.User.Repository
{
    public interface IUserRepository
    {
        Task AddUser (UserEntity user);
        Task<bool> CheckIfExists (long id);
    }
}