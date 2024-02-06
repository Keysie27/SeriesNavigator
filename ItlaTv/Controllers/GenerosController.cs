using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTv.Controllers
{
    public class GenerosController : Controller
    {
        private readonly GeneroService _generoService;

        public GenerosController(ApplicationContext dbContext)
        {
            _generoService = new GeneroService(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _generoService.GetGenerosViewModel());
        }

        public IActionResult CreateGenero()
        {
            return View("SaveGenero", new SaveGeneroViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenero(SaveGeneroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGenero", vm);
            }
            else
            {
                await _generoService.AddGenero(vm);
                return RedirectToRoute(new { controller = "Generos", action = "Index" });
            }
        }

        public async Task<IActionResult> EditGenero(int IdGenero)
        {
            return View("SaveGenero", await _generoService.GetGeneroViewModel(IdGenero));
        }

        [HttpPost]
        public async Task<IActionResult> EditGenero(SaveGeneroViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveGenero", vm);
            }
            else
            {
                await _generoService.UpdateGenero(vm);
                return RedirectToRoute(new { controller = "Generos", action = "Index" });
            }
        }

        public async Task<IActionResult> DeleteGenero(int IdGenero)
        {
            return View("DeleteGenero", await _generoService.GetGeneroViewModel(IdGenero));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteGeneroPost(int IdGenero)
        {
            await _generoService.DeleteGenero(IdGenero);

            return RedirectToRoute(new { controller = "Generos", action = "Index" });
        }
    }
}
