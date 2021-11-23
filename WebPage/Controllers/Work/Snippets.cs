using Microsoft.AspNetCore.Mvc;
namespace Personal.Controllers.Work
{
    public partial class WorkController : Controller
    {
        public ActionResult Snippets()
        {
            ViewBag.Titulo = "Snippets";
            return View();
        }
    }
}