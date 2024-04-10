namespace Personal.Controllers.Work
{
    public partial class WorkController(IScopedService scoped, ISingletonService singleton) : Controller
    {
        readonly IScopedService _scopedService = scoped;
        readonly ISingletonService _singletonService = singleton;

        public ActionResult Index()
        {            
            ViewBag.Titulo = "Work";
            return View();
        }
    }
}