using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Core.Utilities.Security.Encryption
{
    //3
    //Signing
    public class SigningCredentialsHelper
    {
        //Credentials = key..
        //SigningCredentials, Allows creation of JWT services
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey) 
        {
            //Hashing
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
