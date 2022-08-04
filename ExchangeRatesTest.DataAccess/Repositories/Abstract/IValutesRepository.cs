using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatesTest.DataAccess.Models;

namespace ExchangeRatesTest.DataAccess.Repositories.Abstract
{
    public interface IValutesRepository
    {
        Task<IEnumerable<Valute>> GetAll();
        Task<Valute> GetById(string id);
        Task<bool> Create(Valute entity);
        Task<Valute> Update(Valute entity);
        Task<bool> Delete(string id);
    }
}
