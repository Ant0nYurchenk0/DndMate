using System.Web.Mvc;

namespace DndMate.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Gamespace");
        }

    }
}