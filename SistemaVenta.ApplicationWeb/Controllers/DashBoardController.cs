using Microsoft.AspNetCore.Mvc;

namespace SistemaVenta.ApplicationWeb.Controllers
{
    public class DashBoardController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}