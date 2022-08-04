using ExchangeRatesTest.API;
using ExchangeRatesTest.BL.Helpers;
using ExchangeRatesTest.BL.Services.Abstract;
using ExchangeRatesTest.BL.Services.Implementations;
using ExchangeRatesTest.DataAccess;
using ExchangeRatesTest.DataAccess.Repositories.Abstract;
using ExchangeRatesTest.DataAccess.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IValutesRepository, EFValutesRepository>();
builder.Services.AddScoped<IValutesService, ValutesService>();
builder.Services.AddScoped<ValuteAPIFetcher>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureApi();

app.Run();