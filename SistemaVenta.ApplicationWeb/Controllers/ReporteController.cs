using Microsoft.AspNetCore.Mvc;

namespace SistemaVenta.ApplicationWeb.Controllers
{
    public class ReporteController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}