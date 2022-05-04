using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    //Veritabanına yapılacak herhangi bir CRUD operasyonu için kod tekrarından kurtulmaya yarayacak yapı
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //Buradaki CRUD metotları her bir EntityFramework katmanında aynı değişkenleri ve parametleri barındırdığı için--
            //bu yapılar için bir generic class oluşturulabilir.

            //Belleğin hızlıca temizlenmesini sağlayan blok(dispose)
            //IDisposable Pattern Implementation of C# -- Search
            using (TContext context = new TContext())
            {
                //Referansı yakala, ekle ve tut
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

            }
        }
        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var uptadedEntity = context.Entry(entity);
                uptadedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //Tek bir veri getirmek için DBSet'lerden Car' a git ve SingleOfDefault' a verilen filtreye göre getir.
                return context.Set<TEntity>().SingleOrDefault(filter);

            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                //Ternary Operator
                //Eğer filtre verilmemişse tüm veriyi getir,:, verilmemişse Car tablosundaki filtrelenen veriyi Listele ve getir.
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }
    }
}
