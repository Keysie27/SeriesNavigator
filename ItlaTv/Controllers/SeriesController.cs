using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ItlaTv.Controllers
{
    public class SeriesController : Controller
    {
        private readonly SerieService _serieService;
        private readonly ProductoraService _productoraService;
        private readonly GeneroService _generoService;

        public SeriesController(ApplicationContext dbContext)
        {
            _serieService = new SerieService(dbContext);
            _productoraService = new ProductoraService(dbContext);
            _generoService = new GeneroService(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _serieService.GetSeriesViewModel());
        }

        public async Task<IActionResult> CreateSerie()
        {
            SaveSerieViewModel vm = new()
            {
                Productoras = await _productoraService.GetProductorasViewModel(),
                Generos = await _generoService.GetGenerosViewModel()
            };
            return View("SaveSerie", vm);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSerie(SaveSerieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Productoras = await _productoraService.GetProductorasViewModel();
                vm.Generos = await _generoService.GetGenerosViewModel();
                return View("SaveSerie", vm);
            } else
            {
                await _serieService.AddSerie(vm);
                return RedirectToRoute(new { controller="Series", action = "Index" });
            }
        }
        
        public async Task <IActionResult> EditSerie(int IdSerie)
        {
            var vm = await _serieService.GetSerieViewModel(IdSerie);
            vm.Productoras = await _productoraService.GetProductorasViewModel();
            vm.Generos = await _generoService.GetGenerosViewModel();

            return View("SaveSerie", vm);
        }

        [HttpPost]
        public async Task<IActionResult> EditSerie(SaveSerieViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Productoras = await _productoraService.GetProductorasViewModel();
                vm.Generos = await _generoService.GetGenerosViewModel();
                return View("SaveSerie", vm);
            }
            else
            {
                await _serieService.UpdateSerie(vm);
                return RedirectToRoute(new { controller = "Series", action = "Index" });
            }
        }
        
        public async Task <IActionResult> DeleteSerie(int IdSerie)
        {
            return View("DeleteSerie", await _serieService.GetSerieViewModel(IdSerie));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSeriePost(int IdSerie)
        {
            await _serieService.DeleteSerie(IdSerie);

            return RedirectToRoute(new { controller = "Series", action = "Index" });
        }
    }
}
