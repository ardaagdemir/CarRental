using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal : EfEntityRepositoryBase<Color, CarRentalDBContext>, IColorDal
    {
        //Buradaki CRUD metotları her bir EntityFramework katmanında aynı değişkenleri ve parametleri barındırdığı için--
        //bu yapılar için bir generic class oluşturulabilir.

        //Belleğin hızlıca temizlenmesini sağlayan blok(dispose)
        //IDisposable Pattern Implementation of C# -- Search
        
    }
}
