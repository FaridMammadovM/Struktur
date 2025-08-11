using Application.Common.Extension;
using Application.Common.GeneralService;
using Application.Interfaces.ICommon;
using Application.Interfaces.IService;
using Infrastructure.DB;
using Infrastructure.Persistence;
using Infrastructure.Persistence.CommonRepository;
using Infrastructure.Service.Internal;
using Infrastructure.Service.Transaction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDbConnectionFactory>(x => new DbConnectionFactory(configuration.GetConnectionString("ConnectionString")));

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("ConnectionString"));
            });

            services.AddScopedServices(Assembly.GetExecutingAssembly());
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<TransactionHandler>();
            //ef repo 
            services.AddScoped<IGenericEfRepository, GenericEfRepository>();
            services.AddScoped<ICommonRepository, CommonRepository>();

            return services;
        }
    }
}
