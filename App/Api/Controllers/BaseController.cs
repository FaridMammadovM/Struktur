using Application.Common.GeneralService;
using Domain.General;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ?? (_mediator = base.HttpContext.RequestServices.GetService<IMediator>());

        protected GeneralResponse ReturnSuccess(object result, string successMessage = "Success", List<GeneralMessage> messages = null)
        {
            return new GeneralResponse(200, result, successMessage, null, null, messages);
        }

        protected GeneralResponse ReturnError(object result, string successMessage = "Error", int statusCode = 400, List<GeneralMessage> messages = null)
        {
            return new GeneralResponse(statusCode, result, successMessage, null, null, messages);
        }
    }
}
