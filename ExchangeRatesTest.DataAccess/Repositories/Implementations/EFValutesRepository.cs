using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatesTest.DataAccess.Models;
using ExchangeRatesTest.DataAccess.Queries;
using ExchangeRatesTest.DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ExchangeRatesTest.DataAccess.Repositories.Implementations
{
    public class EFValutesRepository : IValutesRepository
    {
        private readonly AppDbContext _dbContext;

        public EFValutesRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Valute>> GetAll()
        {
            return await _dbContext.Valutes.ToListAsync();
        }

        public async Task<IEnumerable<Valute>> GetAll(ValuteQueryParameters parameters)
        {
            return await _dbContext.Valutes
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToListAsync();
        }

        public async Task<Valute> GetById(string id)
        {
            return await _dbContext.Valutes.FindAsync(id);
        }

        public async Task<bool> Create(Valute entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Valute> Update(Valute entity)
        {
            _dbContext.Update(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(string id)
        {
            var entityToDelete = await _dbContext.Valutes.FindAsync(id);

            if (entityToDelete == null)
            {
                return false;
            }

            _dbContext.Remove(entityToDelete);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
