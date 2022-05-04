using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.DataAccess;

namespace DataAccess.Abstract
{
    //Dal---> Data Access Layer
    //Database operation
    public interface ICarDal : IEntityRepository<Car>
    {
    }
}
