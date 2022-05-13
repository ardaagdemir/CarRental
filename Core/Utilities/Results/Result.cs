using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //Constructor ile parametre olarak yalnızca sonucu veya hem sonucu hem de mesajı döndürebilen metotlar oluşturuldu.

        //Constructor
        //Result'a(this) success tutan constructorı bağlamak anlamına gelir.
        //This kullanmak yerine global bir 'success' değişkeni oluşturularak da aynı işlem yapılabilirdi.
        //Ancak burada iki parametre alan constructor' da success parametresinin tekrar belleğe tanıtılmasına gerek olmadığı için,--
        //tek parametreli (success) constructorı this keyword ü ile 2 parametreli constructora vererek bellekte tanıtılan parametreyi alması sağlandı.
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }

        //Overloading
        public Result(bool success)
        {
            Success = success;
        }


        //Getter, read only' dir. Constructor' da set edilebilir.
        public bool Success { get; }
        public string Message { get; }
    }
}
