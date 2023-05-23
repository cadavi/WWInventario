using Microsoft.EntityFrameworkCore;
using WWInventario.Data.Base;
using WWInventario.Models;
using WWInventario.Data.ViewModels;

namespace WWInventario.Data.Services
{
    public class EquipoService:EntityBaseRepository<Equipo>, IEquipoService
    {
        private readonly AppDbContext _context;

        public EquipoService(AppDbContext context):base(context)
        {
            _context = context;   
        }

        public async Task<List<Equipo>> GetEquipoByEstatusAsync(int estadoEquipo)
        {
            var equipos = await _context.Equipos.
                Include(td => td.Dispositivo).
                Include(ee => ee.EstadoEquipo).
                Include(u => u.Usuario).
                Where(e => e.EstadoEquipoId == estadoEquipo).ToListAsync();

            return equipos;
        }

        public async Task<Equipo> GetEquipoByIdAsync(int id)
        {
            var equiposDisponibles = await _context.Equipos.
                Include(td => td.Dispositivo).
                Include(ee => ee.EstadoEquipo).
                Include(u => u.Usuario).
                FirstOrDefaultAsync(e => e.Id == id);

            return equiposDisponibles;
        }


        public async Task AddNewEquipoAsync(NewEquipoVM data)
        {
            var newEquipo = new Equipo()
            {
                SerialNo = data.SerialNo,
                Modelo = data.Modelo,
                Marca = data.Marca,
                FechaCompra = data.FechaCompra,
                FechaInicioGarantia = data.FechaInicioGarantia,
                FechaFinGarantia = data.FechaFinGarantia,
                FechaAsignacion = data.FechaAsignacion,
                DispositivoId = data.DispositivoId,
                EstadoEquipoId = data.EstadoEquipoId,
                UsuarioResponsableId = data.UsuarioResponsableId
            };
            await _context.Equipos.AddAsync(newEquipo);
            await _context.SaveChangesAsync();
        }

        public async Task<NewEquipoDropdownVM> GetNewEquipoDropdownsValues()
        {
            var response = new NewEquipoDropdownVM()
            {
                Dispositivos = await _context.Dispositivos.OrderBy(c => c.Tipo).ToListAsync(),
                EstadoEquipos = await _context.EstadoEquipos.OrderBy(c => c.Estado).ToListAsync(),
                Usuarios = await _context.Usuarios.OrderBy(c => c.Nombre).ToListAsync()
            };

            return response;
        }

        public async Task<bool> ExistsSerialNo(string serialNo)
        {
            var sN = await _context.Equipos.
                AnyAsync(e => e.SerialNo.Trim().ToLower() == serialNo.Trim().ToLower());
           
            return sN;
        }

        public async Task UpdateEquipoAsync(NewEquipoVM data)
        {
            var dbEquipo = await _context.Equipos.FirstOrDefaultAsync(c => c.Id == data.Id);

            if(dbEquipo != null)
            {
                dbEquipo.SerialNo = data.SerialNo;
                dbEquipo.Modelo = data.Modelo;
                dbEquipo.Marca = data.Marca;
                dbEquipo.FechaCompra = data.FechaCompra;
                dbEquipo.FechaInicioGarantia = data.FechaInicioGarantia;
                dbEquipo.FechaFinGarantia = data.FechaFinGarantia;
                dbEquipo.FechaAsignacion = data.FechaAsignacion;
                dbEquipo.DispositivoId = data.DispositivoId;
                dbEquipo.EstadoEquipoId = data.EstadoEquipoId;
                dbEquipo.UsuarioResponsableId = data.UsuarioResponsableId;
                await _context.SaveChangesAsync();
            }
        }
    }
}
