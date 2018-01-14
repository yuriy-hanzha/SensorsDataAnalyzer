using System.Web.Mvc;

namespace SensorsDataAnalyzer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            // navigate to help page
            return RedirectToAction("Index", "Help");
        }
    }
}
