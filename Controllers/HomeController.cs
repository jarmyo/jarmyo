using Microsoft.AspNetCore.Mvc;

namespace Personal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}