using Application.Interfaces.IService;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.Common.Extension
{
    public static class BusinessInjection
    {
        public static void AddScoped(IServiceCollection services, Assembly assembly)
        {
            Type markerInterface = typeof(IBusinessInjection);
            List<Type> list = (from type in assembly.GetTypes()
                               where markerInterface.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract
                               select type).ToList();
            foreach (Type item in list)
            {
                services.AddScoped(item);
            }
        }
    }
}
