using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);

        void Add(string key, object value, int duration); //Add Cache

        object Get(string key);
        bool IsAdd(string key); //Check Cache
        void Remove(string key); //Update Caching and Remove

        //Deletion by filtering
        void RemoveByPattern(string pattern);
    }
}
