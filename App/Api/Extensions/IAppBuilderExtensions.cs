using Api.Extensions;

namespace Api.Extensions
{
    public static class IAppBuilderExtensions
    {
        public static IApplicationBuilder UseCors(this IApplicationBuilder builder, IConfiguration configuration)
        {
            builder.UseCors(builder =>
            {
                var origins = new List<string>();
                if (configuration.GetSection("Clients:Local").Exists())
                {
                    origins.Add(configuration.GetValue<string>("Clients:Local"));
                }

                if (configuration.GetSection("Clients:Remote").Exists())
                {
                    origins.Add(configuration.GetValue<string>("Clients:Remote"));
                }

                builder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins(origins.ToArray())
                    .AllowCredentials();
            });

            return builder;
        }
    }
}
