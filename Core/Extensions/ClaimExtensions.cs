using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{
    //8
    public static class ClaimExtensions
    {
        //Bir extension yazabilmek için hem metodun hem de class' ın static olması zorunludur.
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            //this keyword' ü, ICollection<Calim>(.Net içerisindeki hazır nesneler) içerisine extend etmek genişletmek anlamına gelir. Yani burada string tipinde bir email değişkeni ekle anlamına gelmektedir.
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }

        //Gönderilen rolleri Listeye çevir, tek tek dolaş ve claim' e ekle.
        public static void AddRoles(this ICollection<Claim> claims, string[] roles) 
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
