using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WWInventario.Data.Services;
using WWInventario.Models;

namespace WWInventario.Controllers
{
	public class CompaniasController : Controller
	{
		private readonly ICompaniasService _companiasService = null!;

		public CompaniasController(ICompaniasService companiasService)
		{
			_companiasService = companiasService;
		}
		public async Task<IActionResult> Index()
		{
			var allCompanies = await _companiasService.GetAllAsync();
			return View(allCompanies);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create([Bind("Nombre,Pais,LogoPath")] Compania compania)
		{
			await CompaniaValidationRules(compania);

			if (!ModelState.IsValid)
			{
				return View(compania);
			}

			await _companiasService.AddAsync(compania);

			return RedirectToAction(nameof(Index));
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var compania = await _companiasService.GetByIdAsync(id);
			if(compania == null) return View("NotFound");

			return View(compania);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var compania = await _companiasService.GetByIdAsync(id);
			if(compania == null) return View("NotFound");

			return View(compania);
		}

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compania = await _companiasService.GetByIdAsync(id);
            if (compania == null) return View("NotFound");

			await _companiasService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var compania = await _companiasService.GetByIdAsync(id);
			if (compania == null) return View("NotFound");

			return View(compania);
		}

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Nombre,Pais,LogoPath")] Compania compania)
        {
            var comp = await _companiasService.GetByIdAsync(id);
            if (comp == null) return View("NotFound");

			await _companiasService.UpdateCompaniaAsync(id, compania);

            return RedirectToAction(nameof(Index));
        }

        private async Task CompaniaValidationRules(Compania compania)
        {
			if (ModelState.IsValid)
			{
                if (await _companiasService.ExistsNombre(compania.Nombre))
                {
                    ModelState.AddModelError("Nombre", "Ya existe una compañia con este nombre");
                }
            }
        }
    }
}
