using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRatesTest.DataAccess.Models;

public class Daily
{
    public DateTime Date { get; set; }
    public DateTime PreviousDate { get; set; }
    public DateTime Timestamp { get; set; }
    public List<Valute> Valutes { get; set; }
}