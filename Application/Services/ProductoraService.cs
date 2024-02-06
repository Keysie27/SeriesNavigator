using Application.Repository;
using Application.ViewModels;
using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductoraService
    {
        private readonly ProductoraRepository _productoraRepository;

        public ProductoraService(ApplicationContext dbContext)
        {
            _productoraRepository = new ProductoraRepository(dbContext);
        }

        public async Task AddProductora(SaveProductoraViewModel vm)
        {
            Productora productora = new()
            {
                Nombre = vm.Nombre,
            };
            await _productoraRepository.AddProductora(productora);
        }
        
        public async Task UpdateProductora(SaveProductoraViewModel vm)
        {
            Productora productora = new()
            {
                IdProductora = vm.IdProductora,
                Nombre = vm.Nombre
            };
            await _productoraRepository.UpdateProductora(productora);
        }
        
        public async Task DeleteProductora(int IdProductora)
        {
            var productora = await _productoraRepository.GetProductora(IdProductora);

            await _productoraRepository.DeleteProductora(productora);
        }

        public async Task<List<ProductoraViewModel>> GetProductorasViewModel()
        {
            var productorasList = await _productoraRepository.GetListProductoras();

            return productorasList.Select(productora => new ProductoraViewModel
            {
                IdProductora = productora.IdProductora,
                Nombre = productora.Nombre
            }).ToList();
        }     
        
        public async Task<SaveProductoraViewModel> GetProductoraViewModel(int IdProductora)
        {
            var productora = await _productoraRepository.GetProductora(IdProductora);

            SaveProductoraViewModel vm = new()
            {
                IdProductora = productora.IdProductora,
                Nombre= productora.Nombre
            };

            return vm;
        }
    }
}
