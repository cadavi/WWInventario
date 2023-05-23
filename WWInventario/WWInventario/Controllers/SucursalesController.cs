using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WWInventario.Data;
using WWInventario.Data.Services;
using WWInventario.Data.ViewModels;
using WWInventario.Models;

namespace WWInventario.Controllers
{
    public class SucursalesController : Controller
    {
        private readonly ISucursalService _sucursalService;

        public SucursalesController(ISucursalService sucursalService)
        {
            _sucursalService = sucursalService;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _sucursalService.GetAllSucursalsAsync();
            return View(data);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var sucursales = await _sucursalService.GetByIdAsync(id);
            if (sucursales == null) return View("NotFound");

            var response = new NewSucursalVM()
            {
                CompaniaId = sucursales.CompaniaId,
                Nombre = sucursales.Nombre,
                Direccion = sucursales.Direccion
            };

            var sucursalDropdownData = await _sucursalService.GetNewSucursalDropdownsValues();

            ViewBag.Companias = new SelectList(sucursalDropdownData.Companias, "Id", "Nombre");
            
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Direccion,CompaniaId")] NewSucursalVM sucursal)
        {
            //await SucursalValidationRule(sucursal);

            if (id != sucursal.Id) return View("NotFound");

            if(!ModelState.IsValid)
            {
                var sucursalDropdownData = await _sucursalService.GetNewSucursalDropdownsValues();
                ViewBag.Companias = new SelectList(sucursalDropdownData.Companias, "Id", "Nombre");

                return View(sucursal);
            }

            await _sucursalService.UpdateSucursalAsync(sucursal);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var sucursal = await _sucursalService.GetSucursalByIdAsync(id);
            if (sucursal == null) return View("NotFound");

            return View(sucursal);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var sucursalDropdownData = await _sucursalService.GetNewSucursalDropdownsValues();

            ViewBag.Companias = new SelectList(sucursalDropdownData.Companias, "Id", "Nombre");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nombre,Direccion,CompaniaId")] NewSucursalVM sucursal)
        {
            await SucursalValidationRule(sucursal);

            if (!ModelState.IsValid)
            {
                return View(sucursal);
            }

            await _sucursalService.AddNewSucursal(sucursal);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var sucursal = await _sucursalService.GetSucursalByIdAsync(id);
            if (sucursal == null) return View("NotFound");

            return View(sucursal);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sucursal = await _sucursalService.GetSucursalByIdAsync(id);
            if (sucursal == null) return View("NotFound");

            await _sucursalService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task SucursalValidationRule(NewSucursalVM sucursal)
        {
            if(ModelState.IsValid)
            {
                if(await _sucursalService.ExistsSucursalName(sucursal.Nombre))
                {
                    ModelState.AddModelError("Nombre", "Ya existe una sucursal con este nombre");
                }
            }
        }
    }
}
