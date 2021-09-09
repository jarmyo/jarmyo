using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personal.Data;
using System.Linq;

namespace Personal.Controllers
{
    public class BlogController : Controller
    {
        private readonly PersonalBlogContext personal = new();
        private readonly BlogContext blogCtx = new();
        public BlogController()
        {
        }
        public ActionResult Index()
        {
            ViewBag.Titulo = "Blog";
            var model = new Models.BlogIndexModel
            {
                Entradas = blogCtx.Entradas.OrderByDescending(e => e.Fecha).ToList()
            };
            return View(model);
        }

        public ActionResult Personal()
        {
            ViewBag.Titulo = "Blog Personal";
            var model = new Models.BlogIndexModel
            {
                Entradas = personal.Entradas.OrderByDescending(e => e.Fecha).ToList()
            };
            return View(model);
        }

        public ActionResult Entrada(string id)
        {
            if (id != null)
            {
                var entrada = personal.Entradas.Find(id);
                return View(entrada);
            }
            else
                return NoContent();
        }
        /// <summary>
        /// Crear un nuevo post.
        /// </summary>
        /// <returns></returns>        
        [Authorize]
        public ActionResult New()
        {
            //TODO: usar autorización y autenticación para publicar
            //Esto es un micro CMS
            return View();
        }
        public ActionResult Importar()
        {
            //Background:
            //Para importar el archivo xml-json- a este blog, debo guardarlos en la base de datos.

            //var json = System.IO.File.ReadAllText(Environment.WebRootPath + "/blogpost/xmltojson.json");
            //var data = System.Text.Json.JsonSerializer.Deserialize<Root>(json);
            //foreach (var ent in data.feed.entry)
            //{
            //    if (ent.author.name == "Shinji")
            //    {
            //        var cont = ent.content.ToString();

            //        if (cont.Contains("jarm.yo@gmail.com"))
            //        {
            //            _DbContext.Entradas.Add(new Post()
            //            {
            //                Id = Guid.NewGuid().ToString(),
            //                Fecha = ent.published,
            //                Titulo = ent.title,
            //                Contenido = ent.content.ToString()
            //            });
            //        }
            //    }
            //}

            // _DbContext.SaveChanges();
            return View();
        }
    }
}
