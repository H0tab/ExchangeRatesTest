using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatesTest.DataAccess.Models;
using ExchangeRatesTest.DataAccess.Queries;
using ExchangeRatesTest.DataAccess.Responses;

namespace ExchangeRatesTest.BL.Services.Abstract
{
    public interface IValutesService
    {
        Task<IBaseResponse<IEnumerable<Valute>>> GetAll();
        Task<IBaseResponse<IEnumerable<Valute>>> GetAll(ValuteQueryParameters parameters);
        Task<IBaseResponse<Valute>> GetById(string id);
    }
}
