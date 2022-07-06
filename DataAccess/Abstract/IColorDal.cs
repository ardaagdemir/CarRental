using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using Core.DataAccess;

namespace DataAccess.Abstract
{

    public interface IColorDal : IEntityRepository<Color>
    {
    }
}
