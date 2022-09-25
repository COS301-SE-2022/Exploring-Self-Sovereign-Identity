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


    public class UpdateAtributesHandler : IRequestHandler<UserDataResponse, UserDataResponse>
    {

        private readonly IUserDataService _service;

        private UserDataResponse response = new UserDataResponse();

        public UpdateAtributesHandler(IUserDataService service)
        {
            _service = service;
        }
        public async Task<UserDataResponse> Handle(UserDataResponse request, CancellationToken cancellationToken)
        {

            for (int i = 0; i < request.Attributes.Count; i++)
            {

                if (i < response.Attributes.Count)
                {
                    response.Attributes[i].Name = request.Attributes[i].Name;
                    response.Attributes[i].Value = request.Attributes[i].Value;
                    continue;
                }

                Attribute a1 = new Attribute();
                a1.Name = request.Attributes[i].Name;
                a1.Value = request.Attributes[i].Value;

                response.Attributes.Add(a1);

            }

            return response;


        }
    }
}
