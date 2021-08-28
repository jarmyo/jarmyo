using Microsoft.AspNetCore.Mvc;
namespace Personal.Controllers.Work
{
    public partial class WorkController : Controller
    {
        /// <summary>
        /// Square root API Service. Just to demostrate that i know how to use this.
        /// </summary>
        /// <param name="id">optional value </param>
        /// <returns>square root of given number</returns>
        public JsonResult WebApiExample(string id)
        {
            //TODO: traducir.
            //TODO: obtener propiedades del header.
            //TODO: controlar el numero maximo de solicitudes.
            var Respuesta = new ObjetoResultado();
            if (id != null)
            {
                Respuesta.Id = -1;
                Respuesta.OK = false;
                if (long.TryParse(id, out _))
                {
                    if (short.TryParse(id, out short numero))
                    {
                        var cuadrado = numero * numero;
                        Respuesta.Name = $"El cuadrado de {numero} es {cuadrado}";
                        Respuesta.Id = numero;
                        Respuesta.OK = true;
                    }
                    else
                    {
                        Respuesta.Name = $"El valor no es un numero entero de 16Bits, debe ser mayor a {short.MinValue} y menor que {short.MaxValue}";
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
            }
            Respuesta.Attributes.Add("scoped", _scopedService.GetID().ToString());
            Respuesta.Attributes.Add("singleton", _singletonService.GetID().ToString());
            return Json(Respuesta);
        }
    }
}
