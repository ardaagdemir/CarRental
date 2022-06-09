using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Core.Utilities.Security.JWT
{
    //5
    //Genelde JWT ile yapılır ancak güvenlik açısından bu şekilde tanımlama gerçekleştirdik.
    public interface ITokenHelper
    {
        //Kullanıcı bilgilerini girdi ve bu bilgiler Api' ye geldi.
        //Eğer doğruysa burada ilgili kullanıcı için veritabanına gidilir ve veritabanından bu kullanıcının claimlerini bulunur ve orada bir JWT üretilir.
        //Daha sonra onlar burada görülen CreateToken' a gönderilir.
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims); //User için Token üretecek mekanizma, Token içerisinde OperationClaim yetkilendirilmesi yapıldı

    }
}
