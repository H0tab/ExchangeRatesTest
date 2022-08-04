using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ExchangeRatesTest.DataAccess.Models;

namespace ExchangeRatesTest.BL.Helpers
{
    public class ValuteAPIFetcher
    {
        private Daily _daily;
        private string error;
        
        public async Task<Daily> FetchFromAPI()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "https://www.cbr-xml-daily.ru/daily_json.js");

            var client = new HttpClient();

            var response = await client.SendAsync(request);
            if (response.IsSuccessStatusCode)
            {
                _daily = await response.Content.ReadFromJsonAsync<Daily>();

                return _daily;
            }
            else
            {
                error = "There was an error getting valutes";

                return null;
            }
        }
    }
}
