using Microsoft.AspNetCore.Mvc;

namespace SistemaVenta.ApplicationWeb.Controllers
{
    public class ProductoController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}