using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandModelDal : IBrandModelDal
    {
        public void Add(BrandModel entity)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(BrandModel entity)
        {
            using (CarRentalDBContext context = new CarRentalDBContext() )
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(BrandModel entity)
        {
            using (CarRentalDBContext contex = new CarRentalDBContext())
            {
                var uptadedEntity = contex.Entry(entity);
                uptadedEntity.State = EntityState.Modified;
                contex.SaveChanges();
            }
        }

        public BrandModel Get(Expression<Func<BrandModel, bool>> filter = null)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                return context.Set<BrandModel>().SingleOrDefault(filter);
            }
        }

        public List<BrandModel> GetAll(Expression<Func<BrandModel, bool>> filter = null)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                return filter == null ? context.Set<BrandModel>().ToList() : context.Set<BrandModel>().Where(filter).ToList();
            }
        }
    }
}
