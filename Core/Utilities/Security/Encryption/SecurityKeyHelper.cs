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
        //WepApi - appsettings.json klasöründe JWT formatında yazılan SecurityKey burada kullanılmaktadır.
        //Buradaki SecurityKey olarak dönen değer appsettings.json' daki belirlenen SecurityKey değeridir.
        public static SecurityKey CreateSecurityKey(string securityKey) //securityKey - appsetting.json' daki SecurityKey' e karşılık gelen değerdir.
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); //Anahatarlar, simetrik ve asimetrik anahtar olarak ayrılmaktadır.
        }
    }
}
