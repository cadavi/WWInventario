using Microsoft.EntityFrameworkCore;
using WWInventario.Data.Base;
using WWInventario.Data.ViewModels;
using WWInventario.Models;

namespace WWInventario.Data.Services
{
    public class DispositivosService : EntityBaseRepository<Dispositivo>, IDispositivosService
    {
        private readonly AppDbContext _context;
        public DispositivosService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task UpdateDispositivoAsync(int id, Dispositivo data)
        {
            var dnDispositivo = await _context.Dispositivos.FirstOrDefaultAsync(c => c.Id == id);

            if (dnDispositivo != null)
            {
                dnDispositivo.Tipo = data.Tipo;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsTipoDisp(string tipoDisp)
        {
            var tP = await _context.Dispositivos.
                AnyAsync(d => d.Tipo == tipoDisp);

            return tP;
        }

        public bool ExistsChildEquipo(int id)
        {
            return _context.Equipos.Any(e => e.DispositivoId == id);
        }
    }
}
