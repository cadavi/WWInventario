using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WWInventario.Data.Base;
using WWInventario.Models;

namespace WWInventario.Data.Services
{
	public class CompaniasService:EntityBaseRepository<Compania>, ICompaniasService
	{
		private readonly AppDbContext _context;

		public CompaniasService(AppDbContext context):base(context)
		{
			_context = context;
		}

        public async Task UpdateCompaniaAsync(int id, [Bind("Nombre,Pais,LogoPath")] Compania data)
        {
            var compania = await _context.Companias.FirstOrDefaultAsync(c => c.Id == id);

            if (compania != null)
            {
                compania.Nombre = data.Nombre;
                compania.Pais = data.Pais;
                compania.LogoPath = data.LogoPath;

                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsNombre(string nombre) => await _context.Companias.AnyAsync(c => 
			c.Nombre.Trim().ToLower() == nombre.Trim().ToLower());
	}
}
