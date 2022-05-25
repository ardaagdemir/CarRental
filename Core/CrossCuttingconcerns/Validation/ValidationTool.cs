using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Core.CrossCuttingconcerns.Validation
{
    //static bir sınıfın metotları da static olmalıdır
    public static class ValidationTool
    {
        //3
        public static void Validate(IValidator validator, object entity)
        {
            //Validation yapılacağında çalışacak kod bloğudur.
            //Her doğrulama için yazmak yerine bir kere yazılarak devamlı kullanılabilir.
            //Evrensel kullanıma uygundur.

            var context = new ValidationContext<object>(entity); //bir obje olan entity için doğrulama yap
            var result = validator.Validate(context); //validator'ı ilgili context için doğrula 

            if (!result.IsValid) //eğer sonuç geçerli değilse(!)
            {
                throw new ValidationException(result.Errors); //hata fırlat
            }
}
    }
}
