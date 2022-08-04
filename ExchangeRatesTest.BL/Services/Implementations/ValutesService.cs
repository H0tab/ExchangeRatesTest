using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatesTest.BL.Helpers;
using ExchangeRatesTest.BL.Services.Abstract;
using ExchangeRatesTest.DataAccess.Models;
using ExchangeRatesTest.DataAccess.Queries;
using ExchangeRatesTest.DataAccess.Repositories.Abstract;
using ExchangeRatesTest.DataAccess.Responses;

namespace ExchangeRatesTest.BL.Services.Implementations
{
    public class ValutesService : IValutesService
    {
        private readonly IValutesRepository _valutesRepository;
        private readonly ValuteAPIFetcher _api;

        public ValutesService(IValutesRepository valutesRepository, ValuteAPIFetcher api)
        {
            _valutesRepository = valutesRepository;
            _api = api;
        }

        public async Task<IBaseResponse<IEnumerable<Valute>>> GetAll()
        {
            var response = new BaseResponse<IEnumerable<Valute>>();

            try
            {
                var valutes = await _valutesRepository.GetAll();
                if (!valutes.Any())
                {
                    var daily = await _api.FetchFromAPI();
                    if (daily != null)
                    {
                        foreach (var valute in daily.Valute)
                        {
                            await _valutesRepository.Create(valute);
                        }
                    }

                    response.Description = "";
                    response.Status = Status.NotFound;

                    return response;
                }

                response.Data = valutes.ToList();
                response.Description = $"";
                response.Status = Status.OK;

                return response;
            }
            catch (Exception e)
            {
                return new BaseResponse<IEnumerable<Valute>>()
                {
                    Description = $"{nameof(GetAll)}: {e.Message}",
                    Status = Status.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<IEnumerable<Valute>>> GetAll(ValuteQueryParameters parameters)
        {
            var response = new BaseResponse<IEnumerable<Valute>>();

            try
            {
                var valutes = await _valutesRepository.GetAll(parameters);
                if (!valutes.Any())
                {
                    var daily = await _api.FetchFromAPI();
                    if (daily != null)
                    {
                        foreach (var valute in daily.Valute)
                        {
                            await _valutesRepository.Create(valute);
                        }
                    }

                    response.Description = "";
                    response.Status = Status.NotFound;

                    return response;
                }

                response.Data = valutes.ToList();
                response.Description = $"";
                response.Status = Status.OK;

                return response;
            }
            catch (Exception e)
            {
                return new BaseResponse<IEnumerable<Valute>>()
                {
                    Description = $"{nameof(GetAll)}: {e.Message}",
                    Status = Status.InternalServerError
                };
            }
        }

        public async Task<IBaseResponse<Valute>> GetById(string id)
        {
            var response = new BaseResponse<Valute>();

            try
            {
                var valute = await _valutesRepository.GetById(id);
                if (valute == null)
                {
                    response.Description = "Valute not found";
                    response.Status = Status.NotFound;

                    return response;
                }

                response.Data = valute;
                response.Description = $"";
                response.Status = Status.OK;

                return response;
            }
            catch (Exception e)
            {
                return new BaseResponse<Valute>()
                {
                    Description = $"{nameof(GetById)}: {e.Message}",
                    Status = Status.InternalServerError
                };
            }
        }
    }
}
