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
    //JWT için SecuredOperation...
    public class SecuredOperation : MethodInterception
    {
        //_roles nesnesini string array olarak tut
        private string[] _roles;

        //JWT göndererek bir istek yapıldığında oraya aynı anda binlerce kişi istek yapılabilir.
        //Her istek yapan kişi işin ayrı ayrı HttpContext oluşur. 
        private IHttpContextAccessor _httpContextAccessor;


        //SecuredOperation bir Aspect olduğu için doğrudan bir injection yapamayız.
        //.Net' in Autofac ile oluşturulan servis mimarisine ulaşmak için aşağıdaki kodlar yazılmıştır.
        public SecuredOperation(string roles) 
        {
            _roles = roles.Split(','); //String bir metni ',' ile ayırarak array' a at.
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>(); //ServiceTool kullanılarak WinForms' da injection yapılabilmektedir.
            //ServiceTool geliştirilen mimarideki zincirin içerisinde yer almamaktadır.
            //Yani API' daki Controller, Business' ı tutar; Business, DAL' ı tutar, DAL ise Entity'leri tutar.
            //Bu katmanlı mimaride ServiceTool bulunmamaktadır. Buradaki dependency' leri yakalayabilmek için bir ServiceTool yazılır.
            //ServiceTool yazdığımız injection alt yapısını okuyabilmeye yarayan bir araç olacaktır.

        }

        //İlgili metodun önünde çalıştır. --> OnBefore
        //Kullanıcının claim rollerini bul(roleClaims), rolleri gez(foreach), eğer claimlerde ilgili role varsa(if) metodu çalıştırmaya devam et(return)
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
