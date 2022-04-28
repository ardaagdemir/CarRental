using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concerete;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
    }
}
