using ExploringSelfSovereignIdentityAPI.Models.Default;
using MediatR;

namespace ExploringSelfSovereignIdentityAPI.Commands.SessionCommand
{
    public class GetDefaultSessionCommand : IRequest<DefaultSessionModel>
    {
        //public short SessionId { get; set; }

        public string otp { get; set; }

        public GetDefaultSessionCommand(string otp)
        {
            this.otp = otp;
        }
    }
}
