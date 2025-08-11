using Application.Common.GeneralService;
using Application.Interfaces.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Extensions
{
    public class GeneralResponseFilter : IAsyncActionFilter
    {
        private readonly IService _hmsService;

        public GeneralResponseFilter(IService hmsService)
        {
            _hmsService = hmsService;
        }
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Code executed before the action method

            // Execute the action method
            var resultContext = await next();

            // Code executed after the action method

            // Modify the data in the response, if the response is successful and contains data
            if (resultContext.Result is ObjectResult objectResult && objectResult.Value is GeneralResponse customData)
            {
                customData.Messages = await _hmsService.ReadExceptionMessages();
            }
        }
    }

    public static class GeneralResponseFilterExtensions
    {
        public static void UseCustomExceptionHandler(this IServiceCollection services)
        {
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<GeneralResponseFilter>();
            });
        }
    }
}
