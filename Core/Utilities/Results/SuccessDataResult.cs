using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //DataResult oluşturulduktan sonra bazı kısıtlamalar yapılması gerekmektedir.
        //Örneğin data'yı business katmanındaki belirlenen kurallara göre listelemek istediğimizde sonucun true veya false olma ihtimalleri olduğundan---
        //Bu ihtimallerin oluşturulması gerekmektedir. Aksi halde yalnızca DataResult'a göre yapıldığında buradaki kodların tekrar yazılması gerekmektedir.
        //Aynı durumlar SuccessResult, ErrorResult, ErrorDataResult için geçerlidir.
        public SuccessDataResult(T data) : base(data, true)
        {
        }

                                //Dönecek tipler           //Tiplerin base' de doğrulanması için tipleri
        public SuccessDataResult(T data, string message) : base(data, true, message)
        {
        }

        //Data tipi default dönüyor
        public SuccessDataResult(string message) : base(default,true,message)
        {
        }

        public SuccessDataResult():base(default,true)
        {
        }
    }
}
