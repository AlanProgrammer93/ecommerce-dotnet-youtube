
using SistemaVenta.Entity;

namespace SistemaVenta.BLL.Interfaces
{
	public interface INegocioService
	{
		Task<Negocio> Obtener();
		Task<Negocio> GuardarCambios(Negocio negocio, Stream Logo = null, string NombreLogo = "");
	}
}