using ExploringSelfSovereignIdentityAPI.Models.Default;
using MediatR;

namespace ExploringSelfSovereignIdentityAPI.Commands.SessionCommand
{
    public class GetDefaultSessionCommand : IRequest<DefaultSessionModel>
    {
        public short SessionId { get; set; }

        public GetDefaultSessionCommand(short sessionId)
        {
            SessionId = sessionId;
        }
    }
}
