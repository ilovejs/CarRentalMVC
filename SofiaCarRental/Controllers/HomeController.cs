using System.Web.Mvc;

namespace SofiaCarRental.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult About()
        {
            return View();
        }
    }
}
