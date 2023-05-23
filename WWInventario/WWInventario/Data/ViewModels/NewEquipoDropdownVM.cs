using WWInventario.Models;

namespace WWInventario.Data.ViewModels
{
	public class NewEquipoDropdownVM
	{
		public List<Dispositivo> Dispositivos { get; set; }
		public List<EstadoEquipo> EstadoEquipos { get; set; }
		public List<Usuario> Usuarios { get; set; }

		public NewEquipoDropdownVM()
		{
            Dispositivos = new List<Dispositivo>();
			EstadoEquipos = new List<EstadoEquipo>();
			Usuarios = new List<Usuario>();
		}
	}
}
