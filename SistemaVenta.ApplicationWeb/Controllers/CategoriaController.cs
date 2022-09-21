using Microsoft.AspNetCore.Mvc;

namespace SistemaVenta.ApplicationWeb.Controllers
{
    public class CategoriaController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}