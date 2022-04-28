using System;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine(item.Description);
            }

        }
    }
}
