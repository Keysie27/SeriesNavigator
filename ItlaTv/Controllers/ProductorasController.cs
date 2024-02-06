using Application.Services;
using Application.ViewModels;
using Database.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace ItlaTv.Controllers
{
    public class ProductorasController : Controller
    {
        private readonly ProductoraService _productoraService;

        public ProductorasController(ApplicationContext dbContext)
        {
            _productoraService = new ProductoraService(dbContext);
        }

        public async Task<IActionResult> Index()
        {
            return View(await _productoraService.GetProductorasViewModel());
        }

        public IActionResult CreateProductora()
        {
            return View("SaveProductora", new SaveProductoraViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductora(SaveProductoraViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProductora", vm);
            }
            else
            {
                await _productoraService.AddProductora(vm);
                return RedirectToRoute(new { controller = "Productoras", action = "Index" });
            }
        }

        public async Task<IActionResult> EditProductora(int IdProductora)
        {
            return View("SaveProductora", await _productoraService.GetProductoraViewModel(IdProductora));
        }

        [HttpPost]
        public async Task<IActionResult> EditProductora(SaveProductoraViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveProductora", vm);
            }
            else
            {
                await _productoraService.UpdateProductora(vm);
                return RedirectToRoute(new { controller = "Productoras", action = "Index" });
            }
        }

        public async Task<IActionResult> DeleteProductora(int IdProductora)
        {
            return View("DeleteProductora", await _productoraService.GetProductoraViewModel(IdProductora));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProductoraPost(int IdProductora)
        {
            await _productoraService.DeleteProductora(IdProductora);

            return RedirectToRoute(new { controller = "Productoras", action = "Index" });
        }
    }
}
