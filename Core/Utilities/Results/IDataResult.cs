using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //List<> yapısı için oluşturulan Generic yapıdır.
    //IRestult' ı referans olarak alır.
    //Hem T tipinde bir data döndürmeye hem de IResult'dan dolayı mesaj ve sonuç döndürmeye yarar.
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
