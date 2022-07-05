using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        //API' nin servis bağımlılıklarının ya da araya girmesi istenilen servislerin eklendiği bir yapıdır.
        //IServisCollection' ı genişleterek içerisinde AddDependencyResolvers metodu kullanılabilecek. Bu sayede de bağımlılıklar AddDependencyResolvers'a eklenebilecek.
        public static IServiceCollection AddDependencyResolvers(this IServiceCollection serviceCollection, ICoreModule[] modules)
        {
            foreach (var module in modules)
            {
                //Birden fazla module' un eklenebileceğini gösterir.
                module.Load(serviceCollection);
            }

            return ServiceTool.Create(serviceCollection);
        }

        //Kısacası bu kod bloğu eklenecek tüm injection' ları bir arada toplamaya yarayacaktır.
        //Eklenecek injection' lar --> business da bulunan DependencyResolvers' da bulunan local bağımlılıklar ve Core' da bulunan global bağımlılıklardır.
    }
}
