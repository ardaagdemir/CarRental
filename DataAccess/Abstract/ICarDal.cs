using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    //Dal---> Data Access Layer
    //Database operation
    public interface ICarDal : IEntityRepository<Car>
    {
    }
}
