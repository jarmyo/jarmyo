namespace Personal.Controllers.School
{
    [Route("api/v2/[Controller]")]
    public class SchoolsController : Controller
    {
        private readonly SchoolContext _schoolCtx;
        //private readonly SignInManager<IdentityUser> _signInManager;
        //private const string IdDefaultBusinness = "juliansoft"; //for testing purpouses.
        public SchoolsController(SchoolContext schoolCtx/*, SignInManager<IdentityUser> signInManager*/)
        {
          //  _signInManager = signInManager;
            _schoolCtx = schoolCtx;
        }
        #region WebAPI    
        [HttpPost("Clients")]

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
        [HttpDelete("Clients/{id}")]
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
        [HttpGet("Clients")]
        public IActionResult Clients()
        {
            return Json(_schoolCtx.Clients.ToList());
        }

        [HttpPost("Appointments")]
        public IActionResult Appointments([FromBody] Appointment appointment)
        {
            return Json(_schoolCtx.Appointments);
        }
        [HttpGet("Appointments")]
        public IActionResult Appointments()
        {
            return Json(_schoolCtx.Appointments);
        }
        [HttpDelete("Appointments")]
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
