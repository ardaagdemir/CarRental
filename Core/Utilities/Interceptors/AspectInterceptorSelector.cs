using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
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

            //Ulaşılan attribute değerlerini IInterceptor listesine ekle
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); //Otomatik olarak sistemdeki bütün metotları log' a dahil et.

            //Çalışma sırasını da Priority' ye(öncelik değerine) göre sırala
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}