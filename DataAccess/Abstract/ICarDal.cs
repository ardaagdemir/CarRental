using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.DataAccess;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    //Database operation
    //Dal---> Data Access Layer
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
    }
}
