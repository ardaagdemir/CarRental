using System;
using System.Collections.Generic;
using System.Text;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByBrandId(int brandId);
        IDataResult<List<Car>> GetByColorId(int colorId);
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails();

        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

        //It allows to undo an incorrect operation.
        IResult TransactionalOperation(Car car);

    }
}
