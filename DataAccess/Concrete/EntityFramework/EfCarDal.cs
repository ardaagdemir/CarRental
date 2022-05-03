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
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            //Belleğin hızlıca temizlenmesini sağlayan blok(dispose)
            //IDisposable Pattern Implementation of C# -- Search
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                //Referansı yakala, ekle ve tut
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

                context.Cars.Add(entity);
            }
        }

        public void Delete(Car entity)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                var uptadedEntity = context.Entry(entity);
                uptadedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                //Tek bir veri getirmek için DBSet'lerden Car' a git ve SingleOfDefault' a verilen filtreye göre getir.
                return context.Set<Car>().SingleOrDefault(filter);
                
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarRentalDBContext context = new CarRentalDBContext())
            {
                //Ternary Operator
                //Eğer filtre verilmemişse tüm veriyi getir,:, verilmemişse Car tablosundaki filtrelenen veriyi Listele ve getir.
                return filter == null 
                    ? context.Set<Car>().ToList() 
                    : context.Set<Car>().Where(filter).ToList();
            }
        }
    }
}
