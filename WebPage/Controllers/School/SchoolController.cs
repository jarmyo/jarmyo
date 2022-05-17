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

            var selectedBusiness = _schoolCtx.Businesses.Where(b => b.Id == id);
            if (selectedBusiness.Any())
            {
                var model = new Models.School.SchoolAdminModel();
                model.Clients = _schoolCtx.Clients.ToList();
                model.Services = _schoolCtx.Services.ToList();
                ViewBag.Titulo = "Admin your Data";
                ViewBag.IdBusiness = id;
                return View(model);
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
        public IActionResult Clients([FromForm] Client client)
        {
            if (client.IdBusiness != null)
            {
                string resultMessage;
                try
                {
                    _schoolCtx.Clients.Add(client);
                    _schoolCtx.SaveChanges();
                    resultMessage = "ok";
                }
                catch (Exception e)
                {
                    resultMessage = e.Message;
                }
                return Json(new { result = resultMessage });

            }
            return NotFound();
        }
        [HttpDelete]
        public IActionResult Clients(string id)
        {
            var Matchingclients = _schoolCtx.Clients.Where(c => c.Id == id);
            string resultMessage;
            if (Matchingclients.Any())
            {
                var client = Matchingclients.First();
                _schoolCtx.Clients.Remove(client);
                _schoolCtx.SaveChanges();
                resultMessage = "ok";
            }
            else
            {
                resultMessage = "NotFound";
            }
            return Json(new { result = resultMessage });
        }

        [HttpPost]
        public IActionResult Appointments([FromBody] Appointment appointment)
        {
            return Json(_schoolCtx.Clients);
        }
        [HttpGet]
        public IActionResult Appointments()
        {
            return Json(_schoolCtx.Appointments);
        }
        [HttpDelete]
        public IActionResult Appointments(string id)
        {
            //delete the appointment
            var app = _schoolCtx.Appointments.Find(id);
            if (app != null)
            {
                _schoolCtx.Appointments.Remove(app);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        #endregion
    }
}
