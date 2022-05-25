using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    //AbstractValidator aynı zamanda IValidator' dır.
    public class CarValidator : AbstractValidator<Car>
    {
        //2
        //Validation -->Örneğin, Add metodunda eklenilmeye çalışılan nesnenin(car) iş kurallarına dahil edilmesi için yapısal olarak uygun olup olmadığına bakılan yapıdır.
        //CarManager'da belirtilen koşullar burada tanımlanacaktır.
        //Buradaki kurallar bir constructor içine yazılmaktadır.
        //İş kodları bu kısımda olacaktır.

        public CarValidator()
        {
            //...için kural
            //CarName en az 2 karakter olmalıdır.
            RuleFor(c => c.CarName).MinimumLength(2);

            //Boş olmamalıdır.
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.DailyPrice).NotEmpty();

            //0'dan büyük olmalıdır.
            RuleFor(c => c.DailyPrice).GreaterThan(0);

            //Model yılı 2010' dan yüksek olmalıdır, brandId 1 olduğunda
            RuleFor(c => c.ModelYear).GreaterThanOrEqualTo(2010).When(c => c.BrandId == 1);

            //Kendi kuralımızı koymak istediğimizde aşağıdaki syntax kullanılır.
            RuleFor(c => c.CarName).Must(StartWithA);
        }

        //bool => true, arg => gönderilen parametre
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
