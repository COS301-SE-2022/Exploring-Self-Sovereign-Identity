using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExploringSelfSovereignIdentityAPI.Controllers.Session
{
    internal class ConnectionEndpointGetDefaultIdentityQuerry : IRequest<IActionResult>
    {
    }
}