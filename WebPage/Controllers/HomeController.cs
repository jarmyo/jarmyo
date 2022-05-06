using Microsoft.Extensions.Localization;
namespace Personal.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IStringLocalizer<HomeController> localizer)
        {
            _localizer = localizer;
        }
        private readonly IStringLocalizer<HomeController> _localizer;
        public ActionResult Index()
        {
            ViewBag.Titulo = _localizer["Title"];
            return View();
        }
        public ActionResult Error(string code)
        {
            ViewBag.Titulo = _localizer["Title"];
            ViewBag.Code = code;
            //TODO: handle diferent a notfound and a server errors.
            switch (code)
            {
                case "404":
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
            return View();
        }
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );
            return LocalRedirect(returnUrl);
        }
    }
}