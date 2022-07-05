﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    
    public class CarManager : ICarService
    {
        //Global Variable
        //LooselyCoupled
        private ICarDal _carDal;

        //Constructor
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        //Operation
        public IDataResult<List<Car>> GetAll()
        {
            //if (DateTime.Now.Hour==23)
            //{
            //    return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            //}

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.CarListed);
        }

        public IDataResult<List<Car>> GetByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId==brandId));
        }

        public IDataResult<List<Car>> GetByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.CarListed);
        }


        //Bir metodun önünde, bir metodun sonunda veya bir metot hata verdiğinde, çalışması istenilen kod parçacıkları AOP mimarisi ile yazılır.
        //Burada metot çalışmadan önce attribute kodları çalışacaktır. Şartlar sağlanıyorsa metot çalışır.
        //Claim = product.add, admin...
        //Bir operasyon yetki gerektiriyorsa API tabanlı yapılarda JWT adında bir yapı kullanılır.
        [ValidationAspect(typeof(CarValidator))]
        [SecuredOperation("car.add, admin")] //İşlem yapacak kişinin ya admin ya da car.add claim' i olması gereklidir.Veritabanında gerekli yetkilendirme yapılmıştır.
        public IResult Add(Car car)
        {
            IResult result = BusinessRules.Run(CheckIfCareNameExist(car.CarName),
                CheckIfCarCountOfCategoryCorrect(car.BrandId));

            if (result != null)
            {
                return result;
            }

            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);

        }

        public IResult Update(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }


        //BusinessRules
        private IResult CheckIfCarCountOfCategoryCorrect(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).Count;
            if (result >= 10)
            {
                return new ErrorResult("Büyük olamaz");
            }

            return new SuccessResult();
        }

        private IResult CheckIfCareNameExist(string carName)
        {
            var result = _carDal.GetAll(c => c.CarName == carName).Any(); //Any = hiç var mı anlamına gelmektedir. Bool döndürür.
            if (result)
            {
                return new ErrorResult(Messages.CarNameAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
