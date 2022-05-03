using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetByBrandId(int Id);
        List<Car> GetByColorId(int Id);
        public void Add(Car car);
        public void Delete(Car car);
        public void Update(Car car);

    }
}
