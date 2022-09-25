using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Queries;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Handlers
{

    public class RegisterRequestHandler : IRequestHandler<RegisterRequest, GetUserDataOutputDTO>   //Query and response type
    {
        private readonly IUserDataService _service;

        public RegisterRequestHandler(IUserDataService service)
        {
            _service = service;
        }
        public async Task<GetUserDataOutputDTO> Handle(RegisterRequest request, CancellationToken cancellationToken)
        {
            return await _service.getUserData(request.id);
        }

 
    }
}
