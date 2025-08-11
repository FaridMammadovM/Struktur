using Application.Common.Exceptions;
using Application.Interfaces.IService;
using Domain.General;
using Microsoft.AspNetCore.Http;

namespace Application.Common.GeneralService
{
    public class JwtService : IJwtService
    {
        private readonly IHttpContextAccessor httpContextAccessor;

        public JwtService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        public int GetHospitalId()
        {
            int.TryParse(httpContextAccessor.HttpContext.Items["hospital_id"].ToString(), out var result);
            return result;
        }

        public int? GetSubHospitalId()
        {
            if (httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.Items["sub_hospital_id"] != null)
            {
                int.TryParse(httpContextAccessor.HttpContext.Items["sub_hospital_id"].ToString(), out var result);
                return (result == 0) ? null : new int?(result);
            }

            return null;
        }

        public int GetLng()
        {
            if (httpContextAccessor.HttpContext != null && httpContextAccessor.HttpContext.Items["lng"] != null)
            {
                int.TryParse(httpContextAccessor.HttpContext.Items["lng"].ToString(), out var result);
                return (result == 0) ? 1 : result;
            }

            return 1;
        }

        public int GetUserId()
        {
            int.TryParse(httpContextAccessor.HttpContext.Items["user_id"].ToString(), out var result);
            return result;
        }

        public string GetUniqueName()
        {
            return httpContextAccessor.HttpContext.Items["unique_name"]?.ToString();
        }

        public string GetServiceName()
        {
            return httpContextAccessor.HttpContext.Items["service_name"]?.ToString();
        }

        public string GetToken()
        {
            return httpContextAccessor.HttpContext.Items["jwt_token"].ToString();
        }

        public List<GeneralMessageItem> GetMessages()
        {
            if (!(httpContextAccessor.HttpContext.Items["messages"] is List<GeneralMessageItem> result))
            {
                return new List<GeneralMessageItem>();
            }

            return result;
        }

        public void AddMessage(int messageCode, params string[] formatParameters)
        {
            List<GeneralMessageItem> list = httpContextAccessor.HttpContext.Items["messages"] as List<GeneralMessageItem>;
            if (formatParameters.Any())
            {
                list.Add(new GeneralMessageItem(messageCode, formatParameters.ToList()));
            }
            else
            {
                list.Add(new GeneralMessageItem(messageCode));
            }

            httpContextAccessor.HttpContext.Items["messages"] = list;
        }

        public void ThrowException(int messageCode, params string[] formatParameters)
        {
            AddMessage(messageCode, formatParameters);
            throw new BadRequestException();
        }
    }
}
