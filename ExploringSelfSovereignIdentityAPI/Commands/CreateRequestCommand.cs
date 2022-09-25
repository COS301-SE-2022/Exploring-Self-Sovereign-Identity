using MediatR;

namespace ExploringSelfSovereignIdentityAPI.Commands
{

    public class CreateRequestCommand : IRequest<string>
    {
        public string id { get; set; }
    }
}
