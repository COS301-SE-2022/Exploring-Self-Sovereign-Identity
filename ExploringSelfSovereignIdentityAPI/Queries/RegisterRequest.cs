using ExploringSelfSovereignIdentityAPI.Models.Response;
using MediatR;

namespace ExploringSelfSovereignIdentityAPI.Queries
{
    public class RegisterRequest: IRequest<GetUserDataOutputDTO>
    {
        public string id { get; set; }
    }
}
