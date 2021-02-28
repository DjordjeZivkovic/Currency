using Currency.Domain.Dtos;
using MediatR;
using System.Collections.Generic;

namespace Currency.Application.Inputs.Queries.ExchangeQueries
{
    public class ExchangeQuery : IRequest<List<RateDto>>
    {
        public ExchangeInputDto ExchangeInput { get; set; }
    }
}
