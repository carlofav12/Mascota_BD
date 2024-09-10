using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tarea3.Data;
using Tarea3.Models;
using Tarea3.ViewModel;

namespace Tarea3.Controllers
{
    public class MascotaController : Controller
    {
        private readonly ILogger<MascotaController> _logger;
        private readonly ApplicationDbContext _context;

        public MascotaController(ILogger<MascotaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var misMascotas = from o in _context.Mascotas select o;
            _logger.LogDebug("Mascotas: {misMascotas}", misMascotas);
            var viewModel = new MascotaViewModel
            {
                FormMascota = new Mascota(),
                ListMascota = misMascotas
            };
            _logger.LogDebug("ViewModel: {viewModel}", viewModel);
            return View();
        }

        [HttpPost]
        public IActionResult Insertar(MascotaViewModel viewModel)
        {
            var fechaNacimiento = viewModel.FormMascota.FechaNacimiento.ToUniversalTime();
            var mascota = new Mascota
            {
                Nombre = viewModel.FormMascota.Nombre,
                Raza = viewModel.FormMascota.Raza,
                Color = viewModel.FormMascota.Color,
                FechaNacimiento = fechaNacimiento
            };

            _context.Mascotas.Add(mascota);
            _context.SaveChanges();

            ViewData["Message"] = "Mascota Insertada con éxito";

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }

}