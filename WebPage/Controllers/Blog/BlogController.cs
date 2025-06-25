using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Globalization;
using System.Linq;

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
        if (!int.TryParse(id, out int currentPage) || currentPage < 1)
        {
            currentPage = 1;
        }
        else if (currentPage > TotalPages)
        {
            currentPage = TotalPages;
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
        model.Archivo = GetArchive(blogCtx.Fechas, culture);

        return View(model);
    }

    private Dictionary<string, string> GetArchive(IEnumerable<MonthYear> fechas, CultureInfo culture)
    {
        var archive = new Dictionary<string, string>();
        foreach (var (date, year, monthName) in from date in fechas
                                                let dateParts = date.Name.Split('-')
                                                let year = 2000 + int.Parse(dateParts[0])
                                                let month = new DateTime(year, int.Parse(dateParts[1]), 1)
                                                let monthName = month.ToString("MMMM", culture)
                                                select (date, year, monthName))
        {
            archive.Add(date.Name, $"{year}-{monthName}");
        }

        return archive;
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