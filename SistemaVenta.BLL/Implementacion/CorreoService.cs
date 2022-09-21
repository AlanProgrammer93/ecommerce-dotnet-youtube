using System.Net;
using System.Net.Mail;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using SistemaVenta.BLL.Interfaces;
using SistemaVenta.DAL.Interfaces;
using SistemaVenta.Entity;

namespace SistemaVenta.BLL.Implementation
{
	public class CorreoService : ICorreoService
	{
		private readonly IGenericRepository<Configuracion> _repository;

		public CorreoService(IGenericRepository<Configuracion> repository)
		{
			_repository = repository;
		}

		public async Task<bool> EnviarCorreo(string CorreoDestino, string Asunto, string Mensaje)
		{
			try
			{
				IQueryable<Configuracion> query = await _repository.Consultar(c => c.Recurso.Equals("Service_Correo"));

				Dictionary<string, string> Config = query.ToDictionary(keySelector: c => c.Propiedad, elementSelector: c => c.Valor);

				var credenciales = new NetworkCredential(Config["correo"], Config["clave"]);

				var correo = new MailMessage()
				{
					From = new MailAddress(Config["correo"], Config["alias"]),
					Subject = Asunto,
					Body = Mensaje,
					IsBodyHtml = true
				};

				correo.To.Add(new MailAddress(CorreoDestino));

				var clienteServidor = new SmtpClient()
				{
					Host = Config["host"],
					Port = int.Parse(Config["puerto"]),
					Credentials = credenciales,
					DeliveryMethod = SmtpDeliveryMethod.Network,
					UseDefaultCredentials = false,
					EnableSsl = true
				};

				clienteServidor.Send(correo);
				return true;
			}
			catch 
			{
				return false;
			}
		}
	}
}