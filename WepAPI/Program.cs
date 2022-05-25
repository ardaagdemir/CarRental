using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Business.DependencyResolvers.Autofac;
using Autofac.Extensions.DependencyInjection;

namespace WepAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        //Server configürasyonun olduðu yer
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            //Kendimizin belirlediði bir IoC(AutofacBusinessModule) yapýsýný kullanmak için DefaultBuilder olarak bu þekilde belirtmemiz gerekmektedir.
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())//Servis saðlayýcý fabrikasý olarak kullan
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacBusinessModule());
                })


                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
