using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    //Caching Nedir?
    //Herhangi bir kullanıcı bir istekte bulunduğunda program veritabanına giderek veriyi getirir.
    //Başka bir kullanıcı aynı istekte bulunduğunda eğer veritabanında herhangi bir değişiklik yapılmadıysa programın tekrar veri tabanına gidip veriyi getirmesi doğru olmayacaktır. Veri zaten daha önceden çağırılmış bir veridir.
    //Teknik olarak bir kategori çağırıldığında onu cache' leyerek tekrar aynı veri çağırıldığında verinin cache' den gelmesi sağlanır.

    //Cache birkaç yöntem ile yapılabilmektedir.
    //Bu projede .NetCore' un kendi mekanizması olan InMemoryCache kullanılacaktır.
    //Cache için istenilen süre verilebilmektedir.
    //Cache' de bir başka durum ise veritabanında bir değişiklik yapıldığında daha önce oluşturulmuş Cache' in yok edilmesidir.
    //Cache'lemek istenilen data bellekte(InMemoryCache) key-value türünde tutulmaktadır.

    //ICacheManager inteface' nin kurulma amacı ileride InMemoryCache dışında farklı Cache belleklerini de kullanabilme ihtimalidir.
    public interface ICacheManager
    {
        //Cache' den bir data gelmelidir. Ancak bu data tek bir data veya bir list' de olabilir.
        T Get<T>(string key);

        void Add(string key, object value, int duration); //Cache' ekleme

        object Get(string key);
        bool IsAdd(string key); //Cache' de var mı kontrolü
        void Remove(string key); //Cache' den güncellenen veriyi silme

        //Filtreleyerek silme işlemi
        void RemoveByPattern(string pattern);
    }
}
