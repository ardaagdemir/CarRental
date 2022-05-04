using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    //Dal---> Data Access Layer
    //Database operation
    public interface IBrandDal : IEntityRepository<Brand>
    {
    }
}
