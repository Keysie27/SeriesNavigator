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
    public class GeneroService
    {
        private readonly GeneroRepository _generoRepository;

        public GeneroService(ApplicationContext dbContext)
        {
            _generoRepository = new GeneroRepository(dbContext);
        }

        public async Task AddGenero(SaveGeneroViewModel vm)
        {
            Genero genero = new()
            {
                Nombre = vm.Nombre,
            };
            await _generoRepository.AddGenero(genero);
        }
        
        public async Task UpdateGenero(SaveGeneroViewModel vm)
        {
            Genero genero = new()
            {
                IdGenero = vm.IdGenero,
                Nombre = vm.Nombre
            };
            await _generoRepository.UpdateGenero(genero);
        }
        
        public async Task DeleteGenero(int IdGenero)
        {
            var genero = await _generoRepository.GetGenero(IdGenero);

            await _generoRepository.DeleteGenero(genero);
        }

        public async Task<List<GeneroViewModel>> GetGenerosViewModel()
        {
            var generosList = await _generoRepository.GetListGeneros();

            return generosList.Select(genero => new GeneroViewModel
            {
                IdGenero = genero.IdGenero,
                Nombre = genero.Nombre
            }).ToList();
        }     
        
        public async Task<SaveGeneroViewModel> GetGeneroViewModel(int IdGenero)
        {
            var genero = await _generoRepository.GetGenero(IdGenero);

            SaveGeneroViewModel vm = new()
            {
                IdGenero = genero.IdGenero,
                Nombre= genero.Nombre
            };

            return vm;
        }
    }
}
