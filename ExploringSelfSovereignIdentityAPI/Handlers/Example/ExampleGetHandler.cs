using ExploringSelfSovereignIdentityAPI.Queries.Example;
using ExploringSelfSovereignIdentityAPI.Services.Example;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Handlers.Example
{
    public class ExampleGetHandler : IRequestHandler<ExampleGetQuery, string>   //Query and response type
    {
        private readonly IExampleService _service;

        public ExampleGetHandler(IExampleService service)
        {
            _service = service;
        }
        public async Task<string> Handle(ExampleGetQuery request, CancellationToken cancellationToken)
        {
            return await _service.Get();
        }
    }
}
