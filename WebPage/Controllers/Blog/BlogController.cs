namespace Personal.Controllers
{
    public partial class BlogController : Controller
    {
        internal const int MaxPages = 10; //10 post by page
        internal static int TotalPost;
        internal static int TotalPages;
        private readonly BlogContext blogCtx;
        public BlogController(BlogContext _blogCtx)
        {
            blogCtx = _blogCtx;
        }
        [AllowAnonymous]
        public ActionResult Index(string id)
        {
            ViewBag.Titulo = "Blog";
            int currentPage = 1;
            if (id != null)
            {
                _ = int.TryParse(id, out currentPage);
            }

            var model = new BlogIndexModel
            {
                //TODO: This can be slice, order and filter
                Entradas = blogCtx.Entradas.OrderByDescending(e => e.Fecha).ToList(),
                DisableBack = currentPage == 1,
                DisableFoward = currentPage == TotalPages,
                CurrentPage = currentPage,
                Etiquetas = blogCtx.Etiquetas.ToList(),
                Archivo = blogCtx.Fechas.ToList()
            };
            return View(model);
        }
    }
}