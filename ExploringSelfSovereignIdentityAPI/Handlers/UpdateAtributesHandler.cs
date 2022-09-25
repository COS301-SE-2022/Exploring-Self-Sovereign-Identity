using ExploringSelfSovereignIdentityAPI.Commands;
using ExploringSelfSovereignIdentityAPI.Models.Response;
using ExploringSelfSovereignIdentityAPI.Services.NetheriumBlockChain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using ExploringSelfSovereignIdentityAPI.Models.Entity;
using Attribute = ExploringSelfSovereignIdentityAPI.Models.Entity.Attribute;

namespace ExploringSelfSovereignIdentityAPI.Handlers
{
    public class UpdateAtributesHandler
    {
    }

    public class UpdateAtributesHandler : IRequestHandler<UpdateGen2, UserDataResponse>
    {

        private readonly IUserDataService _service;

        private UserDataResponse response = new UserDataResponse();

        public UpdateAtributesHandler(IUserDataService service)
        {
            _service = service;
        }
        public async Task<UserDataResponse> Handle(UserDataResponse request, CancellationToken cancellationToken)
        {




        }
    }
}
