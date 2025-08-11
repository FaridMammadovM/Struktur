using Application.Interfaces.IService;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Common.Extension
{
    public static class CommonInjection
    {
        public static void AddScopedServices(this IServiceCollection services, Assembly assembly)
        {
            Type markerInterface = typeof(ICommonInjection);
            List<Type> list = (from type in assembly.GetTypes()
                               where markerInterface.IsAssignableFrom(type) && !type.IsInterface
                               select type).ToList();
            list.ForEach(delegate (Type type)
            {
                (from i in type.GetInterfaces()
                 where i != markerInterface
                 select i).ToList().ForEach(delegate (Type @interface)
                 {
                     services.AddScoped(@interface, type);
                 });
            });
        }
    }
}
