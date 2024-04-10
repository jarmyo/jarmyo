namespace Personal.Controllers;
public partial class BlogController(BlogContext blogCtx, SignInManager<IdentityUser> signInManager) : Controller
{
    internal const int MaxPages = 10; //10 post by page
    internal static int TotalPost;
    internal static int TotalPages;

    [AllowAnonymous]
    public ActionResult Index(string id)
    {
        ViewBag.Titulo = "Blog";
        int currentPage = 1;
        if (id != null)
        {
            _ = int.TryParse(id, out currentPage);
            if (currentPage < 1) currentPage = 1;
            else if (currentPage > TotalPages) currentPage = TotalPages;
        }

        var model = new Models.Blog.BlogIndexModel
        {
            //TODO: This can be slice, order and filter
            Entradas = [.. blogCtx.Entradas.OrderByDescending(e => e.Fecha).Skip((currentPage - 1) * MaxPages).Take(MaxPages)],
            DisableBack = currentPage == 1,
            DisableFoward = currentPage == TotalPages,
            CurrentPage = currentPage,
            Etiquetas = [.. blogCtx.Etiquetas],
        };

        var culture = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture;
        model.Archivo = [];
        foreach (var date in blogCtx.Fechas)
        {
            var dateparts = date.Name.Split('-');
            var year = 2000 + int.Parse(dateparts[0]);
            var month = new DateTime(year, int.Parse(dateparts[1]), 1);
            var monthName = month.ToString("MMMM", culture);
            //Localize date names
            model.Archivo.Add(date.Name, year + "-" + monthName);
        }

        return View(model);
    }
    [AllowAnonymous]
    public ActionResult Entrada(string id)
    {
        Post entrada;
        if (id != null)
        {
            entrada = blogCtx.Entradas.Find(id);
            ViewBag.Titulo = entrada.Titulo;
            return View(entrada);
        }
        else
            return NoContent();
    }
}