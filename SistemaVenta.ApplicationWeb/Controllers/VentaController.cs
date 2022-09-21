using Microsoft.AspNetCore.Mvc;

namespace SistemaVenta.ApplicationWeb.Controllers
{
    public class VentaController: Controller
    {
        public IActionResult NuevaVenta()
        {
            return View();
        }

		public IActionResult HistoriaVenta()
        {
            return View();
        }
    }
}