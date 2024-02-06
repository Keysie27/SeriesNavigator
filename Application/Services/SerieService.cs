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
    public class SerieService
    {
        private readonly SerieRepository _serieRepository;
        private readonly ProductoraRepository _productoraRepository;
        private readonly GeneroRepository _generoRepository;

        public SerieService(ApplicationContext dbContext)
        {
            _serieRepository = new SerieRepository(dbContext);
            _productoraRepository = new ProductoraRepository(dbContext);
            _generoRepository = new GeneroRepository(dbContext);
        }

        public async Task AddSerie(SaveSerieViewModel vm)
        {
            Serie serie = new()
            {
                Nombre = vm.Nombre,
                Portada = vm.Portada,
                Trailer = vm.Trailer,
                IdProductora = vm.IdProductora,
                IdGenero = vm.IdGenero
            };
            await _serieRepository.AddSerie(serie);
        }
        
        public async Task UpdateSerie(SaveSerieViewModel vm)
        {
            Serie serie = new()
            {
                IdSerie = vm.IdSerie,
                Nombre = vm.Nombre,
                Portada = vm.Portada,
                Trailer = vm.Trailer,
                IdProductora = vm.IdProductora,
                IdGenero = vm.IdGenero
            };
            await _serieRepository.UpdateSerie(serie);
        }
        
        public async Task DeleteSerie(int IdSerie)
        {
            var serie = await _serieRepository.GetSerie(IdSerie);

            await _serieRepository.DeleteSerie(serie);
        }

        public async Task<List<SerieViewModel>> GetSeriesViewModel()
        {
            var seriesList = await _serieRepository.GetListSeries();
            var productorasList = await _productoraRepository.GetListProductoras();
            var generosList = await _generoRepository.GetListGeneros();

            List<SerieViewModel> vm = seriesList.Select(s => new SerieViewModel
            {
                IdSerie = s.IdSerie,
                Nombre = s.Nombre,
                Portada = s.Portada,
                Trailer = s.Trailer,
                IdProductora = s.IdProductora,
                IdGenero = s.IdGenero,
                Productora = productorasList.FirstOrDefault(p => p.IdProductora == s.IdProductora),
                Genero = generosList.FirstOrDefault(g => g.IdGenero == s.IdGenero)
            }).ToList();

            return vm;
        }     
        
        public async Task<SaveSerieViewModel> GetSerieViewModel(int IdSerie)
        {
            var serie= await _serieRepository.GetSerie(IdSerie);

            SaveSerieViewModel vm = new()
            {
                IdSerie = serie.IdSerie,
                Nombre= serie.Nombre,
                Portada = serie.Portada,
                Trailer = serie.Trailer,
                IdProductora = serie.IdProductora,
                IdGenero = serie.IdGenero
            };

            return vm;
        }
        
        public async Task<List<SerieViewModel>> FiltrarPorNombre(string NombreSerie)
        {
            var seriesList = await _serieRepository.GetListSeriesByName(NombreSerie);
            var productorasList = await _productoraRepository.GetListProductoras();
            var generosList = await _generoRepository.GetListGeneros();

            return seriesList.Select(serie => new SerieViewModel
            {
                IdSerie = serie.IdSerie,
                Nombre = serie.Nombre,
                Portada = serie.Portada,
                Trailer = serie.Trailer,
                IdProductora = serie.IdProductora,
                IdGenero = serie.IdGenero,
                Productora = productorasList.FirstOrDefault(p => p.IdProductora == serie.IdProductora),
                Genero = generosList.FirstOrDefault(g => g.IdGenero == serie.IdGenero)
            }).ToList();
        }
        public async Task<List<SerieViewModel>> FiltrarPorProductora(int IdProductora)
        {
            var seriesList = await _serieRepository.GetListSeriesByProducer(IdProductora);
            var productorasList = await _productoraRepository.GetListProductoras();
            var generosList = await _generoRepository.GetListGeneros();

            return seriesList.Select(serie => new SerieViewModel
            {
                IdSerie = serie.IdSerie,
                Nombre = serie.Nombre,
                Portada = serie.Portada,
                Trailer = serie.Trailer,
                IdProductora = serie.IdProductora,
                IdGenero = serie.IdGenero,
                Productora = productorasList.FirstOrDefault(p => p.IdProductora == serie.IdProductora),
                Genero = generosList.FirstOrDefault(g => g.IdGenero == serie.IdGenero)
            }).ToList();
        }
    }
}
