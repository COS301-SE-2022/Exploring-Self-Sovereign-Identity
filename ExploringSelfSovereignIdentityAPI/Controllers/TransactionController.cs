using Microsoft.AspNetCore.Mvc;

namespace ExploringSelfSovereignIdentityAPI.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
