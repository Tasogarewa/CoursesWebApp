using Castle.Core.Configuration;
using Courses.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasogarewa.Application.Common;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Domain;
using Tasogarewa.Persistance.Common;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace Tasogarewa.Persistance
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services,IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<ITasogarewaDbContext,TasogarewaDbContext>(options =>
            options.UseSqlServer(connectionString,b=>b.MigrationsAssembly("CoursesWebAPI")).UseLazyLoadingProxies()
            );
            services.AddScoped<IRepository<Course>, Repository<Course>>();
            services.AddScoped<IRepository<Image>, Repository<Image>>();
            services.AddScoped<IRepository<Notification>, Repository<Notification>>();
            services.AddScoped<IRepository<Message>, Repository<Message>>();
            services.AddScoped<IRepository<Chat>, Repository<Chat>>();
            services.AddScoped<IRepository<AppUser>, Repository<AppUser>>();
            services.AddScoped<IRepository<Comment>, Repository<Comment>>();

            return services;
        }
    }
}
