﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        //Class' ın oluşturulduğu ana klasöt olan DependencyResolvers = Bağımlılık çözümleyici anlamına gelmektedir.
        //Burada asıl amaç varolan nesnelerimizi new'leyerek WepApi'nin bağımlılığını en aza indirmektir.(Loosely Coupled)
        //WepAPI katmanında Starttup.cs içerisinde bağımlılığı azaltmak için nesnelerin birer instance' ı oluşturulmuştu.
        //Ancak projeye farklı bir Api hizmeti daha eklenebilmesi ve bunun efektif kullanılabilmesi için--
        //Startup.cs içerisinde newlenen ve ilişkilendirilen class'lar ve interface'ler burada tutulmalıdır.
        //Autofac teknolojisi bize bu instance üretimi için gerekli ortamı sağlamaktadır.
        //Bunun için oluşturduğumuz AutofacBusinessModule sınıfına Autofac eklentisinde bulunan "Module" abstract class'ı inherit edilmelidir.

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
        }
    }
}
