using Application.Common.Exceptions;
using Application.Common.Extension;
using Application.Common.GeneralService;
using Application.Interfaces.IService;
using FluentValidation;


namespace Api.Extensions
{

    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IService externalService)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, externalService);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception, IService externalService)
        {
            int code = StatusCodes.Status500InternalServerError;
            string title = exception.Message;
            string detail = exception.InnerException?.Message;

            var result = string.Empty;

            switch (exception)
            {
                case ValidationException validationException:
                    code = StatusCodes.Status400BadRequest;
                    result = SerializerHelper.Serialize(validationException.Errors);
                    break;
                case NotFoundException _:
                    code = StatusCodes.Status404NotFound;
                    break;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            if (string.IsNullOrEmpty(result))
            {
                result = SerializerHelper.Serialize(new { error = exception.Message });
            }

            var messages = await externalService.ReadExceptionMessages();

            var response = new GeneralResponse(code, title, detail: detail, messages: messages);

            await context.Response.WriteAsync(SerializerHelper.Serialize(response));
        }
    }


    public static class CustomExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
