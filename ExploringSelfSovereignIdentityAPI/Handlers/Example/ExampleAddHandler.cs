using ExploringSelfSovereignIdentityAPI.Commands.Example;
using ExploringSelfSovereignIdentityAPI.Models.Example;
using ExploringSelfSovereignIdentityAPI.Services.Example;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Handlers.Example
{
    public class ExampleAddHandler : IRequestHandler<ExampleAddCommand, ExampleModel>
    {
        private readonly IExampleService _service;

        public ExampleAddHandler(IExampleService service)
        {
            _service = service;
        }
        public async Task<ExampleModel> Handle(ExampleAddCommand request, CancellationToken cancellationToken)
        {
            ExampleModel example = new ExampleModel(request.FieldA, request.FieldB);

            return await _service.Add(example);
        }
    }
}
