using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    //2
    //AbstractValidator == IValidator
    public class CarValidator : AbstractValidator<Car>
    {
        
        //Business Validation 
        public CarValidator()
        {
            RuleFor(c => c.CarName).MinimumLength(2);

            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();

            RuleFor(c => c.DailyPrice).GreaterThan(0);

            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(2010).When(c => c.BrandId == 1);

            //RuleFor(c => c.CarName).Must(StartWithA);
        }

        //bool => true, arg => gönderilen parametre
        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
