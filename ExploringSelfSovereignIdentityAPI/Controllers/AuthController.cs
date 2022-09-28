using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ExploringSelfSovereignIdentityAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly IMediator mediator;
        public AuthController(IMediator med)
        {
            mediator = med;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
