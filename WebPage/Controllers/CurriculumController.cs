using Microsoft.AspNetCore.Mvc;

namespace Personal.Controllers
{
    public class CurriculumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
