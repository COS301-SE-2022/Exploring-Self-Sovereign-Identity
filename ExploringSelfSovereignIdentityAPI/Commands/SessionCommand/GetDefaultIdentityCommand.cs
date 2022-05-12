using ExploringSelfSovereignIdentityAPI.Models.DefaultIdentity;
using MediatR;

namespace ExploringSelfSovereignIdentityAPI.Commands.SessionCommand
{
    public class GetDefaultIdentityCommand : IRequest<DefaultIdentityModel>
    {
        public DefaultIdentityModel identity;

        public GetDefaultIdentityCommand()
        {
            identity = new DefaultIdentityModel();
        }
    }
}
