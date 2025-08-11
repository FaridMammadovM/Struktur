using Application.Common.GeneralService;
using Application.CQRS.Query.Test;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : BaseController
    {
        [HttpGet("Test")]
        public async Task<ActionResult<GeneralResponse>> Test()
        {
            GeneralResponse response = new GeneralResponse(
            statusCode: StatusCodes.Status200OK,
            data: null,
            title: "Uğurlu",
            detail: "Test API çalışır"
            );

            return Ok(response);
        }


        [HttpGet("GetTest")]
        public async Task<ActionResult<GeneralResponse>> GetTest()
        {
            TestQuery test = new TestQuery();
            var response = await Mediator.Send(test);

            return Ok(response);
        }
    }
}
