using Microsoft.AspNetCore.Mvc;

namespace Personal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Titulo = "Inicio";
            return View();
        }
    }
}