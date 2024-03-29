﻿namespace Personal.Controllers;
public partial class BlogController : Controller
{
    internal const int MaxPages = 10; //10 post by page
    internal static int TotalPost;
    internal static int TotalPages;
    private readonly BlogContext _blogCtx;
    private readonly SignInManager<IdentityUser> _signInManager;
    public BlogController(BlogContext blogCtx, SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager)
    {
        _signInManager = signInManager;
        _blogCtx = blogCtx;
    }
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
            Entradas = _blogCtx.Entradas.OrderByDescending(e => e.Fecha).Skip((currentPage - 1) * MaxPages).Take(MaxPages).ToList(),
            DisableBack = currentPage == 1,
            DisableFoward = currentPage == TotalPages,
            CurrentPage = currentPage,
            Etiquetas = _blogCtx.Etiquetas.ToList(),
        };

        var culture = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture;
        model.Archivo = new Dictionary<string, string>();
        foreach (var date in _blogCtx.Fechas)
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
            entrada = _blogCtx.Entradas.Find(id);
            ViewBag.Titulo = entrada.Titulo;
            return View(entrada);
        }
        else
            return NoContent();
    }
}