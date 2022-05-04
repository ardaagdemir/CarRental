using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;

namespace Core.DataAccess
{
    //BASE CRUD OPERATION

    //Generic Repository Design Pattern
    //Generic Constraint -- T Parametresini kısıtlamak gerekiyor. class=referans tip olduğunu belirtir. IEntity' ye ait bir new'lenen referans tip olabilir.
    public interface IEntityRepository <T> where T:class,IEntity, new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        //Refactoring--GetAll, GetById metotlara verilen parametreler içerisinden seçim yapmaya yarar
        //Expression; id, name parametrelerini verebilmek için Linq ile kullanılacak
        //Expression-->Predicıt??
        T Get(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(Expression<Func<T,bool>> filter=null); 

        //List<T> GetById(int Id);
        //Yukarıdaki refactoring sayesinde bu kodu kullanmaya gerek kalmaz.
    }
}
