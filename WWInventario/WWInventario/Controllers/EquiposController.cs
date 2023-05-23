using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WWInventario.Data.Services;
using WWInventario.Data.Validation;
using WWInventario.Data.ViewModels;
using WWInventario.Models;

namespace WWInventario.Controllers
{
    public class EquiposController : Controller
    {
        private readonly IEquipoService _equipoService;
        public EquiposController(IEquipoService equipoService)
        {
            _equipoService = equipoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var equipos = await
                _equipoService.GetAllAsync();

            return View(equipos);
        }

        public async Task<IActionResult> Details(int id)
        {
            var equipoDetalles = await _equipoService.GetEquipoByIdAsync(id);
            if (equipoDetalles == null) return View("NotFound");
            return View(equipoDetalles);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var equipoDropdownData = await _equipoService.GetNewEquipoDropdownsValues();

            ViewBag.Dispositivos = new SelectList(equipoDropdownData.Dispositivos, "Id", "Tipo");
            ViewBag.EstadosEquipos = new SelectList(equipoDropdownData.EstadoEquipos, "Id", "Estado");
            ViewBag.Usuarios = new SelectList(equipoDropdownData.Usuarios, "Id", "Nombre");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("SerialNo,Modelo,Marca,FechaCompra,FechaInicioGarantia," +
            "FechaFinGarantia,FechaAsignacion,DispositivoId,EstadoEquipoId,UsuarioResponsableId")] NewEquipoVM equipo)
        {
            await EquipoValidationRules(equipo);

            if (!ModelState.IsValid)
            {
                var equipoDropdownData = await _equipoService.GetNewEquipoDropdownsValues();

                ViewBag.Dispositivos = new SelectList(equipoDropdownData.Dispositivos, "Id", "Tipo");
                ViewBag.EstadosEquipos = new SelectList(equipoDropdownData.EstadoEquipos, "Id", "Estado");
                ViewBag.Usuarios = new SelectList(equipoDropdownData.Usuarios, "Id", "Nombre");

                return View(equipo);
            }

            await _equipoService.AddNewEquipoAsync(equipo);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var equipoDetalles = await _equipoService.GetEquipoByIdAsync(id);
            if (equipoDetalles == null) return View("NotFound");

            var response = new NewEquipoVM()
            {
                SerialNo = equipoDetalles.SerialNo,
                Modelo = equipoDetalles.Modelo,
                Marca = equipoDetalles.Marca,
                FechaCompra = equipoDetalles.FechaCompra,
                FechaInicioGarantia = equipoDetalles.FechaInicioGarantia,
                FechaFinGarantia = equipoDetalles.FechaFinGarantia,
                DispositivoId = equipoDetalles.DispositivoId,
                EstadoEquipoId = equipoDetalles.EstadoEquipoId,
                UsuarioResponsableId = equipoDetalles.UsuarioResponsableId
            };

            var equipoDropdownData = await _equipoService.GetNewEquipoDropdownsValues();

            ViewBag.Dispositivos = new SelectList(equipoDropdownData.Dispositivos, "Id", "Tipo");
            ViewBag.EstadosEquipos = new SelectList(equipoDropdownData.EstadoEquipos, "Id", "Estado");
            ViewBag.Usuarios = new SelectList(equipoDropdownData.Usuarios, "Id", "Nombre");

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SerialNo,Modelo,Marca,FechaCompra,FechaInicioGarantia," +
            "FechaFinGarantia,FechaAsignacion,DispositivoId,EstadoEquipoId,UsuarioResponsableId")] NewEquipoVM equipo)
        {
            await EquipoValidationRules(equipo);

            /*
            var errors = ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .Select(x => new { x.Key, x.Value.Errors })
                .ToArray();
            */

            if (id != equipo.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var equipoDropdownData = await _equipoService.GetNewEquipoDropdownsValues();
                ViewBag.Dispositivos = new SelectList(equipoDropdownData.Dispositivos, "Id", "Tipo");
                ViewBag.EstadosEquipos = new SelectList(equipoDropdownData.EstadoEquipos, "Id", "Estado");
                ViewBag.Usuarios = new SelectList(equipoDropdownData.Usuarios, "Id", "Nombre");

                return View(equipo);
            }

            await _equipoService.UpdateEquipoAsync(equipo);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var equipo = await _equipoService.GetEquipoByIdAsync(id);
            if (equipo == null) return View("NotFound");

            return View(equipo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipo = await _equipoService.GetEquipoByIdAsync(id);
            if (equipo == null) return View("NotFound");

            await _equipoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        private async Task EquipoValidationRules(NewEquipoVM equipo)
        {
            if (ModelState.IsValid)
            {
                if (await _equipoService.ExistsSerialNo(equipo.SerialNo))
                {
                    ModelState.AddModelError("SerialNo", "Existe un equipo con este serial.");
                }

                if (equipo.FechaInicioGarantia >= equipo.FechaFinGarantia)
                {
                    ModelState.AddModelError("FechaFinGarantia", "El fin de la garantia debe ser posterior al inicio.");
                }
            }
        }
    }
}
