using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using MediatR;

namespace ExploringSelfSovereignIdentityAPI.Queries.ConnectEndpoint
{
    public class ConnectEndpointGetDefaultIdentityQuerry
    {
        public record ConnectEndpointGetIdentityQuerry : IRequest<DefaultIdentityModel>
        {

        }
    }
}
