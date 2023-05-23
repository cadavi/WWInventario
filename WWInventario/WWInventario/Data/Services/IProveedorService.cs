using WWInventario.Data.Base;
using WWInventario.Models;

namespace WWInventario.Data.Services
{
    public interface IProveedorService:IEntityBaseRepository<Proveedor>
    {
        Task UpdateProveedorAsync(int id, Proveedor proveedor);
        Task<bool> ExistsNombre(string nombre);
    }
}
