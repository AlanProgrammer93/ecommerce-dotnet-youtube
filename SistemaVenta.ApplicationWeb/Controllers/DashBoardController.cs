using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using SistemaVenta.ApplicationWeb.Models.ViewModels;
using SistemaVenta.ApplicationWeb.Utilidades.Response;
using SistemaVenta.BLL.Interfaces;

namespace SistemaVenta.ApplicationWeb.Controllers
{
    [Authorize]
    public class DashBoardController: Controller
    {
        private readonly IDashboardService _dashboardService;

        public DashBoardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerResumen()
        {
            GenericResponse<VMDashBoard> gResponse = new GenericResponse<VMDashBoard>();

            try
            {
                VMDashBoard vmDashboard = new VMDashBoard();

                vmDashboard.TotalVentas = await _dashboardService.TotalVentasUltimaSemana();
                vmDashboard.TotalIngresos = await _dashboardService.TotalIngresosUltimaSemana();
                vmDashboard.TotalProductos = await _dashboardService.TotalProductos();
                vmDashboard.TotalCategorias = await _dashboardService.TotalCategorias();

                List<VMVentasSemana> listaVentasSemana = new List<VMVentasSemana>();
                List<VMProductosSemana> listaProductosSemana = new List<VMProductosSemana>();

                foreach(KeyValuePair<string, int> item in await _dashboardService.VentasUltimaSemana()) {
                    listaVentasSemana.Add(new VMVentasSemana(){
                        Fecha = item.Key,
                        Total = item.Value
                    });
                }

                foreach(KeyValuePair<string, int> item in await _dashboardService.ProductosTopUltimaSemana()) {
                    listaProductosSemana.Add(new VMProductosSemana(){
                        Producto = item.Key,
                        Cantidad = item.Value
                    });
                }

                vmDashboard.VentasUltimaSemana = listaVentasSemana;
                vmDashboard.ProductosTopUltimaSemana = listaProductosSemana;

                gResponse.Estado = true;
                gResponse.Objeto = vmDashboard;
            }
            catch (Exception ex)
            {
                gResponse.Estado = false;
                gResponse.Mensaje = ex.Message;
            }

            return StatusCode(StatusCodes.Status200OK, gResponse);
        }
    }
}