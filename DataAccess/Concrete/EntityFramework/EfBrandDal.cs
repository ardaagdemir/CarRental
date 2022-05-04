using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, CarRentalDBContext>, IBrandDal
    {
        //Buradaki CRUD metotları her bir EntityFramework katmanında aynı değişkenleri ve parametleri barındırdığı için--
        //bu yapılar için bir generic class oluşturulabilir. (EfEntityRepositoryBase)
    }
}
