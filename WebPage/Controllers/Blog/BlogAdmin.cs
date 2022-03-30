namespace Personal.Controllers
{
    public partial class BlogController : Controller
    {
        [Authorize]
        [HttpGet]
        public ActionResult New() => RedirectToAction("Edit");
        [Authorize]
        [HttpGet]
        public ActionResult Edit(string id)
        {
            Post entrada = new();
            ViewBag.IsUpdate = id != null;
            if (ViewBag.IsUpdate)
            {
                ViewBag.Title = "Actualizar Entrada";
                ViewBag.ButtonCaption = "Actualizar";
                entrada = blogCtx.Entradas.Find(id);
            }
            else
            {
                ViewBag.Title = "Nueva Entrada";
                ViewBag.ButtonCaption = "Publicar";
                entrada.Fecha = DateTime.Now;
                entrada.Id = Guid.NewGuid().ToString();
            }
            return View(entrada);
        }
        [Authorize]
        [HttpPost]
        public ActionResult Edit(BlogPostEntry formData)
        {
            Post OriginalPost = new();
            if (formData.IsUpdate) OriginalPost = blogCtx.Entradas.Find(formData.Id); //find original if update
            //map 
            OriginalPost.Id = formData.Id;
            //TODO: Manage date index.
            OriginalPost.Fecha = DateTime.Parse(formData.Fecha);
            OriginalPost.Titulo = formData.Titulo;
            OriginalPost.Contenido = formData.Contenido;
            //TODO: manage tags
            OriginalPost.Etiquetas = formData.Etiquetas.Trim().ToLower();
            ProcessTags(OriginalPost.Etiquetas, OriginalPost.Id);
            // end map
            if (!formData.IsUpdate) blogCtx.Entradas.Add(OriginalPost); //add if new
            blogCtx.SaveChanges();
            return RedirectToAction("Index");
        }
        private void ProcessTags(string etiquetas, string id)
        {
            List<string> usedTags = new();
            foreach (var tags in etiquetas.Split(';'))
            {
                var trimmedTag = tags.Trim();
                usedTags.Add(trimmedTag);
                // create tag if not exist
                if (!blogCtx.Etiquetas.Any(t => t.Name == trimmedTag))
                {
                    blogCtx.Etiquetas.Add(new Tag() { Name = trimmedTag });
                    blogCtx.SaveChanges();
                }
                // now, check if has in the map.
                if (!blogCtx.EtiquetasEntradas.Any(et => et.Tag == trimmedTag && et.IdPost == id))
                {
                    blogCtx.EtiquetasEntradas.Add(new PostTags() { IdPost = id, Tag = trimmedTag });
                    blogCtx.SaveChanges();
                }
            }
            //then remove unused tags.
            var unused = blogCtx.EtiquetasEntradas.Where(et => et.IdPost == id && !usedTags.Contains(et.Tag));
            blogCtx.EtiquetasEntradas.RemoveRange(unused);
            //save
            blogCtx.SaveChanges();
        }
        [Authorize]
        public IActionResult Delete(string id)
        {
            if (id != null)
            {
                var entrada = blogCtx.Entradas.Find(id);
                blogCtx.Entradas.Remove(entrada);
                blogCtx.SaveChanges();
            }
            return RedirectToAction("Index");
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
