using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, CarRentalDBContext>, ICarDal
    {
        //CarDetailDto' da verilen nesneler burada birbirleri ile join edilmiş oldu
        public List<CarDetailDto> GetCarDetails()
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var result = from c in context.Cars
                    join b in context.Brands on c.BrandId equals b.BrandId
                    join cl in context.Colors on c.ColorId equals cl.ColorId
                    select new CarDetailDto { CarId = c.CarId, CarName = c.CarName, BrandName = b.BrandName, 
                        ColorName = cl.ColorName, ModelYear = c.ModelYear, DailyPrice = c.DailyPrice, Description = c.Description};

                return result.ToList();
            }
            
        }
    }
}
