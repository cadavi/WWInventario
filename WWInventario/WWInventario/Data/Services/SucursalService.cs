using Microsoft.EntityFrameworkCore;
using WWInventario.Data.Base;
using WWInventario.Data.ViewModels;
using WWInventario.Models;

namespace WWInventario.Data.Services
{
    public class SucursalService : EntityBaseRepository<Sucursal>, ISucursalService
    {
        private readonly AppDbContext _context;
        public SucursalService(AppDbContext appDbContext) : base(appDbContext)
        {
            _context = appDbContext;
        }

        public async Task AddNewSucursal(NewSucursalVM data)
        {
            var newSucursal = new Sucursal()
            {
                Nombre = data.Nombre,
                Direccion = data.Direccion,
                CompaniaId = data.CompaniaId
            };
            await _context.Sucursales.AddAsync(newSucursal);
            await _context.SaveChangesAsync();
        }

        public async Task<Sucursal> GetSucursalByIdAsync(int id)
        {
            var sucursal = await _context.Sucursales.
                Include(c => c.Compania).
                FirstOrDefaultAsync(c => c.Id == id);

            return sucursal;
        }

        public async Task<List<Sucursal>> GetAllSucursalsAsync()
        {
            var allSucursals = await _context.Sucursales.
                 Include(c => c.Compania).ToListAsync();

            return allSucursals;
        }

        public async Task<bool> ExistsSucursalName(string nombre)
        {
            var nM = await _context.Sucursales.
                AnyAsync(e => e.Nombre.Trim().ToLower() == nombre.Trim().ToLower()) ;

            return nM;
        }

        public async Task<NewSucursalDropdownVM> GetNewSucursalDropdownsValues()
        {
            var response = new NewSucursalDropdownVM()
            {
                Companias = await _context.Companias.OrderBy(c => c.Nombre).ToListAsync()
            };

            return response;
        }

        public async Task UpdateSucursalAsync(NewSucursalVM data)
        {
            var dbSucursal = await _context.Sucursales.FirstOrDefaultAsync(s => s.Id == data.Id);

            if (dbSucursal != null)
            {
                dbSucursal.Nombre = data.Nombre;
                dbSucursal.Direccion = data.Direccion;
                dbSucursal.CompaniaId = data.CompaniaId;
                await _context.SaveChangesAsync();
            }
        }
    }
}
