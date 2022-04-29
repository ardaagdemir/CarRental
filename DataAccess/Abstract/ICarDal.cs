using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    //Dal---> Data Access Layer
    //Database operation
    public interface ICarDal
    { 
        List<Car> GetById(int BrandId);
        List<Car> GetAll();
        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);
    }
}
