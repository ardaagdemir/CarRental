using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Core.CrossCuttingConcerns.Validation
{
    //3
    public static class ValidationTool
    {
        
        public static void Validate(IValidator validator, object entity)
        {
            

            var context = new ValidationContext<object>(entity); //validation for the entity
            var result = validator.Validate(context); //validation for the validatior

            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors); //throw Exception
            }
}
    }
}
