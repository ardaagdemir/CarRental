using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    //1
    public class AutofacBusinessModule : Module
    {
        //Class' ın oluşturulduğu ana klasör olan DependencyResolvers = Bağımlılık çözümleyici anlamına gelmektedir.
        //Burada asıl amaç varolan nesnelerimizi new'leyerek WepApi'nin bağımlılığını en aza indirmektir.(Loosely Coupled)
        //WepAPI katmanında Starttup.cs içerisinde bağımlılığı azaltmak için nesnelerin birer instance' ı oluşturulmuştu.
        //Ancak projeye farklı bir Api hizmeti daha eklenebilmesi ve bunun efektif kullanılabilmesi için--
        //Startup.cs içerisinde newlenen ve ilişkilendirilen class'lar ve interface'ler burada tutulmalıdır.
        //Autofac teknolojisi bize bu instance üretimi için gerekli ortamı sağlamaktadır.
        //Bunun için oluşturduğumuz AutofacBusinessModule sınıfına Autofac eklentisinde bulunan "Module" abstract class'ı inherit edilmelidir.
        //Load metodu override edilir. Uygulama hayata geçtiği zaman bu kısım çalışacaktır. Base' deki Load' ın çalışmasını engelliyoruz.

        protected override void Load(ContainerBuilder builder)
        {
            //Startup.cs' deki services.AddSingleton<>'a karşılık gelmektedir.
            builder.RegisterType<CarManager>().As<ICarService>();
            builder.RegisterType<EfCarDal>().As<ICarDal>();

            builder.RegisterType<BrandManager>().As<IBrandService>();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>();

            builder.RegisterType<ColorManager>().As<IColorService>();
            builder.RegisterType<EfColorDal>().As<IColorDal>();

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();

            builder.RegisterType<RentalManager>().As<IRentalService>();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            //Attribute'ları operasyona enjekte etmek için gerekli kod bloğu
            //Çalışan uygulama içerisinde(GetExecutingAssembly) implement edilmiş interface'leri bul(AsImplementedInterfaces) ve AspectInterceptorSelector' ı çağır.
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector() //Bütün sınıflar için bir Aspect oluşuturulup oluşturulmadığını kontrol eder.
                }).SingleInstance();
        }
    }
}
