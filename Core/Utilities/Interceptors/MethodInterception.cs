using System;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //Hangi metot çalıştırılmak isteniyorsa burada parametre olarak verilir.
        //Örneğin OnBefore(CarValidator Add) gibi..
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { } //invocation --> çalıştırılmak istenilen metoda karşılık gelmektedir
                                    

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            //Metodun nerede çalıştırılması gerektiğini belirleyen blok
            //Genelde OnBefore ve OnException kullanılmaktadır.

            //Bütün metodlarda çalışacak temel try-catch bloğu
            OnBefore(invocation); //OnBefore, kodun başında çalışır
            try
            {
                invocation.Proceed();
            }
            catch (Exception e) 
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
}