using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Personal.Data;
using Personal.Models;
namespace Personal.Controllers
{
    public partial class WorkController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Titulo = "Portafolio";
            return View();
        }
        private readonly SQLiteContext _myDbContext = new();
        public ActionResult SQLite()
        {
            var model = new SQLiteModel();
            model.Visitantes = _myDbContext.Visitantes.OrderByDescending(v => v.Fecha).Take(50).ToList();
            return View(model);
        }
        public async Task<JsonResult> SQLiteAgregarVisitante(string id)
        {
            if (id != null)
            {
                if (id.Length > 50) //chop chop chop      
                    id = id.Substring(0, 50);

                var respuesta = new ObjetoResultado { OK = false, Name = id };

                try
                {
                    var visita = new Visitante();
                    visita.Nombre = id;
                    visita.Fecha = DateTime.Now;
                    visita.Id = respuesta.GUID;
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
                var respuesta = new ObjetoResultado { OK = false, Name = "No ha especificador un nombre" };
                return Json(respuesta);
            }
        }
    }
}