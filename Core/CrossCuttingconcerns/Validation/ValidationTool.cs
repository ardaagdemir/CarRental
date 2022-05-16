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
        public static void Validate(IValidator validator, object entity)
        {

            var context = new ValidationContext<object>(entity); //bir obje olan entity için doğrulama yap
            var result = validator.Validate(context); //validator'ı ilgili context için doğrula 

            if (!result.IsValid) //eğer sonuç geçerli değilse(IsValid)
            {
                throw new ValidationException(result.Errors); //hata fırlat(throw)
            }
}
    }
}
