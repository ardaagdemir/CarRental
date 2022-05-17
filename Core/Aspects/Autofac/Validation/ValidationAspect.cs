using Core.Utilities.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingconcerns.Validation;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType) //Attribute' lara tipler 'Type' ile atanır.
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //Kullanacak kişinin yazdığı şey bir Validator değil ise Exception hata mesajı fırlat.
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }

        //MethodInterception içerisindeki OnBefore' da çalışacak kod burada belirlenmiştir.
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); //Reflection --> çalışma anında başka bir şeyi çalıştırabilmeyi sağlar.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //carValidator' ın çalışma tipini bul.
            //invocation--> metot ---- carValidator'ın tipine eşit olan parametreleri bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); //parametrelerini bul(ilgili methodun(add) parametrelerini bul)
            foreach (var entity in entities)//parametreleri gez, ValidationTool kullanarak Validate et.
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
