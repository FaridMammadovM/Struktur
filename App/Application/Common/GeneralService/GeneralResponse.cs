using Domain.General;
using Hellang.Middleware.ProblemDetails;

namespace Application.Common.GeneralService
{
    public class GeneralResponse : StatusCodeProblemDetails
    {
        public object Data { get; set; }

        public List<GeneralMessage> Messages { get; set; }

        public GeneralResponse(int statusCode, string title = null, string detail = null, string instance = null, List<GeneralMessage> messages = null)
            : base(statusCode)
        {
            base.Title = title;
            base.Detail = detail;
            base.Instance = instance;
            Messages = messages;
        }

        public GeneralResponse(int statusCode, object data, string title = null, string detail = null, string instance = null, List<GeneralMessage> messages = null)
            : base(statusCode)
        {
            Data = data;
            base.Title = title;
            base.Detail = detail;
            base.Instance = instance;
            Messages = messages;
        }
    }
}
