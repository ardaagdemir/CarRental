using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        //-----------------Dependency Injection------------------
        //Global değişken
        //Referans tutucu 
        private List<Car> _car;

        //Constructor
        //Proje new'lendiğinde çalışacak kısım
        public InMemoryCarDal()
        {
            //Simulation--racle, Sql Server, Postgres, MongoDb
            _car = new List<Car>
            {
                new Car() {Id = 1, BrandId = 1, ColorId = 001, ModelYear = 2015, DailyPrice = 40000, Description = "BMW 420d"},
                new Car() {Id = 2, BrandId = 2, ColorId = 002, ModelYear = 2016, DailyPrice = 60000, Description = "BMW 420d"},
                new Car() {Id = 3, BrandId = 3, ColorId = 003, ModelYear = 2017, DailyPrice = 80000, Description = "BMW 420d"},
                new Car() {Id = 4, BrandId = 4, ColorId = 004, ModelYear = 2018, DailyPrice = 100000, Description = "BMW 420d"}
            };
        }

        public List<Car> GetById(int BrandId, int Id)
        {
            //LINQ
            return _car.Where(c => c.BrandId == BrandId).ToList();
            return _car.Where(c => c.Id == Id).ToList();

        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public void Add(Car car)
        {
            //Business'dan gelen kurallara göre DB' ye veri ekleme
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            //LINQ(Language Integrated Query)-DB Query
            Car carToDelete = _car.SingleOrDefault(c=>c.Id == car.Id);
            _car.Remove(carToDelete);

            //Alternatif
            //Car carToDelete2;
            //foreach (var c in _car)
            //{
            //    if (car.Id == c.Id)
            //    {
            //        carToDelete2 = c;
            //    }
            //}
        }

        public void Update(Car car)
        {
            Car carToUpdate = _car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description; 
        }
    }
}
