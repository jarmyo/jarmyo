using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Personal.Data;
using Personal.Models;
using System.IO;
using System.Text;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;

namespace Personal.Controllers
{
    public class WorkController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Titulo = "Portafolio";
            return View();
        }

        public JsonResult WebApiExample(string id)
        {
            var Respuesta = new ObjetoResultado();
            if (id != null)
            {
                Respuesta.Id = -1;
                Respuesta.OK = false;
                if (Int64.TryParse(id, out long result2))
                {
                    if (Int16.TryParse(id, out short result))
                    {
                        var ll = result * result;
                        Respuesta.Name = "El cuadrado de " + result + " es " + ll.ToString();
                        Respuesta.Id = result;
                        Respuesta.OK = true;
                    }
                    else
                    {
                        Respuesta.Name = "El valor no es un numero entero de 16Bits, debe ser mayor a " + Int16.MinValue.ToString() + " y menor que " + Int16.MaxValue.ToString();
                    }
                }
                else
                {
                    Respuesta.Name = "El valor no es un numero valido, validé con Int64.TryParse, puede que si sea un numero pero muy grande y pude provocar desbordamiento";
                }
            }
            else
            {
                Respuesta.OK = true;
                Respuesta.Id = 9876;
                Respuesta.Name = "Respuesta de Ejemplo, agrege un parametro de valor entero de 16Bits (WebApiExample/99) para obtener el cuadrado del numero ";
                Respuesta.Attributes.Add("Normalized", "true");
                Respuesta.Attributes.Add("Webfriendly", "true");
                Respuesta.Attributes.Add("NoTrash", "maybe");
            }

            return Json(Respuesta);
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

        public class ObjetoResultado
        {
            public ObjetoResultado()
            {
                GUID = Guid.NewGuid().ToString();
                Attributes = new Dictionary<string, string>();
            }
            public bool OK { get; set; }
            public string GUID { get; }
            public int Id { get; set; }
            public string Name { get; set; }
            public Dictionary<string, string> Attributes { get; set; }
        }
    }
}