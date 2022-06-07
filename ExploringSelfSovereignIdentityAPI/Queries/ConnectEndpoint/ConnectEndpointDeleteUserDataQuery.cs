using ExploringSelfSovereignIdentityAPI.Models.Entity;
using MediatR;

namespace ExploringSelfSovereignIdentityAPI.Queries.ConnectEndpoint
{
    public class ConnectEndpointDeleteUserDataQuery
    {
        public record ConnectEndpointDeleteDataQuery : IRequest<UserDataModel>
        {

        }

    }
}
