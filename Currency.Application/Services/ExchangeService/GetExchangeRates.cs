using AutoMapper;
using Currency.Application.Inputs.Queries.ExchangeQueries;
using Currency.Application.Interfaces;
using Currency.Domain.Dtos;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Currency.Application.Services.ExchangeService
{
    public class GetExchangeRates
    {
        public class QueryHandler : IRequestHandler<ExchangeQuery, List<RateDto>>
        {
            private readonly IMapper _mapper;
            private readonly IExchangeProcessor _processor;

            public QueryHandler(IMapper mapper, IExchangeProcessor processor)
            {
                _mapper = mapper;
                _processor = processor;
            }

            public async Task<List<RateDto>> Handle(ExchangeQuery request, CancellationToken cancellationToken)
            {
                var exchange = await _processor.GetExchangeRates(request.ExchangeInput);

                var rates = _processor.ProcessRatesByDate(exchange, request.ExchangeInput.Dates);

                return _mapper.Map<List<RateDto>>(rates);
            }
        }
    }
}