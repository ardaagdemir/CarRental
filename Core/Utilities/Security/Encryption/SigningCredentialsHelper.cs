using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    //İmzalama
    public class SigningCredentialsHelper
    {
        //Credentials = anahtar..
        //SigningCredentials, JWT servislerinin (WepApi ' ın kullanabileceği) oluşturulabilmesi için credentials(kullanıcı adı, parola..) oluşturmaya yarar.
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) 
        {
            //SecurityKey' in imazalama nesnesini döndürmeye yarar
            //Bir hashleme işlemi yapılacaktır.
            //Anahtar olarak securityKey parametresini kullan, şifreleme(algoritma) olarak da güvenlik algoritmalarından HmacSha512' yi kullan.
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
