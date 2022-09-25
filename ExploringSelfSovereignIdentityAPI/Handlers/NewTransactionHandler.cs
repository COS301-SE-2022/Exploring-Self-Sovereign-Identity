using ExploringSelfSovereignIdentityAPI.Commands;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ExploringSelfSovereignIdentityAPI.Handlers
{
    public class NewTransactionHandler : IRequestHandler<TransactionRequest, string>
    {
        private readonly IUserDataService _service;

        public NewTransactionHandler(IUserDataService service)
        {
            _service = service;
        }
        public async Task<string> Handle(TransactionRequest request, CancellationToken cancellationToken)
        {

            return await _service.newTransactionRequest(request);
        }
    }
}
