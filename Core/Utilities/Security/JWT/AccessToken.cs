using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    //4
    //Access Token = Erişim anahtarı
    //Anlamsız karakterlerden oluşan bir anahtar değeridir.
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; } //Sonlanacağı zaman bilgisi
    }
}
