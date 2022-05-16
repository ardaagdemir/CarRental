using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using IInterceptor = Castle.DynamicProxy.IInterceptor;

//Interceptor --> araya giren, yol kesen...

namespace Core.Utilities.Interceptors
{
    //Attribute --> Bir metodu çalıştırırken önceden belirlenen bazı kısıtların veya koşulların kontrolü için kullanılır.
    //Attribute' lar ilgili metodun üzerine yazılır.
    //Attribute hem class' a hem metot' a uygulanabilir, Birden çok class veya metotla kullanılabilir(AllowMultiple), Class ve metotlara inherit edilebilir(Inherit)
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        //Hangi attribute' un önce çalışacağına karar veren kod satırı
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }


    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            //try-catch hata yakalamak için kullanılır
            //Hata yakalanırsa finally metodu çalışır
            OnBefore(invocation); //OnBefore, kodun başında çalışır
            try
            {
                invocation.Proceed();
            }
            catch (Exception e) //
            {
                isSuccess = false;
                OnException(invocation, e); //Metot sırasında çalışır
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation); //Metot başarılı olduğunda çalışır
                }
            }

            OnAfter(invocation); //Metottan sonra çalışır
        }
    }

    public class AspectInterceptorSelector : IInterceptorSelector
    {
        //IInterceptor array; Yazılan attribute ları tek tek bularak bir dizi haline getirmeye yarar.
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            //Class' ın attributelarını oku
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            //Method' un attributelarını oku
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); //Otomatik olarak sistemdeki bütün metotları log' a dahil et.

            //Çalışma sırasını da Priority' ye göre sırala
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
