using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WWInventario.Data.Services;
using WWInventario.Models;

namespace WWInventario.Controllers
{
    public class DispositivosController : Controller
    {
        private readonly IDispositivosService _dispositivosService = null!;

        public DispositivosController(IDispositivosService dispositivosService)
        {
            _dispositivosService = dispositivosService;
        }

        public async Task<IActionResult> Index()
        {
            var allDispositivos = await _dispositivosService.GetAllAsync();
            return View(allDispositivos);
        }

        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Tipo")] Dispositivo dispositivo)
        {
            if(await _dispositivosService.ExistsTipoDisp(dispositivo.Tipo))
            {
                ModelState.AddModelError("Tipo", "Ya existe este tipo de dispositivo.");
            }

            if(!ModelState.IsValid)
            {
                return View(dispositivo);
            }

            await _dispositivosService.AddAsync(dispositivo);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dispositivoDet = await _dispositivosService.GetByIdAsync(id);
            if (dispositivoDet == null) return View("NotFound");

            return View(dispositivoDet);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Dispositivo dispositivo)
        {
            var dispositivoDet = await _dispositivosService.GetByIdAsync(id);
            if (dispositivoDet == null) return View("NotFound");


            await _dispositivosService.UpdateDispositivoAsync(id, dispositivo);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var dispositivo = await _dispositivosService.GetByIdAsync(id);
            if (dispositivo == null) return View("NotFound");

            return View(dispositivo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dispositivo = await _dispositivosService.GetByIdAsync(id);
            if (dispositivo == null) return View("NotFound");

            if (_dispositivosService.ExistsChildEquipo(id))
            {
                ModelState.AddModelError("Tipo", "Existen equipos con este tipo de dispositivo." +
                                                 "Debes actualizar o eliminar estos equipos");
            }

            if(!ModelState.IsValid)
            {
                return View(dispositivo);
;           }

            await _dispositivosService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
