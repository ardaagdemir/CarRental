using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;

namespace Core.DataAccess
{
    //BASE CRUD OPERATION
    //Generic Repository Design Pattern
    //Generic Constraint
    public interface IEntityRepository <T> where T:class,IEntity, new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        //Expression-->Predicate??
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
