using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    //8
    //JWT-SecuredOperation
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;

        
        private IHttpContextAccessor _httpContextAccessor;


        //The SecuredOperation cannot be injected. Because SecuredOperation is a abstract class.
        public SecuredOperation(string roles) 
        {
            //Access to Autofac Service Architectural 
            _roles = roles.Split(',');
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        //OnBefore --> in front of
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
