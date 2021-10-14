using Microsoft.AspNetCore.Mvc;
using Personal.Data;
using Personal.Models;
namespace Personal.Controllers.Work
{
    public partial class WorkController : Controller
    {
      
        private readonly SQLiteContext _myDbContext = new();
        public ActionResult SQLite()
        {
            ViewBag.Title = "SQLite WebForm";
            var model = new SQLiteModel
            {
                Visitantes = _myDbContext.Visitantes.OrderByDescending(v => v.Fecha).Take(50).ToList()
            };
            return View(model);
        }
        public async Task<JsonResult> SQLiteAgregarVisitante(string id)
        {
            //This function is called in a fecth
            if (id != null)
            {
                if (id.Length > 50) //chop chop chop      
                    id = id.Substring(0, 50);

                var respuesta = new ResultObject { OK = false, Name = id };

                try
                {
                    var visita = new Visitante
                    {
                        Nombre = id,
                        Fecha = DateTime.Now,
                        Id = respuesta.GUID
                    };
                    _myDbContext.Visitantes.Add(visita);
                    await _myDbContext.SaveChangesAsync();
                    respuesta.OK = true;
                    respuesta.Attributes.Add("Fecha", visita.Fecha.ToString());
                }
                catch
                {
                    respuesta.Name = "Error al guardar en la base de datos";
                }
                return Json(respuesta);
            }
            else
            {
                var respuesta = new ResultObject { OK = false, Name = "No ha especificador un nombre" };
                return Json(respuesta);
            }
        }
    }
}