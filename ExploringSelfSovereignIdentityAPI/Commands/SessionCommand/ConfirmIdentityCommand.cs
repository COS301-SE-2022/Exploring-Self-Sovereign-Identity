using ExploringSelfSovereignIdentityAPI.Models.Response;
using MediatR;

namespace ExploringSelfSovereignIdentityAPI.Commands.SessionCommand
{
    public class ConfirmIdentityCommand: IRequest<DefaultIdentityResponse>
    {
    }
}
