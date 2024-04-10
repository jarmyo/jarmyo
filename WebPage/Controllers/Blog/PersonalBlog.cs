namespace Personal.Controllers;
public partial class BlogController : Controller
{
    private readonly PersonalBlogContext personal = new();
    [AllowAnonymous]
    public ActionResult Personal()
    {
        ViewBag.Titulo = "Blog Personal";
        var model = new Models.Blog.BlogIndexModel
        {
            Entradas = [.. personal.Entradas.OrderByDescending(e => e.Fecha)]
        };
        return View(model);
    }
    [AllowAnonymous]
    public ActionResult EntradaPersonal(string id)
    {
        Post entrada;
        if (id != null)
        {
            entrada = personal.Entradas.Find(id);
             
            return View("Entrada",entrada);
        }
        else
        {
            return NoContent();
        }
    }
}
