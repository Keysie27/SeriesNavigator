using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using Database.Models;
using ItlaTv.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ItlaTv.Controllers
{
    public class HomeController : Controller
    {
        private readonly SerieService _serieService;
        private readonly ProductoraService _productoraService;
        private readonly GeneroService _generoService;

        public HomeController(ApplicationContext dbContext)
        {
            _serieService = new SerieService(dbContext);
            _productoraService = new ProductoraService(dbContext);
            _generoService = new GeneroService(dbContext);
        } 

        public async Task<IActionResult> Index()
        {
            HomeViewModel vm = new()
            {
                Series = await _serieService.GetSeriesViewModel(),
                Productoras = await _productoraService.GetProductorasViewModel()
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> FiltrarPorNombre(string NombreSerie)
        {
            HomeViewModel vm = new()
            {
                NombreSerie = NombreSerie,
                Productoras = await _productoraService.GetProductorasViewModel()
            };

            if (!string.IsNullOrWhiteSpace(NombreSerie))
            {
                vm.Series = await _serieService.FiltrarPorNombre(NombreSerie);
            }
            else
            {
                vm.Series = await _serieService.GetSeriesViewModel();
            }

            return View("Index", vm);
        }
        
        [HttpPost]
        public async Task<IActionResult> FiltrarPorProductora(int IdProductora)
        {
            HomeViewModel vm = new()
            {
                IdProductora = IdProductora,
                Productoras = await _productoraService.GetProductorasViewModel()
            };

            if (IdProductora != 0)
            {
                vm.Series = await _serieService.FiltrarPorProductora(IdProductora);
            }
            else
            {
                vm.Series = await _serieService.GetSeriesViewModel();
            }

            return View("Index", vm);
        }
        
        public async Task<IActionResult> DetalleSerie(int IdSerie)
        {
            return View(await _serieService.GetSerieViewModel(IdSerie));
        }
    }
}