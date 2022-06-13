using System;
using System.Collections.Generic;
using System.Text;
using Core.DataAccess;
using Core.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        //join işlemi gerçekleşmelidir
        //Bir kullanıcının claim'leri çekilmek istenildiğinde aşağıdaki operasyon yazılmalıdır.
        List<OperationClaim> GetClaims(User user);
    }
}
