using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Core.Utilities.Helpers.GuidHelpers
{
    public class GuidHelper
    {
        public static string CreateGuid()
        {
            return Guid.NewGuid().ToString(); //Burada yüklenen dosya için eşsiz bir isim oluşturulur. Yani dosya eklerken dosyanın adı kendi olmasın, ona verilen bir isim                                               oluşturulsun ki aynı isimde başka bir dosya varsa çakışmasın anlamına gelir.
                                              //Guid.NewGuid() --> bu metot eşsiz bir isim oluşturur.
                                              //ToStringConverter() --> Bu metotla string bir ifadeye haline getirilir.

        }
    }
}
