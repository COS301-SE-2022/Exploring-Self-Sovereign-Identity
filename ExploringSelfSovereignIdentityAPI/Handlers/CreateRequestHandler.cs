using ExploringSelfSovereignIdentityAPI.Commands;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Handlers
{

    public class CreateRequestHandler : IRequestHandler<CreateRequestCommand, string>
    {
        private readonly IUserDataService _service;

        public CreateRequestHandler(IUserDataService service)
        {
            _service = service;
        }
        public async Task<string> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
        {

            return await _service.createUser(request.id);
      
        }
    }
}
