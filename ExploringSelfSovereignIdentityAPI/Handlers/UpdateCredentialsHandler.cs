using ExploringSelfSovereignIdentityAPI.Models.Request;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Handlers
{
    public class UpdateCredentialsHandler : IRequestHandler<UpdateGen2, GetUserDataOutputDTO>
    {

        private readonly IUserDataService _service;

        public UpdateCredentialsHandler(IUserDataService service)
        {
            _service = service;
        }
        public async Task<GetUserDataOutputDTO> Handle(UpdateGen2 request, CancellationToken cancellationToken)
        {
            
            return await _service.updateUserData(request);
        }
    }
}
