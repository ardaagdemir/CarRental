using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //List<> yapısı için oluşturulan Generic yapıdır.
    //IRestult' ı referans olarak alır.
    //Hem T tipinde bir data döndürmeye hem de IResult'dan dolayı mesaj ve sonuç döndürmeye yarar.
    //Bu yapının oluşturulmasındaki amaç, döndürülmek isteyen List<> türünde bir operasyon belirlenmiş olmasıdır.
    //Bu operasyon veritabanında bulunan dataları listeleyeceği için data'yı listeleyen ve bir mesaj veya sonuç döndüren bir soyutlama yapılması gerekiyor.
    //Data döndürmeyen yalnızca CRUD operasyonlarının gerçekleşeceği durumlar da olduğundan dolayı Data için ayrı bir soyutlama yapılması ve buraya ---
    //CRUD için tanımlanan mesaj ve sonuç parametrelerinin de tanımlaması gerekir.
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
        byte[] PasswordSalt { get; set; }
        byte[] PasswordHash { get; set; }
    }
}
