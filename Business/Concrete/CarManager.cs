using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Text;
using System.Threading.Channels;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
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

        public Car GetById(int carId)
        {
            return _carDal.Get(c=> c.Id == carId);
        }


        public IResult Add(Car car)
        {
            if (car.CarName.Length < 2)
            {
                return new ErrorResult(Messages.CarNameInvalid);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }
        

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true,"Ürün silidi");
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true, "Ürün güncellendi.");
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
