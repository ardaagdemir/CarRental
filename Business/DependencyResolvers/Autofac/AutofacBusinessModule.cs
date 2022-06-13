using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
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
        //WepAPI katmanında Startup.cs içerisinde bağımlılığı azaltmak için nesnelerin birer instance' ı oluşturulmuştu.
        //Ancak projeye farklı bir Api hizmeti daha eklenebilmesi ve bunun efektif kullanılabilmesi için--
        //Startup.cs içerisinde newlenen ve ilişkilendirilen class'lar ve interface'ler burada tutulmalıdır.
        //Autofac teknolojisi bize bu instance üretimi için gerekli ortamı sağlamaktadır.
        //Bunun için oluşturduğumuz AutofacBusinessModule sınıfına Autofac eklentisinde bulunan "Module" abstract class'ı inherit edilmelidir.
        //Load metodu override edilir. Uygulama hayata geçtiği zaman bu kısım çalışacaktır. Base' deki Load' ın çalışması override ile engellenir.

        protected override void Load(ContainerBuilder builder)
        {
            //Startup.cs' deki services.AddSingleton<>'a karşılık gelmektedir.
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance(); //ICarService istenirse ona bir CarManager instance' ı ver anlamına gelir.
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<BrandManager>().As<IBrandService>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorService>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerService>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalService>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();
            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();

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
