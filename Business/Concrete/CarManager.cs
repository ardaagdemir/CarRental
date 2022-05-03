using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    //BusinessCode
    public class CarManager : ICarService
    {
        private ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //Operation
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public void Add()
        {
            Console.WriteLine("Eklendi");
        }
    }
}
