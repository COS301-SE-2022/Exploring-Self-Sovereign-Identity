using ExploringSelfSovereignIdentityAPI.Models.Entity;
using MediatR;

namespace ExploringSelfSovereignIdentityAPI.Queries.ConnectEndpoint
{
    public class ConnectEndpointUpdateUserDataQuery
    {
        public record ConnectEndpointUpdateDataQuery : IRequest<UserDataModel>
        {

        }

    }
}

