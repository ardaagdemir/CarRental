using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;


namespace Business.Concrete
{
    //AuthService -->  Kayıt olmak, giriş yapmak, çıkış yapmak, token üreterek istekte bulunmak gibi operasyonlardan sorumludur.
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        //Cons
        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        
        //Kullanıcıdan Dto ve password alınmalıdır.
        //Dto' da FirstName, LastName, Email ve password bulunmaktadır.
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            //Öncelikle veritabanına bu veriyi gönderebilmek için passwordHash ve passwordSalt' ı kullanarak hash(CreatePasswordHash) oluşturulmalıdır.
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserAdded);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto, string password)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck.Data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck.Data, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var operationClaims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, operationClaims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }
    }
}
