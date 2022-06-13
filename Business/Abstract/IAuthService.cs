using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Login(UserForLoginDto userForLoginDto, string password);
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password);
        IDataResult<AccessToken> CreateAccessToken(User user);
        IResult UserExists(string email);
    }
}
