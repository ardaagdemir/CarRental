using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Core.Extensions;
using Core.Utilities.Security.Encryption;
using Core.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.JWT
{
    //6
    //JwtHelper oluşturulan mimari içerisindedir. Bu yüzden Configuration injection yapılabildi.
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }//appsettings.json' da verilen değerleri okumaya yarar(get)
        private TokenOptions _tokenOptions; //appsettings.json' da verilen değerleri tutar
        private DateTime _accessTokenExpiration; //token' ın geçersiz olacağı zamanı belirlemek için bir nesne üretildi

        public JwtHelper(IConfiguration configuration)
        {
            //Configuration, ASP.Net Web API' da bulunan appsettings.json dosyasını okumaya yarar.
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //Configuration.GetSection --> appsettings içindeki TokenOptions bölümünü al 
            //Get<TokenOptions> --> aldığın değerleri TokenOptions' a map'le

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims) //user ve operationClaims bilgilerinden bir Token oluşturmaya yarar.
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration); //Token' ın biteceği zamanı belirleyen kod satırı.
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); //securityKey değerine, TokenOptions' daki(appsettings.json) SecurityKey değerini kullan.
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey); //Hangi algoritmanın kullanacağının belirlendiği kısım.

            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims); //Ortaya bir tane jwt üretimi çıkacaktır. Buradaki 4 parametre daha önce oluşturulmuştu.
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler(); //CreateJwtSecurityToken' ı üretmek için
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, //Verilen parametre bilgileri verilerek bir adet JwtSecurityToken oluşturuldu.
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer, 
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now, //Şu andan önceli bir an için değer verilemez
                claims: SetClaims(user, operationClaims), //Kullanıcı claim'leri oluşturulurken aşağıda yardımcı bir metot oluşturulmuştur.
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        //Yukarıda kullanıcının kullanıcı bilgilerini ve claimlerini parametre alarak bir adet Claim listesi oluştur.
        //IEnumerable, List<>' in base' idir.
        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            //Var olan bir class'a yeni metotlar eklenebilir. Bunun adı 'Extension' (genişletmek)'dır.
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
