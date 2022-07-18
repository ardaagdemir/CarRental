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
    //7
    
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }//get --> reads data from appsettings.json
        private TokenOptions _tokenOptions; //keeps the values ​​given in appsettings.json
        private DateTime _accessTokenExpiration; 

        public JwtHelper(IConfiguration configuration)
        {
            //Configuration --> reads appsettings.json file.
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>(); //Configuration.GetSection --> appsettings(TokenOptions)
            //Get<TokenOptions> --> TokenOptions -> mapping

        }
        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims) 
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration); 
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey); 
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey); 
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };

        }

        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, User user, 
            SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer, 
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now, 
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        
        private List<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(oc => oc.Name).ToArray());

            return claims;
        }
    }
}
