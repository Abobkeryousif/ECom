using Ecom.Core.Interface;
using Ecom.Core.Services;
using Ecom.Infrstrucure.Data;
using Ecom.Infrstrucure.Repositories;
using Ecom.Infrstrucure.Repositories.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Ecom.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace Ecom.Infrstrucure
{
    public static class InfrastructrueRegisterition 
    {
        
        public static IServiceCollection InfrastructrueConfig(this IServiceCollection services , IConfiguration _configuration) 
        {
            services.AddScoped(typeof(IGenreicRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddSingleton<IConnectionMultiplexer>
            //    ( i => 
            //    {
                    
            //        var Config = ConfigurationOptions.Parse(_configuration.GetConnectionString("redis"));
            //        return ConnectionMultiplexer.Connect(Config);
            //    }
            //    );
            services.AddScoped<IGenretToken, GenretToken>();
            services.AddSingleton<IImageService,ImageService>();
            services.AddDbContext<ApplicationDbContext>(o=> o.UseSqlServer(_configuration.GetConnectionString("Default")));
            services.AddIdentity<UserApp, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            services.AddAuthentication(o=> 
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(x=> 
            {
                x.Cookie.Name = "Token";
                x.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    return Task.CompletedTask;
                };
            }).AddJwtBearer(op=> 
            {
                op.SaveToken = true;
                op.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:Key"])),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Token:Issure"],
                    ValidateAudience = false,

                };
                op.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context=> 
                    {
                        context.Token = context.Request.Cookies["Token"];
                        return Task.CompletedTask;
                    }
                };
            })
            ;
            ;
            return services;
        }
    }
}
