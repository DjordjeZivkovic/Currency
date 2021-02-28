using Currency.Domain.Dtos;
using Currency.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Currency.Application.Interfaces
{
    public interface IExchangeProcessor
    {
        Task<Exchange> GetExchangeRates(ExchangeInputDto input);
        IEnumerable<Rate> ProcessRatesByDate(Exchange exchange, IEnumerable<DateTime> Dates);
    }
}
