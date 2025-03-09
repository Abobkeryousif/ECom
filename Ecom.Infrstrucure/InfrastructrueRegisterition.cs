using Ecom.Core.Interface;
using Ecom.Core.Services;
using Ecom.Infrstrucure.Data;
using Ecom.Infrstrucure.Repositories;
using Ecom.Infrstrucure.Repositories.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Infrstrucure
{
    public static class InfrastructrueRegisterition 
    {
        
        public static IServiceCollection InfrastructrueConfig(this IServiceCollection services , IConfiguration configuration) 
        {
            services.AddScoped(typeof(IGenreicRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IImageService,ImageService>();
            services.AddDbContext<ApplicationDbContext>(o=> o.UseSqlServer(configuration.GetConnectionString("Default")));
            return services;
        }
    }
}
