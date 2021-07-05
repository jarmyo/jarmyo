using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Personal.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personal.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogContext _DbContext = new();
        public BlogController()
        {
        }
        public ActionResult Index()
        {
            ViewBag.Titulo = "Blog Personal";
            var model = new Personal.Models.BlogIndexModel();
            model.Entradas = _DbContext.Entradas.OrderByDescending(e => e.Fecha).ToList();
            return View(model);
        }

        public ActionResult Entrada(string id)
        {
            if (id != null)
            {
                var entrada = _DbContext.Entradas.Find(id);
                return View(entrada);
            }
            else
                return NoContent();
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
