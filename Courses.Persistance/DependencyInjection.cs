using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Interfaces;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Tasogarewa.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services,IConfiguration configuration) 
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<TasogarewaDbContext>(options =>
            options.UseSqlServer(connectionString).UseLazyLoadingProxies()
            );
            services.AddScoped<ITasogarewaDbContext>(provider=>
            provider.GetService<TasogarewaDbContext>());
            return services;
        }
    }
}
