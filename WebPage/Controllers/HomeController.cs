using Microsoft.AspNetCore.Mvc;

namespace Personal.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Titulo = "Inicio";

           // var tv = new KeyVault.TextoAVoz();            
            //tv.Generar("¿Tu restaurante  está perdiendo mucho dinero en robos hormiga? Con alertas repós ¡controla y detén las fugas de dinero en tu negocio! Nuestros algoritmos analizan la actividad de tu restaurante y determinan si una cancelación, descuento, producto borrado o mesa transferida es un movimiento sospechoso o anormal en la operación, y envía una notificación en tiempo real a tu teléfono, para que puedas comunicarte a tu negocio y validar la información. Podrás estar atento a tu restaurante sin importar donde te encuentres. ¡No esperes a acumular más pérdidas! Haz crecer tu negocio con el sistema más avanzado para restaurantes.");
            return View();
        }
    }
}