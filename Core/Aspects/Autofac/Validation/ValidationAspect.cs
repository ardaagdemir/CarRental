using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    //7
    public class ValidationAspect : MethodInterception //Aspect
    {
        private Type _validatorType;

        //Attribute = ValidationAspect
        public ValidationAspect(Type validatorType) //Attribute' lara tipler 'Type' ile atanır.
        //Attribute'larda bu şekilde kısıtlamalar yapılması gerekmektedir.
        {
            //defensice coding(savunma odaklı kodlama)
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //Kullanacak kişinin yazdığı şey bir Validator değil ise Exception hata mesajı fırlat.
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }

        //MethodInterception içerisindeki OnBefore' da çalışacak kod burada belirlenmiştir.
        //Yalnızca OnBefore çağırılmıştır.
        protected override void OnBefore(IInvocation invocation)
        {
            //Reflection(Activator.CreateInstance) --> Çalışma anında başka bir şeyi çalıştırabilmeyi sağlar. 
            //--> CarValidator' ın instance'ını oluştur. Bu instance' ı IValidator' da kullanılabilir hale getirir.
            var validator = (IValidator)Activator.CreateInstance(_validatorType); 

            //CarValidator' ın basetype'ını(AbstractValidator) ve onun çalıştığı Generic veri tipinden(Car) ilkini(0) bul.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //CarValidator' ın çalışma tipini bul.

            //invocation = metot
            //Metodun(invocation), parametrelerine(Arguments) bak ve entityType' a denk gelen parametreleri(Add metoduna verilen parametreleri) bul.
            //Bunun yazılmasının sebebi birden fazla parametre veya Validation olabileceği içindir.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            //Parametreleri gez, ValidationTool kullanarak Validate et.
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
