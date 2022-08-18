using System;
using System.Linq;
using System.Runtime.Caching;
using System.Text.RegularExpressions;

namespace FrameworkExample.Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        protected ObjectCache Cache => MemoryCache.Default;
        public void Add(string key, object data, int cacheTime = 60)
        {
            if (data == null) return;

            var policy = new CacheItemPolicy { AbsoluteExpiration = DateTime.Now.AddMinutes(cacheTime) };
            Cache.Add(new CacheItem(key, data), policy);
        }

        public void Clear()
        {
            foreach (var cache in Cache)
            {
                Remove(cache.Key);
            }
        }

        public T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        public bool IsAdd(string key)
        {
            return Cache.Contains(key);
        }

        public void Remove(string key)
        {
            Cache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern,
                RegexOptions.Singleline
                | RegexOptions.Compiled
                | RegexOptions.IgnoreCase);

            var keysToRemove = Cache.Where(x => regex.IsMatch(x.Key)).Select(x => x.Key).ToList();
            foreach (var key in keysToRemove) Remove(key);
        }
    }
}
