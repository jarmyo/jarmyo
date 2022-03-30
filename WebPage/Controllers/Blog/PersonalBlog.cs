namespace Personal.Controllers
{
    public partial class BlogController : Controller
    {
        private readonly PersonalBlogContext personal = new();
        public ActionResult Personal()
        {
            ViewBag.Titulo = "Blog Personal";
            var model = new BlogIndexModel
            {
                Entradas = personal.Entradas.OrderByDescending(e => e.Fecha).ToList()
            };
            return View(model);
        }
        public ActionResult Entrada(string id)
        {
            Post entrada;
            if (id != null)
            {
                entrada = personal.Entradas.Find(id);

                return View(entrada);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
