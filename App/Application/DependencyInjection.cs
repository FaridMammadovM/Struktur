using Application.Common.Behaviors;
using Application.Common.Extension;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddScopedServices(Assembly.GetExecutingAssembly());

            BusinessInjection.AddScoped(services, Assembly.GetExecutingAssembly());
            HelperInjection.AddScoped(services, Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
