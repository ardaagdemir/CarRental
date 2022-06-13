using Business.Abstract;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;


namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var result = _authService.Login(userForLoginDto, userForLoginDto.Password);
            if (!result.Success) return BadRequest(result);

            var createAccessTokenResult = _authService.CreateAccessToken(result.Data);
            if (!result.Success) return BadRequest(result);

            var newSuccessDataResult = new SuccessDataResult<AccessToken>(createAccessTokenResult.Data, result.Message);
            return Ok(newSuccessDataResult);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            //var userExists = _authService.UserExists(userForRegisterDto.Email);
            //if (!userExists.Success)
            //{
            //    return BadRequest(userExists.Message);
            //}

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (result.Success)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Success);
            
            
        }
    }
}
