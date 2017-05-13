using System;
using System.Runtime.Caching;

namespace HealthyFood.Services
{
    /// <summary>
    /// Method that doing CRUD operation with using Cashe
    /// </summary>
    /// <returns></returns>
    public class MemoryCasheService
    {
        public object GetValue(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Get(key);
        }

        public bool Add(string key, object value, DateTimeOffset absExpiration)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            return memoryCache.Add(key, value, absExpiration);
        }
        
        public void Delete(string key)
        {
            MemoryCache memoryCache = MemoryCache.Default;
            if (memoryCache.Contains(key))
                memoryCache.Remove(key);
        }
    }
}
