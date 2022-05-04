using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Text;
using System.Threading.Channels;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    //BusinessCode
    public class CarManager : ICarService
    {
        //GlobalVariable
        private ICarDal _carDal;
        //Constructor
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //Operation
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.BrandId == colorId);
        }

        public void Add(Car car)
        {
            if (car.CarName.Length >= 2 && car.DailyPrice > 0 )
            {
                _carDal.Add(car);
                
            }
            else
            {
                if (car.CarName.Length < 2)
                {
                    Console.WriteLine("Araba ismi minimum 2 karakter olmalıdır");
                }
                else
                {
                    Console.WriteLine("Araba günlük fiyatı 0' dan büyük olmalıdır.");
                }
            }
            Console.WriteLine("Eklendi");
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Silindi");
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
