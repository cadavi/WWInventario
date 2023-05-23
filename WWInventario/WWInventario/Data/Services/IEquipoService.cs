using WWInventario.Data.Base;
using WWInventario.Data.ViewModels;
using WWInventario.Models;

namespace WWInventario.Data.Services
{
    public interface IEquipoService : IEntityBaseRepository<Equipo>
    {
        Task<List<Equipo>> GetEquipoByEstatusAsync(int estadoEquipo);
        Task<Equipo> GetEquipoByIdAsync(int id);
        Task AddNewEquipoAsync(NewEquipoVM data);
        Task<NewEquipoDropdownVM> GetNewEquipoDropdownsValues();
        Task<bool> ExistsSerialNo(string serialNo);
        Task UpdateEquipoAsync(NewEquipoVM data);
    }
}
