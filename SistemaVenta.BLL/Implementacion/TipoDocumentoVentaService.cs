using System.Net;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.Entity;

namespace SistemaVenta.BLL.Implementation
{
	public class TipoDocumentoVentaService : ITipoDocumentoVentaService
	{
		private readonly IGenericRepository<TipoDocumentoVenta> _repositorio;

		public TipoDocumentoVentaService(IGenericRepository<TipoDocumentoVenta> repositorio)
		{
			_repositorio = repositorio;
		}

		public async Task<List<TipoDocumentoVenta>> Lista()
		{
			IQueryable<TipoDocumentoVenta> query = await _repositorio.Consultar();
			return query.ToList();
		}
	}
}