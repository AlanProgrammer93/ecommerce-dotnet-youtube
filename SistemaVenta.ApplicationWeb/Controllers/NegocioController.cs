using Microsoft.AspNetCore.Mvc;

namespace SistemaVenta.ApplicationWeb.Controllers
{
    public class NegocioController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}