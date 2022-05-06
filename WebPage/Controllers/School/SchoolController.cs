namespace Personal.Controllers.School
{
    public class SchoolController : Controller
    {
        private readonly SchoolContext _schoolCtx;
        private readonly SignInManager<IdentityUser> _signInManager;
        private const string IdDefaultBusinness = "juliansoft"; //for testing purpouses.
        public SchoolController(SchoolContext schoolCtx, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _schoolCtx = schoolCtx;
        }
        #region Views
        public IActionResult Index()
        {
            ViewBag.Titulo = "School Project";
            return View();
        }
        public IActionResult Admin(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = IdDefaultBusinness;

            var selectedBusiness = _schoolCtx.Businesses.Where(b=> b.Id == id);
            if (selectedBusiness.Any())
            {
                ViewBag.Titulo = "Admin your Appointments";
                return View();
            }
            return NotFound();
        }
        public IActionResult New(string id)
        {
            if (string.IsNullOrEmpty(id))
                id = IdDefaultBusinness;

            //Search for the id and send to sessión.

            ViewBag.Titulo = "Create a new appointment";
            return View();
        }
        #endregion

        #region WebAPI
        [HttpPost]
        public IActionResult CreateAppointment()
        {
            return Json(new { result="OK" });
        }
        [HttpGet]
        public IActionResult Appointments()
        {
            return Json(new { result = "OK" });
        }
        #endregion
    }
}
