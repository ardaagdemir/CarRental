using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        //9
        //.Net' in IServiceCollection' ınını kullan ve onları build et(services.BuildServiceProvider).
        //Bu kod WebAPI veya Autofac' de kurulan injection yapılarını oluşturabilmeye yaramaktadır.
        //Artık istenilen herhangi bir interface' in servisteki karşılığı alınabilir.
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services)
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
