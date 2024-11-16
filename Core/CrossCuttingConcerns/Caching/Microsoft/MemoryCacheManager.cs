using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Adapter pattern
        IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }
        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        //Bellekte böyle bir cache değeri var mı?
        public bool IsAdd(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            //var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            //var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            //List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            //foreach (var cacheItem in cacheEntriesCollection)
            //{
            //    ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
            //    cacheCollectionValues.Add(cacheItemValue);
            //}

            //var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            //var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            //foreach (var key in keysToRemove)
            //{
            //    _memoryCache.Remove(key);
            //}



            var coherentState = typeof(MemoryCache)
       .GetField("_coherentState", BindingFlags.NonPublic | BindingFlags.Instance)
       ?.GetValue(_memoryCache);

            var entriesCollection = coherentState?.GetType()
                .GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetValue(coherentState) as ICollection;

            if (entriesCollection == null)
                return;

            var cacheItems = entriesCollection.Cast<dynamic>()
                .Select(entry => entry.GetType().GetProperty("Key").GetValue(entry, null))
                .ToList();

            foreach (var key in cacheItems)
            {
                if (Regex.IsMatch(key.ToString(), pattern, RegexOptions.IgnoreCase))
                {
                    _memoryCache.Remove(key);
                }
            }

        }
    }


}
    

