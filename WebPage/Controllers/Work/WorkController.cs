namespace Personal.Controllers.Work
{
    public partial class WorkController : Controller
    {
        readonly IScopedService _scopedService;
        readonly ISingletonService _singletonService;
        public WorkController(IScopedService scoped, ISingletonService singleton)
        {
            _scopedService = scoped;
            _singletonService = singleton;
        }
        public ActionResult Index()
        {
            ViewBag.Titulo = "Work";
            return View();
        }
    }
}