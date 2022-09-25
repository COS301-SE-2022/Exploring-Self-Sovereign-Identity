using ExploringSelfSovereignIdentityAPI.Models.Response;
using MediatR;

namespace ExploringSelfSovereignIdentityAPI.Models.Request
{
    public class RegisterRequest: IRequest<GetUserDataOutputDTO>
    {
        public string id { get; set; }
    }
}
