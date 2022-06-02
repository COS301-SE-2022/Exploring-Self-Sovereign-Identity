using ExploringSelfSovereignIdentityAPI.Models.Entity;
using MediatR;

namespace ExploringSelfSovereignIdentityAPI.Queries.ConnectEndpoint
{
    public class ConnectEndpointGetUserDataQuery
    {
        public record ConnectEndpointGetDataQuery : IRequest<UserDataModel>
        {

        }

    }
}
