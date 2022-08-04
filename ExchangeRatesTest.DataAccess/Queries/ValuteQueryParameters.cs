using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRatesTest.DataAccess.Queries
{
    public class ValuteQueryParameters
    {
        private const int maxPageSize = 35;
        public int PageNumber { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }

        public static bool TryParse(string? value, out ValuteQueryParameters? parameters)
        {
            var trimmedValue = value?.TrimStart('(').TrimEnd(')');
            var segments = trimmedValue?.Split(',',
                StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            if (segments?.Length == 2
               && int.TryParse(segments[0], out var pageNumber)
               && int.TryParse(segments[1], out var pageSize))
            {
                parameters = new ValuteQueryParameters {PageNumber = pageNumber, _pageSize = pageSize};
                return true;
            }

            parameters = null;
            return false;
        }
    }
}
