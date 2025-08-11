using Api.Extensions;

namespace Api.Extensions
{
    public static class CorsExtensions
    {
        public static void AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
            }));
        }

        public static void AddCorsPolicy(this WebApplication app)
        {
            app.UseCors("CorsPolicy");
        }
    }
}
