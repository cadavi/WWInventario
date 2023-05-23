using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WWInventario.Data.Base;
using WWInventario.Models;

namespace WWInventario.Data.Services
{
    public class ProveedorService:EntityBaseRepository<Proveedor>, IProveedorService
    {
        private readonly AppDbContext _context;

        public ProveedorService(AppDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistsNombre(string nombre) => await _context.Proveedores.AnyAsync(c =>
            c.Nombre.Trim().ToLower() == nombre.Trim().ToLower());

        public async Task UpdateProveedorAsync(int id, Proveedor proveedor)
        {
            var newProveedor = await _context.Proveedores.FirstOrDefaultAsync(c => c.Id == id);
            if (newProveedor != null)
            {
                newProveedor.Id = proveedor.Id;
                newProveedor.Nombre = proveedor.Nombre;
                newProveedor.RNC = proveedor.RNC;
                newProveedor.EmailPrincipal = proveedor.EmailPrincipal;
                newProveedor.EmailSecundario = proveedor.EmailSecundario;
                newProveedor.TelefonoPrincipal = proveedor.TelefonoPrincipal;
                newProveedor.TelefonoSecundario = proveedor.TelefonoSecundario;
                newProveedor.Direccion = proveedor.Direccion;

                await _context.SaveChangesAsync();
            }
        }
    }
}
