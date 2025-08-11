using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Application.Common.Behaviors
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public RequestPerformanceBehaviour(
            ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();
            _logger = logger;
        }


        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds > 1000)
            {
                var requestName = typeof(TRequest).Name;
                //var userId = JwtDefaultData.UserId;

                _logger.LogWarning("Long Running Request detected: {Name} ({ElapsedMilliseconds} milliseconds), Request: {@Request}",
                    requestName, elapsedMilliseconds, request);
            }

            return response;
        }
    }
}

