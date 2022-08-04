using ExchangeRatesTest.BL.Services.Abstract;
using ExchangeRatesTest.DataAccess.Queries;
using ExchangeRatesTest.DataAccess.Repositories.Abstract;
using ExchangeRatesTest.DataAccess.Responses;
using Microsoft.AspNetCore.Mvc;
using Results = Microsoft.AspNetCore.Http.Results;

namespace ExchangeRatesTest.API
{
    public static class Api
    {
        public static void ConfigureApi(this WebApplication app)
        {
            app.MapGet("/currencies", GetCurrencies);
            app.MapGet("/currency/{id}", GetCurrency);
        }

        private static async Task<IResult> GetCurrencies([FromServices] IValutesService service)
        {
            var response = await service.GetAll();
            if (response.Status == Status.OK)
            {
                return Results.Ok(response.Data);
            }

            return Results.Problem(response.Description);
        }

        private static async Task<IResult> GetCurrency(string id, [FromServices] IValutesService service)
        {
            var response = await service.GetById(id);
            if (response.Status == Status.OK)
            {
                return Results.Ok(response.Data);
            }

            return Results.Problem(response.Description);
        }
    }
}
