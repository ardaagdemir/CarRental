using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetByBrandId(int brandId);
        List<Car> GetByColorId(int colorId);
        public void Add(Car car);
        public void Delete(Car car);
        public void Update(Car car);

        List<CarDetailDto> GetCarDetails();

    }
}
