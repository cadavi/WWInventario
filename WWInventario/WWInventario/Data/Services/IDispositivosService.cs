using WWInventario.Data.Base;
using WWInventario.Models;

namespace WWInventario.Data.Services
{
    public interface IDispositivosService : IEntityBaseRepository<Dispositivo>
    {
        Task UpdateDispositivoAsync(int id, Dispositivo data);

        Task<bool> ExistsTipoDisp(string tipoDisp);

        bool ExistsChildEquipo(int id);
    }
}
