using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExploringSelfSovereignIdentityAPI.Controllers
{
    public class userDataModelController : Controller
    {
        // GET: userDataModelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: userDataModelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: userDataModelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: userDataModelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: userDataModelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: userDataModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: userDataModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: userDataModelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
