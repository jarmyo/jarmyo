﻿using System;
using Microsoft.AspNetCore.Mvc;
namespace Personal.Controllers.Work
{
    public partial class WorkController : Controller
    {
        public JsonResult WebApiExample(string id)
        {
            var Respuesta = new ObjetoResultado();
            if (id != null)
            {
                Respuesta.Id = -1;
                Respuesta.OK = false;
                if (long.TryParse(id, out long result2))
                {
                    if (short.TryParse(id, out short result))
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
    }
}
