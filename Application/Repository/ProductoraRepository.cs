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
    public class ProductoraRepository
    {
        private readonly ApplicationContext _dbContext;

        public ProductoraRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddProductora(Productora productora)
        {
            await _dbContext.Productoras.AddAsync(productora);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProductora(Productora productora)
        {
            _dbContext.Entry(productora).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductora(Productora productora)
        {
            _dbContext.Set<Productora>().Remove(productora);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Productora>> GetListProductoras()
        {
            return await _dbContext.Set<Productora>().ToListAsync();
        }

        public async Task<Productora> GetProductora(int IdProductora)
        {
            return await _dbContext.Set<Productora>().FindAsync(IdProductora);
        }
    }
}
