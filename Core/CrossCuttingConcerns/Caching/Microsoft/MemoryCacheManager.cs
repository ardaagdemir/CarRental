using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        //Cons Inj. burada çalışmaz. Sebebi Aspect' in bağımlılık zincirinin(WebAPI-Business-DataAccess) içinde olmamasıdır.
        //Adapter Patter --> Var olan bir sistemi kendi sistemimize uyarlamak için kullanılan bir pattern'dir.
        private IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }
        
        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration)); //TimeSpan --> zamanı algıla
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public bool IsAdd(string key)
        {
            //Bellek kontrolü
            return _memoryCache.TryGetValue(key, out _); //out _ --> bir değer döndürülmek istenmiyorsa
        }

        public void Remove(string key)
        {
             _memoryCache.Remove(key);
        }

        //Çalışma anında bellekten silmeye yarar
        //Reflection --> Dinamik olarak sistem içerisindeki(app domain) yüklü olan tipleri en küçük birimden en büyük birime kadar yönetmeyi sağlar. İçerisindeki meta-data' ları almaya yarar.
        //Bir IoC-Container tasarlarken Reflection kullanılabilir. Yazılmış bütün IoCContainer' larda Reflection hazır olarak bulunmaktadır.
        //Kodu çalışma anında oluşturma, koda çalışma anında müdahele etme gibi durumlarda reflection kullanılır. 
        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }
    }
}
