using Currency.Application.Inputs.Queries.ExchangeQueries;
using Currency.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Currency.API.Controllers
{
    public class ExchangeController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<List<RateDto>>> ExchangeRates(ExchangeQuery query) => 
            await Mediator.Send(query);
    }
}
