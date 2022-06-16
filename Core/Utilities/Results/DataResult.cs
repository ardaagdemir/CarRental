using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        //Result' ı ve IDataResult' ı inherit eden somut bir classtır.
        //Burada data'ların nasıl döneceği belirlenmektedir.
        //Constructor ile overload yapılarak data ve sonuç veya data, sonuç ve mesajın' da döndürülebileceği durumlar oluşturuldu.
        //Ancak data' nın döndürülmesinin şartı sonucun true olmasıdır.
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        //Data yalnız başına gönderilemez, mutlaka bir success gönderilmesi gerekir.
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

        //Implementation
        public T Data { get; }
        
    }
}
