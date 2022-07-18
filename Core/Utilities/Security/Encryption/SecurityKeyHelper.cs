using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    //2
    //Everything must be in a byte format
    public class SecurityKeyHelper
    {
        
        public static SecurityKey CreateSecurityKey(string securityKey) //securityKey --> appsetting.json(SecurityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey)); //Keys are divided into symmetrical and asymmetrical keys.
        }
    }
}
