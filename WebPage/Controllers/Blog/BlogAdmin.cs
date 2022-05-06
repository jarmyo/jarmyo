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
                entrada = _blogCtx.Entradas.Find(id);
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
            BlogHelper.Configure(_blogCtx);
            Post OriginalPost = new();
            if (formData.IsUpdate) OriginalPost = _blogCtx.Entradas.Find(formData.Id); //find original if update
            //map 
            OriginalPost.Id = formData.Id;
            OriginalPost.Fecha = DateTime.Parse(formData.Fecha);
            OriginalPost.Titulo = formData.Titulo;
            OriginalPost.Contenido = formData.Contenido;
            OriginalPost.Etiquetas = formData.Etiquetas.Trim().ToLower();
            BlogHelper.ProcessDates(OriginalPost.Fecha, OriginalPost.Id);
            BlogHelper.ProcessTags(OriginalPost.Etiquetas, OriginalPost.Id);
            // end map
            if (!formData.IsUpdate) _blogCtx.Entradas.Add(OriginalPost); //add if new
            _blogCtx.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult DeleteTag(string id)
        {
            try
            {
                if (id != null)
                {
                    var tag = _blogCtx.Etiquetas.Find(id);
                    _blogCtx.Etiquetas.Remove(tag);
                }
                else
                {
                    _blogCtx.Etiquetas.Remove(_blogCtx.Etiquetas.First(t => t.Name == string.Empty));
                }
                _blogCtx.SaveChanges();
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
                var entrada = _blogCtx.Entradas.Find(id);
                _blogCtx.Entradas.Remove(entrada);
                _blogCtx.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Logoff()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }       
    }    
}