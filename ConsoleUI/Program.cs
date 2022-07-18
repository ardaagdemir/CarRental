using System;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using Business.Concrete;
using Business.Constants;
using Core.Utilities.Results;
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
            //CarListTest();
        }

        private static void CarListTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            
            var result = carManager.GetCarDetails();
            if (result.Success)
            {
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CarName + "/" + c.BrandName + "/" + c.ColorName + "/" + c.ModelYear);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }
    }
}
