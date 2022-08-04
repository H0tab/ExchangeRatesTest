using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRatesTest.DataAccess.Responses
{
    public class BaseResponse<T> : IBaseResponse<T>
    {
        public T Data { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }

    public interface IBaseResponse<T>
    {
        T Data { get; }
        string Description { get; }
        Status Status { get; }
    }

    public enum Status
    {
        OK,
        NotFound,
        InternalServerError
    }
}
