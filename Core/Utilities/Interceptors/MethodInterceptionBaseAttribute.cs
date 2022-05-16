using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
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
}
