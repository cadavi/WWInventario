using Microsoft.AspNetCore.Mvc;
using WWInventario.Data.Services;
using WWInventario.Models;

namespace WWInventario.Controllers
{
	public class ProveedoresController : Controller
	{
		private readonly IProveedorService _proveedorService;

		public ProveedoresController(IProveedorService  proveedorService)
		{
			_proveedorService = proveedorService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var data = await _proveedorService.GetAllAsync();
			return View(data);
		}

		[HttpGet]
		public async Task<IActionResult> Delete(int id)
		{
			var proveedor = await _proveedorService.GetByIdAsync(id);
			if(proveedor == null) return View("NotFound");

			return View(proveedor);
		}

		[HttpPost, ActionName("Delete")]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
            var proveedor = await _proveedorService.GetByIdAsync(id);
            if (proveedor == null) return View("NotFound");

			await _proveedorService.DeleteAsync(id);
			return RedirectToAction(nameof(Index));
        }

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			var proveedor = await _proveedorService.GetByIdAsync(id);
			if (proveedor == null) return View("NotFound");

			return View(proveedor);
		}


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var proveedor = await _proveedorService.GetByIdAsync(id);
            if (proveedor == null) return View("NotFound");

            return View(proveedor);
        }

		[HttpPost]
		public async Task<IActionResult> Edit(int id, Proveedor proveedor)
		{
            var data = await _proveedorService.GetByIdAsync(id);
            if (data == null) return View("NotFound");

			await _proveedorService.UpdateProveedorAsync(id, proveedor);

			return RedirectToAction(nameof(Index));

        }

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(Proveedor proveedor)
		{
			if(!ModelState.IsValid) return View(proveedor);

			await _proveedorService.AddAsync(proveedor);

			return RedirectToAction(nameof(Index));
		}

        private async Task ProveedorValidationRules(Proveedor proveedor)
        {
            if (ModelState.IsValid)
            {
                if (await _proveedorService.ExistsNombre(proveedor.Nombre))
                {
                    ModelState.AddModelError("Nombre", "Ya existe un proveerdor con este nombre");
                }
            }
        }
    }
}
