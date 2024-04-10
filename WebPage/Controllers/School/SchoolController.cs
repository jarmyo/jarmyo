namespace Personal.Controllers.School
{
    public class SchoolController(SchoolContext schoolCtx, SignInManager<IdentityUser> signInManager) : Controller
    {
        private readonly SchoolContext _schoolCtx = schoolCtx;
        private readonly SignInManager<IdentityUser> _signInManager = signInManager;
        private const string IdDefaultBusinness = "juliansoft"; //for testing purpouses.
        #region Views       
        public ActionResult Index()
        {
            ViewBag.Titulo = "School Project";
            return View();
        }
        public IActionResult Admin(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = IdDefaultBusinness;

            var selectedBusiness = _schoolCtx.Businesses.Where(b => b.Id == id);
            if (selectedBusiness.Any())
            {
                var model = new Models.School.SchoolAdminModel
                {
                    Clients = [.. _schoolCtx.Clients],
                    Services = [.. _schoolCtx.Services]
                };
                ViewBag.Titulo = "Admin your Data";
                ViewBag.IdBusiness = id;
                return View(model);
            }
            return NotFound();
        }
        public IActionResult New(string id)
        {
            if (string.IsNullOrEmpty(id))
                _ = IdDefaultBusinness;

            //Search for the id and send to sessión.
            ViewBag.Titulo = "Create a new appointment";
            return View();
        }
        #endregion
    }
}