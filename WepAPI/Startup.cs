using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Business.Concrete;
using Core.Extensions;
using Core.Utilities.DependencyResolvers;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;

namespace WepAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            //services.AddCors();

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                    };
                });

            //Ýstenilen her module buraya atanabilmektedir. Yalnýzca COreModule deðil bütün module' lar eklenebilir.
            //Kullanabilmek için bir extension oluþturulabilir. Core' da Extensions altýnda oluþturulmuþtur.
            //CoreModule gibi farklý module' lerde oluþturulduðunda buraya eklenebilir. Bu sayede baðýmlýlýklar çözümlenmiþ olur.
            services.AddDependencyResolvers(new ICoreModule[]
            {
                new CoreModule()
            });


            //ASP.Net Core Web API --- IoC(Inversion of Control)
            //.Net' in kendi IoC Container' ý bizim yerimize classlarý otomatik olarak new'ler.
            //Singleton--> Tüm bellekte bir adet CarManager oluþturur. Bütün instance'larý yaratmada kullanýr.
            //Singleton, içerisinde data tutulmayan operasyonlarda kullanýlýr. 
            //Bu new'lemeler Controller' da yeni bir new'leme yapýlmasýnýn önüne geçmektedir ve baðlýlýðý azaltmaktadýr.
            //AutofacBusinessModule' da üretilen instance'larýn WepApi' de tanýmlanabilmesi için WebApi' nin Program.cs' ine gidilir.

            //services.AddSingleton<ICarService,CarManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }

            //Middle wear --> ASP.Net yaþam döngüsünde hangi yapýlarýn hangi sýrayla devreye gireceðinin belirlendiði kýsýmdýr.
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseAuthorization(); 
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
