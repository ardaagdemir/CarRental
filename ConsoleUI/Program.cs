using System;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using Business.Concrete;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarTest();

            //BrandTest();
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            foreach (var brand in brandManager.GetByBrandId(2))
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //foreach (var item in carManager.GetAll())
            //{
            //    Console.WriteLine(item.DailyPrice + " --" + item.Description + " --" + item.BrandId + "-- " + item.ColorId);
            //}

            foreach (var c in carManager.GetCarDetails())
            {
                Console.WriteLine(c.CarName + "/" + c.BrandName + "/" + c.ModelYear);
            }

            //carManager.Add(new Car
            //{
            //    CarName = "AUDI A6", BrandId = 2, ColorId = 3, DailyPrice = 240000, ModelYear = 2019,
            //    Description = "5 kapı sedan"
            //});
        }
    }
}
