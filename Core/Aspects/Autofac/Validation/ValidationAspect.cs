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
    //Aspect
    public class ValidationAspect : MethodInterception 
    {
        private Type _validatorType;

        //Attribute == ValidationAspect
        public ValidationAspect(Type validatorType)
        {
            //defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) //If not validation, throw Exception
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            //Reflection(Activator.CreateInstance)
            var validator = (IValidator)Activator.CreateInstance(_validatorType); 

            
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; 

            //invocation = method
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
