using Personal.Helpers;
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
            var c = new CosmosDBHelper();
            ViewBag.Titulo = "Work";
            return View();
        }
    }
}