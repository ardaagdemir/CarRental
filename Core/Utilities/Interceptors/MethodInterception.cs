using System;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
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
}