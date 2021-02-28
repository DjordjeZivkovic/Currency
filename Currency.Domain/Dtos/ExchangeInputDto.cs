using System;
using System.Collections.Generic;

namespace Currency.Domain.Dtos
{
    public class ExchangeInputDto
    {
        public List<DateTime> Dates { get; set; }
        public string BaseCurrency { get; set; }
        public string TargetCurrency { get; set; }
    }
}
