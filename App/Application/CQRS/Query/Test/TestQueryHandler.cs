using MediatR;

namespace Application.CQRS.Query.Test
{
    public class TestQueryHandler : IRequestHandler<TestQuery, string>
    {
        public async Task<string> Handle(TestQuery request, CancellationToken cancellationToken)
        {
            return "get";
        }
    }
}
