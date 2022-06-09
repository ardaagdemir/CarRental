using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    //2
    //Şifreleme olan sistemlerde her şeyin bir byte[] formatında olması gerekmektedir.
    //Yani bunların ASP.Net' in JWT servislerinin anlayacağı hale getirilmesi gerekmektedir.
    public class SecurityKeyHelper
    {
        //WepApi - appsettings.json klasöründe JWT formatında yazmış olduğumuz SecurityKey burada kullanılmaktadır.
        public static SecurityKey CreateSecurityKey(string securityKey) //securityKey - parametre appsettings.json' daki SecurityKey' e karşılık gelen yazdığımız string ifadedir.
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); //Anahatarlar, simetrik ve asimetrik anahtar olarak ayrılmaktadır.
        }
    }
}
