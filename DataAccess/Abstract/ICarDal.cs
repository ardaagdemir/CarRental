using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.DataAccess;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    //Dal---> Data Access Layer
    //Database operation
    public interface ICarDal : IEntityRepository<Car>
    {
        //Yalnızca Car sınıfına ait nesneleri barındıracağı için bu bir IEntityRepository(ortak method) değildir.
        //Car nesnesine ait olduğu için bu nesneyi tutan EfCarDal sınıfına implement edilmelidir.
        List<CarDetailDto> GetCarDetails();

    }
}
