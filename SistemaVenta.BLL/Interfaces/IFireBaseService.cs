
namespace SistemaVenta.BLL.Interfaces
{
	public interface IFireBaseService
	{
		Task<string> SubirStorage(Stream StreamArchivo, string CarpetaDestino, string NombreArchivo);
	
		Task<bool> EliminarStorage(string CarpetaDestino, string NombreArchivo);
	}
}