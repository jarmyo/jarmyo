namespace Personal.Controllers
{
    [Authorize]
    public partial class BlogController : Controller
    {
        public ActionResult Admin() => View();
        public ActionResult New() => RedirectToAction("Edit");
        [HttpGet]
        public ActionResult Edit(string id)
        {
            Post entrada = new();
            ViewBag.IsUpdate = id != null;
            if (ViewBag.IsUpdate)
            {
                ViewBag.Title = "Update Post"; //TRANSLATE
                ViewBag.ButtonCaption = "Update";
                entrada = blogCtx.Entradas.Find(id);
            }
            else
            {
                ViewBag.Title = "New Post"; //TRANSLATE:
                ViewBag.ButtonCaption = "Publish";
                entrada.Fecha = DateTime.Now;
                entrada.Id = Guid.NewGuid().ToString();
            }
            return View(entrada);
        }
        [HttpPost]
        public ActionResult Edit(BlogPostEntry formData)
        {
            Post OriginalPost = new();
            if (formData.IsUpdate) OriginalPost = blogCtx.Entradas.Find(formData.Id); //find original if update
            //map 
            OriginalPost.Id = formData.Id;
            OriginalPost.Fecha = DateTime.Parse(formData.Fecha);
            OriginalPost.Titulo = formData.Titulo;
            OriginalPost.Contenido = formData.Contenido;
            OriginalPost.Etiquetas = formData.Etiquetas.Trim().ToLower();
            ProcessDates(OriginalPost.Fecha, OriginalPost.Id);
            ProcessTags(OriginalPost.Etiquetas, OriginalPost.Id);
            // end map
            if (!formData.IsUpdate) blogCtx.Entradas.Add(OriginalPost); //add if new
            blogCtx.SaveChanges();
            return RedirectToAction("Index");
        }
        private void ProcessTags(string etiquetas, string idPost)
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
                if (!blogCtx.EtiquetasEntradas.Any(et => et.Tag == trimmedTag && et.IdPost == idPost))
                {
                    blogCtx.EtiquetasEntradas.Add(new PostTags() { IdPost = idPost, Tag = trimmedTag });
                    blogCtx.SaveChanges();
                }
            }
            //then remove unused tags.
            var unused = blogCtx.EtiquetasEntradas.Where(et => et.IdPost == idPost && !usedTags.Contains(et.Tag));
            blogCtx.EtiquetasEntradas.RemoveRange(unused);
            //save
            blogCtx.SaveChanges();
        }
        private void ProcessDates(DateTime Date, string idPost)
        {
            var datename = Date.ToString("yy-M");
            if (!blogCtx.Fechas.Any(d => d.Name == datename))
            {
                blogCtx.Fechas.Add(new MonthYear() { Name = datename });
                blogCtx.SaveChanges();
            }

            var post = blogCtx.FechasEntradas.Find(idPost);
            if (post != null)
            {
                post.IdMonthYear = datename;
            }
            else
            {
                blogCtx.FechasEntradas.Add(new PostMonthYear
                {
                    IdPost = idPost,
                    IdMonthYear = datename
                });
            }
            blogCtx.SaveChanges();
        }
        public IActionResult DeleteTag(string id)
        {
            try
            {
                var tag = blogCtx.Etiquetas.Find(id);
                blogCtx.Etiquetas.Remove(tag);
                blogCtx.SaveChanges();
                return Json("ok");
            }
            catch (Exception ex)
            {
                return Json("fail" + ex.Message);
            }
        }
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
        public IActionResult Logoff()
        {
            _signInManager.SignOutAsync();
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
