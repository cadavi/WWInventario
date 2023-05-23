using WWInventario.Data.Base;
using WWInventario.Models;

namespace WWInventario.Data.Services
{
	public interface ICompaniasService : IEntityBaseRepository<Compania>
	{
		Task UpdateCompaniaAsync(int id, Compania data);
		Task<bool> ExistsNombre(string nombre);
	}
}
