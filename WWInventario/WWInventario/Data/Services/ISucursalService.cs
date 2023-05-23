using WWInventario.Data.Base;
using WWInventario.Data.ViewModels;
using WWInventario.Models;

namespace WWInventario.Data.Services
{
    public interface ISucursalService : IEntityBaseRepository<Sucursal>
    {
        Task AddNewSucursal(NewSucursalVM data);
        Task<Sucursal> GetSucursalByIdAsync(int id);
        Task<List<Sucursal>> GetAllSucursalsAsync();
        Task<NewSucursalDropdownVM> GetNewSucursalDropdownsValues();
        Task<bool> ExistsSucursalName(string nombre);
        Task UpdateSucursalAsync(NewSucursalVM data);
    }
}
