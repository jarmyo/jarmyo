namespace Personal;
public static class BlogHelper
{
    private static BlogContext blogCtx;
    public static void Configure(BlogContext _blogCtx)
    {
        blogCtx = _blogCtx;
    }
    /// <summary>
    /// Converts string to tag registries and map to the post entries
    /// </summary>
    /// <param name="etiquetas">Input string to convert</param>
    /// <param name="idPost">Id of post entry</param>
    public static void ProcessTags(string etiquetas, string idPost)
    {
        var usedTags = new HashSet<string>(
            etiquetas.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(tag => tag.Trim())
            .Where(tag => !string.IsNullOrEmpty(tag))
        );

        // Crear etiquetas que no existen
        var newTags = usedTags.Where(tag => !blogCtx.Etiquetas.Any(t => t.Name == tag)).ToList();
        foreach (var tag in newTags)
        {
            blogCtx.Etiquetas.Add(new Tag { Name = tag });
        }

        // Crear relaciones de etiquetas con entradas que no existen
        var newTagEntries = usedTags
            .Where(tag => !blogCtx.EtiquetasEntradas.Any(et => et.Tag == tag && et.IdPost == idPost))
            .Select(tag => new PostTags { IdPost = idPost, Tag = tag })
            .ToList();

        blogCtx.EtiquetasEntradas.AddRange(newTagEntries);

        // Eliminar etiquetas no utilizadas
        var unusedTagEntries = blogCtx.EtiquetasEntradas
            .Where(et => et.IdPost == idPost && !usedTags.Contains(et.Tag));

        blogCtx.EtiquetasEntradas.RemoveRange(unusedTagEntries);
        blogCtx.SaveChanges();
    }
    /// <summary>
    /// Creates (if doesn't exist) a date entry on DB and maps to Post
    /// </summary>
    /// <param name="date">Date of post</param>
    /// <param name="idPost">Id of post</param>
    public static void ProcessDates(DateTime date, string idPost)
    {
        var dateName = date.ToString("yy-M");
        if (!blogCtx.Fechas.Any(d => d.Name == dateName))
        {
            blogCtx.Fechas.Add(new MonthYear() { Name = dateName });
            blogCtx.SaveChanges();
        }

        var postEntry = blogCtx.FechasEntradas.Find(idPost);
        if (postEntry != null)
        {
            postEntry.IdMonthYear = dateName;
        }
        else
        {
            blogCtx.FechasEntradas.Add(new PostMonthYear
            {
                IdPost = idPost,
                IdMonthYear = dateName
            });
        }
        blogCtx.SaveChanges();
    }
    /// <summary>
    /// this method is to read from XML blogspot history and creates local registry.
    /// </summary>
    public static void Importar()
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
    }
}