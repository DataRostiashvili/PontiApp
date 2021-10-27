using System;
using System.Threading.Tasks;

namespace PontiApp.Images.Cache.Caching_service
{
    public interface ICachingService
    {
        Task<T> GetRecordAsync<T>(string key);
        Task SetRecordAsync<T>(string key, T data, TimeSpan absoluteTime, TimeSpan slidingTime);
        Task UpdateRecordAsync<T>(string key, T data, TimeSpan absoluteTime, TimeSpan slidingTime);
    }
}