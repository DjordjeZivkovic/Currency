using Currency.Application.Interfaces;
using Currency.Domain.Enums;
using Currency.Domain.Models;
using System.Threading.Tasks;
using Currency.Common.Extensions;
using Currency.Domain.Dtos;
using Currency.Common;
using System.Linq;
using Currency.Domain.Middlewares;
using System.Net;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System;

namespace Currency.Infrastructure.Processors
{
    public class ExchangeProcessor : IExchangeProcessor
    {
        private readonly IConfiguration _configuration;

        public ExchangeProcessor(IConfiguration configuration) =>
            _configuration = configuration;

        public async Task<Exchange> GetExchangeRates(ExchangeInputDto input)
        {
            var start = input.Dates.MinBy(x => x.Date).ToString("yyyy-MM-dd");
            var end = input.Dates.MaxBy(x => x.Date).ToString("yyyy-MM-dd");

            var baseUrl = _configuration["ExchangeRatesApi:BaseUrl"];
            var url = $"{baseUrl}/history?start_at={start}&end_at={end}&base={input.BaseCurrency}&symbols={input.TargetCurrency}";

            return await RestService.Instance.Get<Exchange>(url);
        }

        public IEnumerable<Rate> ProcessRatesByDate(Exchange exchange, IEnumerable<DateTime> dates)
        {
            var rates = exchange.Rates.Where(x => dates.Any(y => y == x.Key));

            if (rates.Count() == 0)
                throw new RestException(HttpStatusCode.NotFound, Constants.NotFound);

            var min = rates.MinBy(x => x.Value.FirstOrDefault().Value);
            var max = rates.MaxBy(x => x.Value.FirstOrDefault().Value);
            var avg = rates.Average(x => x.Value.FirstOrDefault().Value);

            return new List<Rate>
            {
                new Rate { Range = RangeType.Min.ToString(), Value = min.Value.FirstOrDefault().Value, Date = min.Key },
                new Rate { Range = RangeType.Max.ToString(), Value = max.Value.FirstOrDefault().Value, Date = max.Key },
                new Rate { Range = RangeType.Avg.ToString(), Value = avg }
            };
        }
    }
}