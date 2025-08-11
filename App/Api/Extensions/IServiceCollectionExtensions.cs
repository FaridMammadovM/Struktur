using Application.Common.Exceptions;
using Application.Common.GeneralService;
using AutoMapper;
using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using Microsoft.AspNetCore.Diagnostics;
using Npgsql;
using System.Reflection;

namespace Api.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            var assemblyName = "AccessManagement.Api";
            var nameSpace = assemblyName;

            var asm = Assembly.Load(assemblyName);
            var classes = asm.GetTypes().Where(p => p.Namespace != null && p.Namespace.Contains(nameSpace) && p.BaseType == typeof(Profile)).ToList();

            var listOfProfiles = new List<Profile>();
            classes.ForEach(x => listOfProfiles.Add((Profile)Activator.CreateInstance(x)!));

            //services.AddSingleton(provider => new MapperConfiguration(cfg => { cfg.AddProfiles(listOfProfiles); }).CreateMapper());

            return services;
        }

        public static IServiceCollection AddCustomizedProblemDetails(this IServiceCollection services)
        {
            services.AddProblemDetails(opts =>
            {
                opts.IncludeExceptionDetails = (ctx, ex) =>
                {
                    var env = ctx.RequestServices.GetRequiredService<IHostEnvironment>();
                    return env.IsDev() || env.IsTest();
                };

                opts.MapStatusCode = (context) =>
                {
                    IExceptionHandlerFeature exceptionContext = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = context.Response.StatusCode;
                    string detail = string.Empty;
                    if (exceptionContext != null && exceptionContext.Error != null)
                    {
                        switch (exceptionContext.Error)
                        {
                            case ApiException ex:
                                statusCode = ex.StatusCode;
                                break;
                            case HttpResponseException ex:
                                statusCode = ex.StatusCode;
                                break;
                            case ValidationException ex:
                                statusCode = StatusCodes.Status400BadRequest;
                                detail = ex.GetValidationErrorMessage();
                                break;
                            case NpgsqlException ex:
                                statusCode = 500;
                                detail = ex.Message;
                                break;
                            default:
                                statusCode = 400;
                                detail = exceptionContext.Error.Message;
                                break;
                        }
                    }
                    return new GeneralResponse(statusCode, "Something went wrong !", detail: detail);
                };
            });

            return services;
        }

        public static string GetValidationErrorMessage(this ValidationException ex)
        {
            return string.Join(", ", ex.Errors.Select(e => e.ErrorMessage));
        }
    }
}
