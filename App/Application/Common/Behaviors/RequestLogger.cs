using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviors
{
    public class RequestLogger<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly ILogger _logger;

        public RequestLogger(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            //var userId = JwtDefaultData.UserId;

            _logger.LogInformation("Request: {Name}, {@Request}", requestName, request);

            await Task.CompletedTask;
        }
    }
}
