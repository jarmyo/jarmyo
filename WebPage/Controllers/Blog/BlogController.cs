using Microsoft.AspNetCore.Authorization;
namespace Personal.Controllers
{
    public partial class BlogController : Controller
    {
        private readonly BlogContext blogCtx;
        public BlogController(BlogContext _blogCtx)
        {
            blogCtx = _blogCtx;
        }
        public ActionResult Index()
        {
            ViewBag.Titulo = "Blog";
            var model = new BlogIndexModel
            {
                //TODO: This can be slice, order and filter
                Entradas = blogCtx.Entradas.OrderByDescending(e => e.Fecha).ToList(),
                DisableBack = true,
                DisableFoward = false,            
                Etiquetas = blogCtx.Etiquetas.ToList(),
                Archivo = blogCtx.Fechas.ToList()
            };
            return View(model);
        }
    }
}