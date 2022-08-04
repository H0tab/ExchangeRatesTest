using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatesTest.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace ExchangeRatesTest.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Valute> Valutes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
    }
}
