using System;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());


            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.DailyPrice + " --" + item.Description + " --" + item.BrandId + "-- " + item.ColorId);
            //}

            //foreach (var c in carManager.GetByBrandId(1))
            //{
            //    Console.WriteLine(c.Description);
            //}

            //carManager.Add(new Car{CarName = "AUDI A6", BrandId = 2, ColorId = 3, DailyPrice = 240000, ModelYear = 2019, Description = "5 kapı sedan"});

        }
    }
}
