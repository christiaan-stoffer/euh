using System.Web.Mvc;

namespace Euh.Web.Controllers
{
    public class HomeController : Controller
    {   
        public ActionResult Index()
        {
            return View();
        }
    }
}
