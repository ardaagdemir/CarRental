using Castle.DynamicProxy;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;
using IInterceptor = Castle.DynamicProxy.IInterceptor;


//4
//Interceptor --> araya giren, yol kesen...
//Buradaki kod bloğu validation' ları attribute olarak business katmanına vermek için yazılmıştır.
//Instance yaratabilmek için bir IoC Container gibi davranan projeye eklediğimiz Autofac' in hem Validate hem de burada kullanılan Interceptor özelliği vardır.
//Oluşturacağımız AOP yapısını sağlayan yapı Autofac ve yardımcı araçlarıdır.

namespace Core.Utilities.Interceptors
{
    //Attribute --> Bir metodu çalıştırırken önceden belirlenen bazı kısıtların veya koşulların kontrolü için kullanılır.
    //Attribute' lar ilgili metodun üzerine yazılır.
    
    //Attribute hem class' a hem metot' a uygulanabilir, Birden çok class veya metotla kullanılabilir(AllowMultiple), Class ve metotlara inherit edilebilir(Inherited)
    //Bir loglama durumunda hem veritabanına hem de bir dosyaya loglama yapabilmek için AllowMultiple yazılmalıdır.
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
