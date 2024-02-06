using Database.Contexts;
using Database.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repository
{
    public class GeneroRepository
    {
        private readonly ApplicationContext _dbContext;

        public GeneroRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddGenero(Genero genero)
        {
            await _dbContext.Generos.AddAsync(genero);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateGenero(Genero genero)
        {
            _dbContext.Entry(genero).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteGenero(Genero genero)
        {
            _dbContext.Set<Genero>().Remove(genero);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Genero>> GetListGeneros()
        {
            return await _dbContext.Set<Genero>().ToListAsync();
        }

        public async Task<Genero> GetGenero(int IdGenero)
        {
            return await _dbContext.Set<Genero>().FindAsync(IdGenero);
        }
    }
}
